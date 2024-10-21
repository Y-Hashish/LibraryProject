using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LibraryProject.Models
{
    public class ApplicationDBContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<test> tests { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Kind> Kinds { get; set; }
        public DbSet<BookStatus> BookStatuses { get; set; }
        public DbSet<Borrowing> Borrowings { get; set; }

        //public DbSet<ApplicationUser> User { get; set; }
        public ApplicationDBContext():base()
        {}
        public ApplicationDBContext(DbContextOptions options):base(options) 
        {}
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("Data Source=DESKTOP-9856E0J;Initial Catalog=LIB_PROJ;Integrated Security=True;Encrypt=False;Trust Server Certificate=True");
        //    base.OnConfiguring(optionsBuilder);
        //}
    }
}
