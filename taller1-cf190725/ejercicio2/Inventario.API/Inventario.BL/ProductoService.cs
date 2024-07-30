using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Inventario.BL.Interfaces;
using Inventario.DAL.Interfaces;
using Inventario.Entities.DTO;
using Inventario.Entities.Models;

namespace Inventario.BL
{
    public class ProductoService : IProductoService
    {
        private readonly IProductoRepository repository;
        private readonly IMapper mapper;
        public ProductoService(IProductoRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }
        public async Task<List<ProductosDTO>> GetProductosAsync()
        {
            try
            {
                var result = await repository.GetProductosAsync();
                return mapper.Map<List<Productos>, List<ProductosDTO>>(result);
            }
            catch (Exception)
            {
                return new List<ProductosDTO>();
            }
        }
        public async Task<ProductosDTO> GetProductoByIdAsync(int id)
        {
            try
            {
                var result = await repository.GetProductoByIdAsync(id);
                return mapper.Map<Productos, ProductosDTO>(result);
            }
            catch (Exception)
            {
                return null;
            }
        }
        public async Task<int> InsertProductoAsync(ProductosDTO model)
        {
            try
            {
                var entity = mapper.Map<ProductosDTO, Productos>(model);
                return await repository.InsertProductoAsync(entity);
            }
            catch (Exception)
            {
                return -1;
            }
        }
        public async Task<ProductosDTO> UpdateProductoAsync(ProductosDTO model)
        {
            try
            {
                var entity = mapper.Map<ProductosDTO, Productos>(model);
                var result = await repository.UpdateProductoAsync(entity);
                return mapper.Map<Productos, ProductosDTO>(result);
            }
            catch (Exception)
            {
                return null;
            }
        }
        public async Task<bool> DeleteProductoAsync(int id)
        {
            try
            {
                return await repository.DeleteProductoAsync(id);
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
