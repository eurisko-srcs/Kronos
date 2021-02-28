using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace KronosAPI.Models
{
    // Model for usuario
    // property names must be the same as the table fields names
    // [DataContract] pour 
    public class Usuario
    {
        // The [Key] keyword indicates that tis property is the primary key
        [Key]
        // [DataMember(Name = "id")]
        public int id { get; set; }
        public string nombre { get; set; }
        public string apellidos { get; set; }
        public string NIF { get; set; }
        public string telefono { get; set; }
        public string mail { get; set; }
        public string direccion { get; set; }
        public string ciudad { get; set; }
        public string codigoPostal { get; set; }
        public string pais { get; set; }
        public DateTime fechaRegistro { get; set; }

    }
}
