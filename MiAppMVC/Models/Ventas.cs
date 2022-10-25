using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MiAppMVC.Models
{
    public class Ventas
    {   [Key]
        public int idVenta { get; set; }

        [Required]
        public int idCliente { get; set; }
        [Required]
        public DateTime Fecha_venta { get; set; }
        [Required]
        public int CantProducto { get; set; }
        [Required]
        public int estado { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal TotalVenta { get; set; }



    }
}
