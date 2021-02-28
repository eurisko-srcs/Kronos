using Microsoft.EntityFrameworkCore;
using KronosAPI.Models;

namespace KronosAPI.Context
{
    public class UsuarioContext:DbContext
    {
        public UsuarioContext(DbContextOptions<UsuarioContext> options) : base(options)
        { 
            
        }

        public DbSet<Usuario> usuarios { get; set; }
    }
}
