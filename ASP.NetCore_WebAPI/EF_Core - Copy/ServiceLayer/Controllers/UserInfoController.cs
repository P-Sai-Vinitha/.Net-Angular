using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using DAL.DataAccess;
using DAL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace ServiceLayer.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]  //http://localhost:5015/api/v1.0/UserInfo/
    [ApiController]
    public class UserInfoController : ControllerBase
    {
        private readonly IUserInfoRepo<UserInfo> _userRepo;
        private readonly IConfiguration _configuration;

        public UserInfoController(IUserInfoRepo<UserInfo> userRepo, IConfiguration configuration)
        {
            _userRepo = userRepo;
            _configuration = configuration;
        }

        
        [HttpGet]
        [Route("GetAll")]
        public IActionResult GetAll()
        {
            var list = _userRepo.GetAllUsers();
            if (list != null && list.Any())
                return Ok(list);
            return NotFound("No users found.");
        }

        [HttpGet]
        [Route("GetByEmail/{emailId}")]
        public IActionResult GetByEmail(string email)
        {
            var user = _userRepo.GetUserByEmail(email);
            if (user != null)
                return Ok(user);
            return NotFound($"User with email '{email}' not found.");
        }

        [HttpPost]
        [Route("Add")]
        public IActionResult Add([FromBody] UserInfo user)
        {
            if (ModelState.IsValid)
            {
                var created = _userRepo.AddUser(user);
                return Created(HttpContext.Request.Path, created);
            }
            return BadRequest(ModelState);
        }

        [HttpPut]
        [Route("Update")]
        public IActionResult Update([FromBody] UserInfo user)
        {
            if (ModelState.IsValid)
            {
                var updated = _userRepo.UpdateUser(user);
                if (updated != null)
                    return Ok(updated);
                return NotFound($"User with email '{user.EmailId}' not found.");
            }
            return BadRequest(ModelState);
        }

        [HttpDelete]
        [Route("Delete/{emailId}")]
        public IActionResult Delete(string email)
        {
            var deleted = _userRepo.DeleteUser(email);
            if (deleted != null)
                return Ok(deleted);
            return NotFound($"User with email '{email}' not found.");
        }

        [HttpPost]
        [Route("ValidateUser")]

        public IActionResult ValidateUser([FromBody] UserInfo userInfo)
        {
            var user = _userRepo.ValidateUser(userInfo.EmailId, userInfo.Password);
            if (user != null)
            {
                //Generate token
                var token = GenerateToken(userInfo);
                return Ok(token);
            }
            else
            {
                return Unauthorized();//401
            }
        }

        [NonAction]
        public string GenerateToken(UserInfo userInfo)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var signingCredential = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var issuer = _configuration["Jwt:Issuer"];
            var audience = _configuration["Jwt:Audience"];

            var claims = new[]
            {
                new Claim(ClaimTypes.Email,userInfo.EmailId),
                new Claim(ClaimTypes.Role,userInfo.Role)
            };

            var token = new JwtSecurityToken(issuer, audience, claims, expires: DateTime.Now.AddMinutes(30), signingCredentials: signingCredential);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
