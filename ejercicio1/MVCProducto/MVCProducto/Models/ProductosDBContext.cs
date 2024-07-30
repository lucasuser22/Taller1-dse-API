using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;
using MVCProducto.Models.Seeds;
using MVCPelicula.Models.Seeds;

namespace MVCProducto.Models
{
    public class ProductosDBContext : DbContext
    {
        public ProductosDBContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Producto> Producto { get; set; }
        public DbSet<Categoria> Categoria { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CategoriaSeed());
            modelBuilder.ApplyConfiguration(new ProductoSeed());

        }


    }
}
