using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiAppMVC.CarritoDTO
{
    public class ProductoDTO //DTO: DATA TRANSFER OBJECT
    {
        public string nombre { get; set; }
        public string categoria { get; set; }
        public decimal importe { get; set; }
        public string imagen { get; set; }
    }
}
