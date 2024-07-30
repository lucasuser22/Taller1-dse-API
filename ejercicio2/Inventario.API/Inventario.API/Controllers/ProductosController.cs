using Microsoft.AspNetCore.Mvc;
using Inventario.BL.Interfaces;
using Inventario.Entities.DTO;
using System.Net;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Inventario.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductosController : ControllerBase
    {
        private readonly IProductoService service;
        ///<sumary>
        ///Constructor
        ///</sumary>
        ///<param name="service"></param>
        public ProductosController(IProductoService service)
        {
            this.service = service;
        }

        //GET: api/Productos
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<ProductosDTO>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public async Task<IActionResult> GetAll()
        {
            IEnumerable<ProductosDTO> result = (IEnumerable<ProductosDTO>)await this.service.GetProductosAsync();
            return (result != null && result.Any()) ? (IActionResult)this.Ok(result) : (IActionResult)this.NoContent();
        }

        //GET api/Productos/5
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ProductosDTO), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public async Task<IActionResult> Get(int id)
        {
            ProductosDTO obj = (ProductosDTO)await this.service.GetProductoByIdAsync(id);
            return (obj != null) ? (IActionResult)this.Ok(obj) : (IActionResult)this.NoContent();
        }

        //POST api/Productos
        [HttpPost]
        [ProducesResponseType(typeof(int), (int)HttpStatusCode.Created)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Post(ProductosDTO model)
        {
            if (model == null)
            {
                return (IActionResult)this.BadRequest();
            }
            int result = await this.service.InsertProductoAsync(model);
            return (result > 0) ? (IActionResult)this.CreatedAtAction("Post", result) : (IActionResult)this.BadRequest();
        }

        //PUT api/Productos/5
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(ProductosDTO), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Put(int id, ProductosDTO model)
        {
            if (model == null)
            {
                return (IActionResult)this.BadRequest();
            }
            ProductosDTO result = await this.service.UpdateProductoAsync(model);
            return (result != null) ? (IActionResult)this.Ok(result) : (IActionResult)this.BadRequest();
        }

        //DELETE api/Productos/5
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Delete(int id)
        {
            bool result = await this.service.DeleteProductoAsync(id);
            return (result) ? (IActionResult)this.Ok(result) : (IActionResult)this.BadRequest();
        }
    }
}
