using EcouzVilla_API.Models;
using Microsoft.EntityFrameworkCore;

namespace EcouzVilla_API.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {
            
        }
        public DbSet<Villa> Villas { get; set; }

    }
}
