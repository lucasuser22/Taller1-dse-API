using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace MVCProducto.Models.Seeds
{
    public class ProductoSeed : IEntityTypeConfiguration<Producto>
    {
        public void Configure(EntityTypeBuilder<Producto> builder)
        {
            builder.HasData(
                new Producto
                {
                    ID = 1,
                    NombreProducto = "Smartphone",
                    Precio = Decimal.Parse("299.99"),
                    Stock = 50,
                    CodigoCategoria = 1
                },
                new Producto
                {
                    ID = 2,
                    NombreProducto = "Camisa",
                    Precio = Decimal.Parse("19.99"),
                    Stock = 200,
                    CodigoCategoria = 2
                },
                new Producto
                {
                    ID = 3,
                    NombreProducto = "Pan",
                    Precio = Decimal.Parse("1.99"),
                    Stock = 100,
                    CodigoCategoria = 3
                },
                new Producto
                {
                    ID = 5,
                    NombreProducto = "Laptop",
                    Precio = Decimal.Parse("799.99"),
                    Stock = 30,
                    CodigoCategoria = 1
                },
                new Producto
                {
                    ID = 6,
                    NombreProducto = "Zapatos",
                    Precio = Decimal.Parse("49.99"),
                    Stock = 150,
                    CodigoCategoria = 2
                }
            );
        }
    }
}
