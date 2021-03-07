using Microsoft.EntityFrameworkCore;
using KronosAPI.Models;

namespace KronosAPI.Data
{
    public class LoginContext : DbContext
    {
        public LoginContext (DbContextOptions<LoginContext> options)
            : base(options)
        {
            
        }

        public DbSet<Login> Login { get; set; }
    }
}
