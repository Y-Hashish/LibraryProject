using LibraryProject.Models;

namespace LibraryProject.Repositories
{
    public class TestRepo : ITestRepo
    {
        ApplicationDBContext context;
        public TestRepo(ApplicationDBContext _context)
        {
            context = _context;
            //context = new ApplicationDBContext();
        }
        public List<test> showall()
        {
            return context.tests.ToList();
        }
    }
}
