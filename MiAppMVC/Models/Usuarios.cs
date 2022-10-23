using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MiAppMVC.Models
{
    public class Usuarios
    {
        [Key]
        public int idUsuario { get; set; }
        [Required]
        public string usuario { get; set; }
        [Required]
        public string pass { get; set; }
        [Required]
        public bool estado { get; set; }
        [Required]
        public DateTime fechaAlta { get; set; }
    }
}
