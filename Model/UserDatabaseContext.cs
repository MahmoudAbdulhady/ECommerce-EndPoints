using Microsoft.EntityFrameworkCore;

namespace EcommerceApp.Model
{
    public class UserDatabaseContext : DbContext
    {
        public UserDatabaseContext()
        {

        }
        public UserDatabaseContext(DbContextOptions<UserDatabaseContext> options)
        : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=UserDatabase;Trusted_Connection=True;");
        }

        
        public DbSet<User> Users { get; set; }
        public DbSet<Products> Products { get; set; }
      



    }
}
