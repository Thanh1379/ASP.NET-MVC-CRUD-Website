using Microsoft.EntityFrameworkCore;
using MyFirstProj.Models;

namespace MyFirstProj.Data
{
    public class ApplicationDbContext : DbContext   
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
        {
            
        }
        public DbSet<Category> Categories { get; set; }
    }
}
