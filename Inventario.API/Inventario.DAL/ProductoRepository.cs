using Dapper;
using Inventario.DAL.Interfaces;
using Inventario.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventario.DAL
{
    public class ProductoRepository : IProductoRepository
    {
        private readonly IDatabaseRepository databaseRepository;
        public ProductoRepository(IDatabaseRepository databaseRepository)
        {
            this.databaseRepository = databaseRepository;
        }
        public async Task<List<Productos>> GetProductosAsync()
        {
            string query = "SELECT * FROM Productos";
            return await databaseRepository.GetDataByQueryAsync<Productos>(query);
        }
        public async Task<Productos> GetProductoByIdAsync(int id)
        {
            string query = "SELECT * FROM Productos WHERE Id = @Id";
            var parameters = new DynamicParameters();
            parameters.Add("@Id", id);
            return (await databaseRepository.GetDataByQueryAsync<Productos>(query, parameters)).FirstOrDefault();
        }
        public async Task<int> InsertProductoAsync(Productos productos)
        {
            string query = "INSERT INTO Productos (Nombre, Precio, Stock) VALUES (@Nombre, @Precio, @Stock); SELECT SCOPE_IDENTITY()";
            var parameters = new DynamicParameters(); 
            parameters.Add("@Nombre", productos.Nombre);
            parameters.Add("@Precio", productos.Precio);
            parameters.Add("@Stock", productos.Stock);
            return await databaseRepository.InsertAsync(query, parameters);
        }
        public async Task<Productos> UpdateProductoAsync(Productos productos)
        {
            string query = "UPDATE Productos SET Nombre = @Nombre, Precio = @Precio, Stock = @Stock WHERE Id = @Id";
            var parameters = new DynamicParameters();
            parameters.Add("@Id", productos.Id);
            parameters.Add("@Nombre", productos.Nombre);
            parameters.Add("@Precio", productos.Precio);
            parameters.Add("@Stock", productos.Stock);
            await databaseRepository.UpdateAsync<Productos>(query, parameters);
            return productos;
        }
        public async Task<bool> DeleteProductoAsync(int id)
        {
            string query = "DELETE FROM Productos WHERE Id = @Id";
            var parameters = new DynamicParameters();
            parameters.Add("@Id", id);
            return await databaseRepository.DeleteAsync(query, parameters);
        }
    }
}
