using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ServicioApi.Models;

namespace ServicioApi.Controllers
{
    public class ClienteController : ControllerBase
    {
        private readonly EvaluacionContext _context;

        public ClienteController(EvaluacionContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("listarClientes")]
        public async Task<ActionResult<IEnumerable<Cliente>>> GetClientes()
        {
            var Clientes = await _context.Clientes.ToListAsync();

            return Ok(Clientes);
        }
    }
}
