using LibraryProject.Models;
using LibraryProject.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Security.Claims;

namespace LibraryProject.Controllers
{
    [Authorize(Roles ="admin")]
    //[Authorize(Roles ="Admin")]
    public class TestController : Controller
    {
        ITestRepo test;
        public TestController(ITestRepo _test)
        {
            test = _test;
        }
        [Authorize]
        public IActionResult Index()
        {
            return View(test.showall());
        }
        public IActionResult testAuth()
        {

            if (User.Identity.IsAuthenticated == true)
            {
                Claim IDClaim = User.Claims.
                    FirstOrDefault(p => p.Type == ClaimTypes.NameIdentifier);
                string id = IDClaim.Value;
                string name = User.Identity.Name;
                return Content($"id :{id} \n Name : {name}");
            }
            return Content("welcom gust");
        }
    }
}
