using LibraryProject.Models;

namespace LibraryProject.Repositories
{
    public interface IHistoryRepo
    {
        public List<Borrowing> userHistory(string id);
        public List<Book> getBooks(string bookId);
        public List<Kind> getKinds();


    }
}
