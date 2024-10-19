using LibraryProject.Models;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
//using AspNetCore;

namespace LibraryProject.Repositories
{
    public class HistoryRepo:IHistoryRepo
    {
        ApplicationDBContext context;
        public HistoryRepo(ApplicationDBContext _context)
        {
            context = _context;
        }
        public List<Borrowing> userHistory(string id)
        {
            
            var items = context.Borrowings
                               .Where(b => b.ApplicationUserId == id) 
                               .ToList();
            return items;  
        }
        public List<Book> getBooks(string id)
        {
            List<Book> books = new List<Book>();
            foreach(var item in userHistory(id))
            {
                var x = context.Books.FirstOrDefault(i=>i.Id==item.BookId);
                books.Add(x);
            }
            return books;
        }
        public List<Kind >getKinds()
        {
            return context.Kinds.ToList();
        }


    }
}
