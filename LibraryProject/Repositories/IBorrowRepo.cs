using LibraryProject.Models;

namespace LibraryProject.Repositories
{
    public interface IBorrowRepo
    {
        public List<Borrowing> GetAll();
        public Borrowing GetById(int id);
        public void AddBorrowing(Borrowing borrowing);
        public void UpdateBorrowing(Borrowing obj);
        public void DeleteBorrowing(int id);
        public List<ApplicationUser>GetAllUsers();
        public void Save();
        
    }
}
