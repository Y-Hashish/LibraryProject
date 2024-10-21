using LibraryProject.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryProject.Repositories
{
    public class BorrowRepo : IBorrowRepo
    {
        ApplicationDBContext dbContext;
        public BorrowRepo(ApplicationDBContext _context)
        {
            dbContext = _context;
        }
        public List<ApplicationUser> GetAllUsers()
        {
            return dbContext.Users.ToList();
            
        }

        public List<Borrowing> GetAll()
        {
            //return dbContext.Borrowings.ToList();
            return dbContext.Borrowings.Include("ApplicationUser").ToList();

        }
        public Borrowing GetById(int id)
        {
            return dbContext.Borrowings.FirstOrDefault(br => br.Id == id);

        }
        public void AddBorrowing(Borrowing borrowing)
        {
            dbContext.Add(borrowing);
        }
        public void UpdateBorrowing( Borrowing obj)
        {
            
            dbContext.Update(obj);
            
        }
        public void DeleteBorrowing(int id)
        {
            Borrowing borrow = GetById(id);
            dbContext.Remove(borrow);
        }
        public void Save()
        {
            dbContext.SaveChanges();
        }

    }
}
