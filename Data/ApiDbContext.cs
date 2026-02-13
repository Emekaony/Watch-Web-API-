using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Data {
    // responsible for interacting with the Database
    // using the primary constructor
    public class ApiDbContext(DbContextOptions<ApiDbContext> options) : DbContext(options) {
        // from what I know so far, this will ceate a table in the database called Products!
        public DbSet<Product> Products { get; set; }
    }

}