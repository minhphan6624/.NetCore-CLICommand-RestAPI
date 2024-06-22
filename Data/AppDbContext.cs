using CLICommandStorage.Models;
using Microsoft.EntityFrameworkCore;

namespace CLICommandStorage.Data
{
    public class AppDbContext : DbContext
    {
        // Constructor
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        //Maps the Command model to the Commands table in the database
        public DbSet<Command> Commands { get; set; }
    }
}