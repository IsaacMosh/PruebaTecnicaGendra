using Microsoft.AspNetCore.Mvc;
using NetCoreGendra.Services;

namespace NetCoreGendra.Controllers
{
    [ApiController]
    [Route("cliente")]
    public class ClienteController : ControllerBase
    {

        private readonly IServicio_Cliente _servicioCliente;

        [HttpGet]
        [Route("Consultar")]
        public dynamic consultarClientes()
        {
            return null;
        }
    }
}
