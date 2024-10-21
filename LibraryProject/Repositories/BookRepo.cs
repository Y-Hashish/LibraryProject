using LibraryProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace LibraryProject.Repositories
{
    public class BookRepo : IBookRepo
    {
        ApplicationDBContext dbContext;
         public BookRepo(ApplicationDBContext _context)
        {
            dbContext = _context;
        }
        public List<Book> GetAll()
        {

           return dbContext.Books.ToList();
        }
        public void Add(Book obj)
        {
            dbContext.Add(obj);
        }


        public void Update(Book obj)
        {
            dbContext.Update(obj);
        }


        public void Delete( int id)
        {
            Book book = GetById(id);
            dbContext.Remove(book);
        }
        public Book GetById(int id)
        {
            return dbContext.Books.FirstOrDefault(b => b.Id == id);
        }


        public List<Book> Search(string name)
        {
            List<Book> bookAuthor = dbContext.Books.Where(b => b.Author == name).ToList();
            return bookAuthor;
        }

        public void Save()
        {
            dbContext.SaveChanges();
        }

    }
}
