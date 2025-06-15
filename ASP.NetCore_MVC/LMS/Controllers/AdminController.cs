using Microsoft.AspNetCore.Mvc;

namespace LMS.Controllers
{
    [Route("Admin")]
    public class AdminController : Controller
    {
        [HttpPost]
        [Route("Index")]
        public IActionResult Index(string username, string password)
        {
            if (username == "admin" && password == "pass")
                return RedirectToAction("Dashboard");
            return RedirectToAction("AdminLogin", "Home");
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

        [Route("ManageCourses")]
        public IActionResult ManageCourses() => View();

        [HttpPost]
        [Route("ManageCourses")]
        public IActionResult ManageCourses(string courseName)
        {
            ViewBag.Message = "Course added successfully!";
            return View();
        }

        [Route("ManageTrainers")]
        public IActionResult ManageTrainers() => View();

        [Route("ManageLearners")]
        public IActionResult ManageLearners() => View();

        [Route("Logout")]
        public IActionResult Logout() => RedirectToAction("Login", "Home");
    }
}