using Inventario.Entities.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventario.BL.Interfaces
{
    public interface IProductoService
    {
        public Task<List<ProductosDTO>> GetProductosAsync();
        public Task<ProductosDTO> GetProductoByIdAsync(int id);
        public Task<int> InsertProductoAsync(ProductosDTO productos);
        public Task<ProductosDTO> UpdateProductoAsync(ProductosDTO productos);
        public Task<bool> DeleteProductoAsync(int id);
    }
}
