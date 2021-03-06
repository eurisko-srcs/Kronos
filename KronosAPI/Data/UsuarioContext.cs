using Microsoft.EntityFrameworkCore;
using KronosAPI.Models;

namespace KronosAPI.Data
{
    public class UsuarioContext:DbContext
    {
        public UsuarioContext(DbContextOptions<UsuarioContext> options) : base(options)
        { 
            
        }

        public DbSet<Usuario> usuarios { get; set; }
    }
}
