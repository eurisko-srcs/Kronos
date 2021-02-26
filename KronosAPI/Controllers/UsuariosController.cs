using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using KronosAPI.Models;
using KronosAPI.Context;

namespace KronosAPI.Controllers
{
    // Cet attribut indique la route pour accéder au controleur 
    // Exemple avec un explorateur https://localhost:44372/api/usuarios
    [Route("api/usuarios")]
    // L' attribut [ApiController] indique que le contrôleur répond aux requêtes de l’API web
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly UsuarioContext _context;

        public UsuariosController(UsuarioContext context)
        {
            _context = context;
        }

        // GET: api/Usuarios
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Usuario>>> Getusuarios()
        {
            return await _context.usuarios
                .ToListAsync();
        }

        // GET: api/Usuarios/5
        [HttpGet("{id}", Name = "GetUsuario" )]
        public async Task<ActionResult<Usuario>> GetUsuario(int id)
        {
            var usuario = await _context.usuarios.FindAsync(id);

            if (usuario == null)
            {
                return NotFound();
            }

            return usuario;
        }

        // PUT: api/Usuarios/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUsuario(int id, Usuario usuario)
        {
            if (id != usuario.id)
            {
                return BadRequest();
            }

           /* // On cherche l'enregistrement qui correspond à l'id;
            var usuario = await _context.usuarios.FindAsync(id);
            if (usuario == null)
            {
                return NotFound();
            }

            usuario.Name = usuarioDTO.Name;
            usuario.IsComplete = usuarioDTO.IsComplete;
           */
            _context.Entry(usuario).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException) when (!UsuarioExists(id))
            {

                    return NotFound();
            }

            return NoContent();
        }

        // POST: api/Usuarios
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Usuario>> CreateUsuario(Usuario usuario)
        {
           /* Usuario usuario = new Usuario
            {
                IsComplete = usuarioDTO.IsComplete,
                Name = usuarioDTO.Name
            };*/

            _context.usuarios.Add(usuario);
            await _context.SaveChangesAsync();

            //return CreatedAtAction("GetUsuario", new { id = usuario.idUsuario }, usuario);
            return CreatedAtAction(nameof(GetUsuario), new { id = usuario.id }, UsuarioToDTO(usuario));
        }

        // DELETE: api/Usuarios/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Usuario>> DeleteUsuario(int id)
        {
            var usuario = await _context.usuarios.FindAsync(id);
            if (usuario == null)
            {
                return NotFound();
            }

            _context.usuarios.Remove(usuario);
            await _context.SaveChangesAsync();

            return usuario;
        }

        private bool UsuarioExists(int id)
        {
            return _context.usuarios.Any(e => e.id == id);
        }
        // Cette méthode peut être simplifiée sur une seule ligne de la façon suivante
        //    private bool TodoItemExists(long id) =>  _context.TodoItems.Any(e => e.Id == id);


        private static UsuarioDTO UsuarioToDTO(Usuario usuario)
        {
            return new UsuarioDTO
            {
                id = usuario.id,
                nombre = usuario.nombre,

            }; 
        }
    }
}
