using LibraryProject.Models;
using LibraryProject.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace LibraryProject.Controllers
{
    public class TestController : Controller
    {
        ITestRepo test;
        public TestController(ITestRepo _test)
        {
            test = _test;
        }
        public IActionResult Index()
        {
            return View(test.showall());
        }
    }
}
