using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MiAppMVC.Models
{
    public class Productos
    {
        [Key]
        public int IdProductos { get; set; }
        
        [Required] // not null
        [MaxLength(50)]
        public string Nombre { get; set; }

        [Required]
        public decimal Precio { get; set; }
        [Required]
        public int IdCategoria { get; set; }   // 1-Televisores, 2-Informatica, 3-Hogar, 4-Indumentaria
        public DateTime FechaAlta { get; set; }
        public DateTime FechaBaja { get; set; }
        public bool Estado { get; set; }
    }
}
