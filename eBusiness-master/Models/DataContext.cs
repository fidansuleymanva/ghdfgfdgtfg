using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace eBusiness.Models
{
    public class DataContext :IdentityDbContext
    {
        public DataContext(DbContextOptions<DataContext> options):base(options) { }
       public DbSet<Team> Teams { get; set; }
        public DbSet<AppUser> AppUsers { get; set; }
    }
}
