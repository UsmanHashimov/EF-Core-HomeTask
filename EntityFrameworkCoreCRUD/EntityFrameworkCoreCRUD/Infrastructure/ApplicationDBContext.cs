using EntityFrameworkCoreCRUD.Models;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkCoreCRUD.Infrastructure
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }

        public DbSet<Gym> Gyms { get; set; }
    }
}
