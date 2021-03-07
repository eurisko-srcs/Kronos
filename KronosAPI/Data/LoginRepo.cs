using KronosAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net.Http;
using System.Net;

namespace KronosAPI.Data
{
    public class LoginRepo : ILoginRepo
    {
        private readonly LoginContext _context;

        public LoginRepo(LoginContext context)
        {
            _context = context;
        }

        public async Task<ActionResult<IEnumerable<Login>>> GetAllLogins()
        {
            return await _context.Login.ToListAsync();
        }

        public async Task<ActionResult<Login>> GetLoginById(int id)
        {
            /* var login = await _context.Login.FindAsync(id);

             if (login == null)
             {

             }
            return login;*/
            //return await _context.Login.FindAsync(id);

            return await _context.Login.FirstOrDefaultAsync(p => p.idUsuario == id);
        }



        public async Task<ActionResult<Login>> PostLogin(Login login)
        {
            _context.Login.Add(login);
            await _context.SaveChangesAsync();

            return login;
        }

        public async Task<ActionResult<Login>> PutLogin(int id, Login login)
        {

            Login log;

            log = await _context.Login.FindAsync(id);

            if (log != null)
            {
                _context.Entry(login).State = EntityState.Modified;

                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (LoginExists(id) == false)
                    {
                        return null;
                    }
                    else
                    {
                        throw;
                    }
                }
            }

            return log;
        }

        public async Task<ActionResult<Login>> DeleteLogin(int id)
        {
            var login = await _context.Login.FindAsync(id);
            if (login != null)
            {
                _context.Login.Remove(login);
                await _context.SaveChangesAsync();
            }

            return login;
        }

        public bool LoginExists(int id)
        {
            return ( _context.Login.Find(id) !=  null) ;
        }

        public HttpResponseMessage NotFound(HttpRequestMessage request, string message)
        {
            HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.NotFound)
            {
                Content = new StringContent(message), // Put the message in the response body (text/plain content).
                RequestMessage = request
            };
            return response;
        }

    }
}
