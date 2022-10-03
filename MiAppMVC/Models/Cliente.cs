using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MiAppMVC.Models
{
    public class Cliente
    {
        [Key]
        public int IdCliente { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name ="Nombre Cliente")]
        public string Nombre { get; set; }

        [MaxLength(100)]
        [Display(Name ="Razon Social Cliente")]
        public string RazonSocial { get; set; }

        [Required]
        [MaxLength(11)] // Dni= 12345678 , Cuit/cuil 12123456789
        public string Documento { get; set; }

        [Required]
        public bool Estado { get; set; }

    }
}
