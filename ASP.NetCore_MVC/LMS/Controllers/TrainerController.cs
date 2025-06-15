using Microsoft.AspNetCore.Mvc;

namespace LMS.Controllers
{
    [Route("Trainer")]
    public class TrainerController : Controller
    {
        [HttpGet("Login")]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [Route("Index")]
        public IActionResult Login(string username, string password)
        {
            if (username == "trainer" && password == "pass")
                return RedirectToAction("Dashboard");

            ViewBag.Message = "Invalid username or password.";
            return View();
        }

        [HttpGet("Dashboard")]
        public IActionResult Dashboard()
        {
            return View();
        }

        [HttpGet("UpdateProfile")]
        public IActionResult UpdateProfile() => View();

        [HttpPost("UpdateProfile")]
        public IActionResult UpdateProfile(string name, string email)
        {
            ViewBag.Message = "Profile updated!";
            return View();
        }

        [HttpGet("ManageContent")]
        public IActionResult ManageContent() => View();

        [HttpPost("ManageContent")]
        public IActionResult ManageContent(string title)
        {
            ViewBag.Message = "Content added successfully!";
            return View();
        }

        [HttpGet("Logout")]
        public IActionResult Logout() => RedirectToAction("Login", "Home");
    }
}
