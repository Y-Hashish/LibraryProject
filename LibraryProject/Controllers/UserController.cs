using LibraryProject.Models;
using LibraryProject.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace LibraryProject.Controllers
{
    public class UserController : Controller
    {
        IHistoryRepo historyRepo;
        public UserController(IHistoryRepo _historyRepo)
        {
            this.historyRepo = _historyRepo;
        }
        public IActionResult History ()
        {
            if(User.Identity.IsAuthenticated == true)
            {
                string claimId =User.Claims.FirstOrDefault(p => p.Type == ClaimTypes.NameIdentifier).Value;
                ViewBag.kind = historyRepo.getKinds();
                return View("History",historyRepo.getBooks(claimId));
            }
            return View("customError");
        }
    }
}
