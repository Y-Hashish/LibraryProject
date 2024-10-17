using Microsoft.AspNetCore.Mvc;

namespace LibraryProject.Controllers
{
    public class AccountController : Controller
    {
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
    }
}
