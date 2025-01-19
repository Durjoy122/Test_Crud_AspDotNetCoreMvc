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

        // Category is model
        // Myproperties is the table name
        // DbSet is used to create a table in the database
        // AplicationDbContext is the class that is used to create a database
    }
}
