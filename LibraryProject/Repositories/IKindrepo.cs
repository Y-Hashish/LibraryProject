using LibraryProject.Models;

namespace LibraryProject.Repositories
{
    public interface IKindrepo
    {
        void Add(Kind kind);
        List<Kind> GetAll();
        Kind GetById(int id);
        void Remove(Kind kind);
        void Update(Kind kind);
        void SaveChanges();
    }
}
