using LibraryProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace LibraryProject.Controllers
{
    public class BookController : Controller
    {
        ApplicationDBContext context;
        public BookController(ApplicationDBContext _context)
        {
            context = _context;
        }
        public IActionResult AllBooks()
        {

            List<Book> books = context.Books.ToList();
            return View("BookView", books);
        }
    }
    
}
