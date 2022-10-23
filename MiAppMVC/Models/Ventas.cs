using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MiAppMVC.Models
{
    public class Ventas
    {
        [Key]
        public int idVenta { get; set; }

        [Required]
        public int idCliente { get; set; }
        [Required]
        public DateTime Fecha_venta { get; set; }
        [Required]
        public int CantProducto { get; set; }
        [Required]
        public int estado { get; set; }

        public decimal TotalVenta { get; set; }
    }
}
