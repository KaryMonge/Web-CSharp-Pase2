using Cliente_API.Models;
using Microsoft.EntityFrameworkCore;

namespace Cliente_API.Data
{
    public class Proyecto3_DbContext : DbContext
    {
        //aquí se crean las tablas para cada clase. 
       public DbSet<Cliente> Clientes { get; set; } //tabla cliente

        public DbSet<Producto> Productos { get; set; }

        public DbSet<Proveedor> Provedores { get; set; }

        public DbSet<Tour> Tours{ get; set; }

        public DbSet<Factura> Facturas { get; set; }

        public Proyecto3_DbContext(DbContextOptions<Proyecto3_DbContext> options) :base(options)// el profe dijo eso se pone así
        {


        }

    }
}
