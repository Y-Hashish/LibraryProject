using LibraryProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace LibraryProject.Controllers
{
    public class BorrowingController : Controller
    {

        ApplicationDBContext context ;
        public BorrowingController(ApplicationDBContext _context)
        {
            context = _context;
            
        }

        public IActionResult Index()
        {
            List<Borrowing> b = context.Borrowings.ToList();
            return View(b);
        }
    }
}
