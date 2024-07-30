using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MVCProducto.Models;

namespace MVCPelicula.Models.Seeds
{
    public class CategoriaSeed : IEntityTypeConfiguration<Categoria>
    {
        public void Configure(EntityTypeBuilder<Categoria> builder)
        {
            builder.HasData(
                new Categoria { Id = 1, Nombre = "Electronica" },
                new Categoria { Id = 2, Nombre = "Ropa" },
                new Categoria { Id = 3, Nombre = "Alimentos" }
            );
        }
    }
}
