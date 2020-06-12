using Microsoft.EntityFrameworkCore;

namespace Models
{
    public class LibraryDBContext: DbContext
    {
        public DbSet<Authors> Authors { get; set; }
        public DbSet<Books> Books { get; set; }
        public DbSet<Categories> Categories { get; set; }
        public DbSet<Users> Users { get; set; }
        public DbSet<UserType> UserTypes { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlServer(@"Data Source=DESKTOP-7D7Q0JH;Initial Catalog=LibraryDB;Integrated Security=True");
        }
    }
}
