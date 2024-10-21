using LibraryProject.Models;

namespace LibraryProject.Repositories
{
    public class Kindrepo: IKindrepo
    {
        private readonly ApplicationDBContext context;

        public Kindrepo(ApplicationDBContext _context)
        {
            context = _context;
        }

        public void Add(Kind kind)
        {
            context.Kinds.Add(kind);
        }
        public List<Kind> GetAll()
        {
            return context.Kinds.ToList();
        }

        public Kind GetById(int id)
        {
            return context.Kinds.Find(id);
        }

        public void Remove(Kind kind)
        {
            context.Kinds.Remove(kind);
        }
        public void Update(Kind kind)
        {
            context.Kinds.Update(kind);
        }
        public void SaveChanges ()
        {
            context.SaveChanges();
        }
    }
}
