using KronosAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KronosAPI.Data
{
    public interface ILoginRepo 
    {
        public Task<ActionResult<IEnumerable<Login>>> GetAllLogins();
        public Task<ActionResult<Login>> GetLoginById(int id);
        public Task<ActionResult<Login>> PostLogin(Login login);
        public Task<ActionResult<Login>> PutLogin(int id, Login login);
        public Task<ActionResult<Login>> DeleteLogin(int id);
        public bool LoginExists(int id);
    }
}
