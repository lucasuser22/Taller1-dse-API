using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventario.Entities.Models
{
    public class Productos
    {
        [Key]
        public int Id { get; set; }
        public required string Nombre { get; set; }
        public required Decimal Precio { get; set; }
        public required int Stock { get; set; }
    }
}
