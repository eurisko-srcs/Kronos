using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KronosAPI.Models
{
    public class LoginDTO
    {
        public int idUsuario { get; set; }
        public int tipoLog { get; set; }
        public string comentario { get; set; }
        public double latitude { get; set; }
        public double longitude { get; set; }
    }
}
