using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Inventario.Entities.Models;

namespace Inventario.DAL.Interfaces
{
    public interface IProductoRepository
    {
        public Task<List<Productos>> GetProductosAsync();
        public Task<Productos> GetProductoByIdAsync(int id);
        public Task<int> InsertProductoAsync(Productos productos);
        public Task<Productos> UpdateProductoAsync(Productos productos);
        public Task<bool> DeleteProductoAsync(int id);
    }
}
