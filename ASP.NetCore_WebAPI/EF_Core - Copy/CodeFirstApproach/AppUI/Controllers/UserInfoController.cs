using AppUI.Models;
using Microsoft.AspNetCore.Mvc;

namespace AppUI.Controllers
{
    [Route("UserInfo")]
    public class UserInfoController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public UserInfoController(IHttpClientFactory httpClientFactory)
        {
            this._httpClientFactory = httpClientFactory;
        }

        [NonAction]
        public HttpClient GetClient()
        {
            var client = this._httpClientFactory.CreateClient("ApiClient");
            return client;
        }

        [Route("/")]
        [Route("LoginPage", Name = "LoginPage")]
        public IActionResult LoginPage()
        {
            return View();
        }

        [HttpPost]
        [Route("ValidateUser", Name = "ValidateUser")]
        public async Task<IActionResult> LoginPage(UserInfo userInfo)
        {
            var client = GetClient();
            var response = await client.PostAsJsonAsync($"api/v1.0/UserInfo/ValidateUser", userInfo);
            if (response.IsSuccessStatusCode)//200-299
            {
                var token = response.Content.ReadAsStringAsync();
                HttpContext.Session.SetString("jwttoken", token.Result);
                return RedirectToRoute("EventList");
            }
            else
            {
                return View();
            }

        }

    }
}