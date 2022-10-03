using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MiAppMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace MiAppMVC.Data
{
    public class ApplicationDbContext : DbContext //hereda de clase DbContext

    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) //por inyeccion de dependencia voy a conectar el DbContext con la cadena de Conexion
        {

        }

        public DbSet<Cliente> Cliente {get;set;} // esta propiedad es la que se va ainteractuar con la tabla Cliente de mi base de datos
        public DbSet<Productos> Producto { get; set; }
        
        
        // add-migration PrimeraMigracion
        // update-database


    }
}
