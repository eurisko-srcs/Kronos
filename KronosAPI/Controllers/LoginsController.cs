using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using KronosAPI.Data;
using KronosAPI.Models;
using System.Data.SqlClient;
using DevExpress.Data.ODataLinq.Helpers;

namespace KronosAPI.Controllers
{
    [Route("api/login")]
    [ApiController]
    public class LoginsController : ControllerBase
    {
        private readonly LoginContext _context;

        public LoginsController(LoginContext context)
        {
            _context = context;
        }

        // GET: api/Logins
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Login>>> GetLogin()
        {
            return await _context.Login.ToListAsync();

            //return _context.Login.Where(x => x.idUsuario == idUsuario).ToList(); // FromSqlRaw("Select * from login where idUsuario = 1").ToList();
        }

        // GET: api/Logins/logtype/5
        [HttpGet("{tipoLog}", Name = "GetTypeLogLogin")]
        [Route("logtype/{tipoLog}")]
        public async Task<ActionResult<IEnumerable<Login>>> GetLogTypeLogin(int tipoLog)
        {
            return await _context.Login.Where(x => x.tipoLog == tipoLog).ToListAsync();
        }

        // GET: api/Logins/user/5
        [HttpGet("{idUsuario}", Name = "GetUserLogin")]
        [Route("user/{idUsuario}")]
        public async Task<ActionResult<IEnumerable<Login>>> GetUserLogin( int idUsuario)
        {
            return await _context.Login.Where(x => x.idUsuario == idUsuario).ToListAsync();
        }

        // GET: api/Logins/id/5
        [HttpGet("{id}", Name = "GetLogin")]
        [Route("id/{id}")]
        public async Task<ActionResult<Login>> GetLogin(int id)
        {
            var login = await _context.Login.FindAsync(id);
            //var login = await _context.Login.FirstOrDefaultAsync(p => p.idUsuario == id);
            if (login == null)
            {
                return NotFound();
            }

            return login;
        }

        // PUT: api/Logins/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLogin(int id, Login login)
        {
            if (id != login.idLog)
            {
                return BadRequest();
            }

            _context.Entry(login).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LoginExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Logins
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Login>> PostLogin(Login login)
        {
            _context.Login.Add(login);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetLogin), new { id = login.idLog }, login);
        }

        // DELETE: api/Logins/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Login>> DeleteLogin(int id)
        {
            var login = await _context.Login.FindAsync(id);
            if (login == null)
            {
                return NotFound();
            }

            _context.Login.Remove(login);
            await _context.SaveChangesAsync();

            return login;
        }

        private bool LoginExists(int id)
        {
            return _context.Login.Any(e => e.idLog == id);
        }
    }
}
