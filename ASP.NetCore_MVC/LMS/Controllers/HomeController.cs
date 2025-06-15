using Microsoft.AspNetCore.Mvc;

namespace LMS.Controllers
{
    [Route("")]
    [Route("Home")]
    public class HomeController : Controller
    {
        [Route("")]
        [Route("Index")]
        public IActionResult Index() => View();

        [Route("About")]
        public IActionResult About() => View();

        [Route("Contact")]
        public IActionResult Contact() => View();

        [Route("Login")]
        public IActionResult Login() => View();

        [Route("AdminLogin")]
        public IActionResult AdminLogin() => View();

        [Route("TrainerLogin")]
        public IActionResult TrainerLogin() => View();

        [Route("LearnerLogin")]
        public IActionResult LearnerLogin() => View();
    }
}