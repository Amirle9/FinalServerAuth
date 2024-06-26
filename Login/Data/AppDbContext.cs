using Login.Models;
using Microsoft.EntityFrameworkCore;


namespace Login.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<User> Users { get; set; }      //DbSet representing the Users table in the databse
    }
}
