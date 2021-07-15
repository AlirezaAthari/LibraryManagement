using Microsoft.EntityFrameworkCore;

namespace wpf_start.Models
{
    public class LibraryDatabase : DbContext
    {
        public DbSet <User> Users { get; set; }
        public DbSet <Manager> Managers { get; set; }
        public DbSet <Librarian> Librarians { get; set; }
        public DbSet <Member> Members { get; set; }
        public DbSet <Book> Books { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=LibraryDatabase;Trusted_Connection=True");
        }
    }
}