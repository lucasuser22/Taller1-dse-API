using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventario.Entities.DTO
{
    public class ProductosDTO
    {
        public int Codigo { get; set; }

        [Required(ErrorMessage = "El nombre del producto es requerido")]
        [StringLength(50, ErrorMessage = "El nombre no puede tener mas de 50 caracteres.")]
        public string NombreProducto { get; set; } = string.Empty;

        [Required(ErrorMessage = "El precio es requerido")]
        public decimal PrecioProducto { get; set; }

        [Required(ErrorMessage = "Se debe establecer el stock del producto")]
        public int StockProducto { get; set; }
    }
}
