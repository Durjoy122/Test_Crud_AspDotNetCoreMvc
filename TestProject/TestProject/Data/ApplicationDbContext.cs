using TestProject.Models;
using Microsoft.EntityFrameworkCore;
namespace TestProject.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        {

        }
        public DbSet<Category> Myproperties { set; get; } // [Myproperties] is the name of the table in the database
    }
}
