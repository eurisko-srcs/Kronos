using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KronosAPI.Models
{
    public class Login
    {
        public Login()
        {
            fecha = DateTime.Now;
        }
        [Key]
        public int idLog { get; set; }
        public int idUsuario { get; set; }
        public int tipoLog { get; set; }
        public DateTime fecha { get; set; }
        public string comentario { get; set; }
        public double latitude { get; set; }
        public double longitude { get; set; }
    }
}
