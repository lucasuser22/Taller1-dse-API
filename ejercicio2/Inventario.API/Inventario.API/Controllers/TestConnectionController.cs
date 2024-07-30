using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace Inventario.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestConnectionController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public TestConnectionController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        public IActionResult TestConnection()
        {
            string connectionString = _configuration.GetConnectionString("ConnectionString");

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    if (connection.State == System.Data.ConnectionState.Open)
                    {
                        return Ok("Conexión exitosa a la base de datos.");
                    }
                    else
                    {
                        return StatusCode(500, "No se pudo abrir la conexión a la base de datos.");
                    }
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al intentar conectar a la base de datos: {ex.Message}");
            }
        }
    }
}
