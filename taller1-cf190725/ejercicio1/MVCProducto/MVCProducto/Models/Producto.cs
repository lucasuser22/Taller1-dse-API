using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MVCProducto.Models
{
    public class Producto
    {
        public int ID { get; set; }

        [StringLength(50, MinimumLength = 4)]
        [Required(ErrorMessage = "El campo titulo es requerido")]
        [Display(Name = "Nombre de Producto")]
        public string NombreProducto { get; set; }

        [Range(1, 10000)]
        [Display(Name = "Precio del producto")]
        [Required(ErrorMessage = "El campo es requerido")]
        public decimal Precio { get; set; }

        [Range(1, 10000)]
        [Display(Name = "Stock del producto")]
        [Required(ErrorMessage = "El campo es requerido")]
        public int Stock { get; set; }

        // Propiedad para llave foránea
        [Required]
        [ForeignKey("Categoria")]
        [Display(Name = "Categoria")]
        public int CodigoCategoria { get; set; }

        // Propiedad de navegación
        public Categoria Categoria { get; set; }
    }
}


