using Microsoft.AspNetCore.Mvc;

namespace LMS.Controllers
{
    [Route("Learner")]
    public class LearnerController : Controller
    {
        [HttpPost]
        [Route("Index")]
        public IActionResult Index(string username, string password)
        {
            if (username == "learner" && password == "pass")
                return RedirectToAction("Dashboard");
            return RedirectToAction("LearnerLogin", "Home");
        }

        [Route("Dashboard")]
        public IActionResult Dashboard() => View();

        [Route("UpdateProfile")]
        public IActionResult UpdateProfile() => View();

        [HttpPost]
        [Route("UpdateProfile")]
        public IActionResult UpdateProfile(string name, string email)
        {
            ViewBag.Message = "Profile updated!";
            return View();
        }

        [Route("SearchContent")]
        public IActionResult SearchContent() => View();

        [HttpPost]
        [Route("SearchContent")]
        public IActionResult SearchContent(string keyword)
        {
            ViewBag.Results = $"Results for '{keyword}'";
            return View();
        }

        [Route("Logout")]
        public IActionResult Logout() => RedirectToAction("Login", "Home");
    }
}
