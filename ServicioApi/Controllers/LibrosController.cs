using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ServicioApi.Models;

namespace ServicioApi.Controllers
{
    public class LibrosController : ControllerBase
    {
        private readonly EvaluacionContext _context;

        public LibrosController(EvaluacionContext context)
        {
            _context = context;
        }

        [HttpPost]
        [Route("crearLibro")]
        public async Task<IActionResult> CrearLibro([FromBody] Libro Libro)
        {
            await _context.Libros.AddAsync(Libro);
            await _context.SaveChangesAsync();

            return Ok("Libro Guardado Exitosamente!");
        }

        [HttpGet]
        [Route("listaLibro")]
        public async Task<ActionResult<IEnumerable<Libro>>> GetLibro()
        {
            var Libros = await _context.Libros.ToListAsync();

            return Ok(Libros);
        }

        [HttpGet]
        [Route("verLibro")]
        public async Task<IActionResult> GetLibro(int id_libro)
        {
            //obtener el Libro de la base de datos
            Libro Libro = await _context.Libros.FindAsync(id_libro);

            //devolver el Libro
            if (Libro == null)
            {
                return NotFound();
            }

            return Ok(Libro);
        }

        [HttpPut]
        [Route("editarLibro")]
        public async Task<IActionResult> UpdateLibro( int id_libro, [FromBody] Libro Libro)
        {
            //Actualizar el Libro en la base de datos
            var LibroExistente = await _context.Libros.FindAsync(id_libro);
            LibroExistente!.Nombre = Libro.Nombre;
            LibroExistente.Genero = Libro.Genero;
            LibroExistente.PrecioAlquiler = Libro.PrecioAlquiler;
            LibroExistente.PrecioVenta = Libro.PrecioVenta;

            await _context.SaveChangesAsync();

            //devolver un mensaje de exito
            return Ok("Editado Correctamente");
        }

        [HttpPost]
        [Route("AgregarItems")]
        public async Task<IActionResult> AddLibros([FromBody] EjemplarAdd ejemplar)
        {
            var LibroExistente = await _context.Libros.FindAsync(ejemplar.IdLibro);

            if (LibroExistente == null)
            {
                return NotFound("Libro no encontrado");
            }

            LibroExistente.Cantidad = LibroExistente.Cantidad + 1;

            await _context.SaveChangesAsync();

            var ejemplarNuevo = new Ejemplare
            {
                Codigo = ejemplar.Codigo,
                Estado = 1,
                TipoProd = 1,
                IdItem = ejemplar.IdLibro,
                IdEstante = ejemplar.IdEstante
            };

            _context.Ejemplares.Add(ejemplarNuevo);

            await _context.SaveChangesAsync();

            return Ok("Registrado con Exito");
        }

        [HttpGet]
        [Route("GetEstantes")]
        public async Task<IActionResult> GetEstantes()
        {
            var Estantes = await _context.Estantes.ToListAsync();

            return Ok(Estantes);
        }

        [HttpDelete]
        [Route("eliminarLibro")]
        public async Task<IActionResult> DeleteLibro(int id_libro)
        {
            //Eliminar Libro de la base de datos
            var LibroBorrado = await _context.Libros.FindAsync(id_libro);
            if (LibroBorrado == null)
            {
                return NotFound($"No se encontró el libro con id {id_libro}");
            }

            var id_item = id_libro;
            var tipo_prod = 1;

            var EjemplaresBorrado = await  _context.Ejemplares.Where(c => c.IdItem == id_item && c.TipoProd == tipo_prod).ToListAsync();

            if (EjemplaresBorrado.Any(e => e.Estado != 1))
            {
                return BadRequest("No se puede eliminar el libro porque tiene ejemplares en uso.");
            }

            if (EjemplaresBorrado.Any())
            {
                _context.Ejemplares.RemoveRange(EjemplaresBorrado);
                await _context.SaveChangesAsync();
            }

            _context.Libros.Remove(LibroBorrado);
            await _context.SaveChangesAsync();

            return Ok("Libro Eliminado y sus Ejemplares");
        }

        [HttpPost]
        [Route("registrarPrestamo")]
        public async Task<IActionResult> RegistrarPrestamo([FromBody] TransactEnvio request)
        {
            var LibroExistente1 = await _context.Libros.FirstOrDefaultAsync(l => l.IdLibro == request.libro1);

            if (LibroExistente1 == null)
            {
                return NotFound("Libro no encontrado");
            }

            var cantidad1 = LibroExistente1!.Cantidad;

            if(cantidad1 < 1)
            {
                return BadRequest("No hay ejemplares disponibles para préstamo.");
            }

            LibroExistente1!.Cantidad = cantidad1 - 1;

            await _context.SaveChangesAsync();

            var transaccion = new Transaccion
            {
                FechaEntrega = DateOnly.FromDateTime(DateTime.Now),
                FechaRetorno = DateOnly.FromDateTime(DateTime.Now.AddDays(3)),
                IdCliente = request.id_cliente,
                IdEstado = 1,
                IdTipotran = request.tipo_transact,
                Direccion = "local",
            };

            _context.Transaccions.Add(transaccion);

            await _context.SaveChangesAsync();

            var Ejemplar1 =  await _context.Ejemplares
                            .Where(u => u.TipoProd == 1 && u.IdItem == request.libro1 && u.Estado == 1)
                            .FirstOrDefaultAsync();

            if(Ejemplar1 == null)
            {
                return BadRequest("No hay ejemplares disponibles para préstamo.");
            }

            Ejemplar1.Estado = 2;
            await _context.SaveChangesAsync();

            var detalle1 = new DetalleTransaccion
            {
                IdEjemplar = Ejemplar1.IdEjemplar,
                IdTransact = transaccion.IdTransact
            };

            _context.DetalleTransaccions.Add(detalle1);
            await _context.SaveChangesAsync();

            if (request.libro2.HasValue && request.libro2 != 0)
            {
                var LibroExistente2 = await _context.Libros.FirstOrDefaultAsync(l => l.IdLibro == request.libro2);

                if (LibroExistente2 == null)
                {
                    return NotFound("Libro no encontrado");
                }

                var cantidad2 = LibroExistente2!.Cantidad;

                if (cantidad1 < 1)
                {
                    return BadRequest("No hay ejemplares disponibles para préstamo.");
                }

                LibroExistente2!.Cantidad = cantidad2 - 1;

                await _context.SaveChangesAsync();

                var Ejemplar2 = await _context.Ejemplares
                            .Where(u => u.TipoProd == 1 && u.IdItem == request.libro2 && u.Estado == 1)
                            .FirstOrDefaultAsync();

                if (Ejemplar2 == null)
                {
                    return BadRequest("No hay ejemplares disponibles para préstamo.");
                }

                Ejemplar1.Estado = 2;
                await _context.SaveChangesAsync();

                var detalle2 = new DetalleTransaccion
                {
                    IdEjemplar = Ejemplar1.IdEjemplar,
                    IdTransact = transaccion.IdTransact
                };

                _context.DetalleTransaccions.Add(detalle2);
                await _context.SaveChangesAsync();
            }            

            if(request.libro3.HasValue && request.libro3 != 0)
            {
                var LibroExistente3 = await _context.Libros.FirstOrDefaultAsync(l => l.IdLibro == request.libro3);

                if (LibroExistente3 == null)
                {
                    return NotFound("Libro no encontrado");
                }

                var cantidad3 = LibroExistente3!.Cantidad;

                if (cantidad3 < 1)
                {
                    return BadRequest("No hay ejemplares disponibles para préstamo.");
                }

                LibroExistente3!.Cantidad = cantidad3 - 1;

                await _context.SaveChangesAsync();

                var Ejemplar3 = await _context.Ejemplares
                            .Where(u => u.TipoProd == 1 && u.IdItem == request.libro3 && u.Estado == 1)
                            .FirstOrDefaultAsync();

                if (Ejemplar3 == null)
                {
                    return BadRequest("No hay ejemplares disponibles para préstamo.");
                }

                Ejemplar3.Estado = 2;
                await _context.SaveChangesAsync();

                var detalle3 = new DetalleTransaccion
                {
                    IdEjemplar = Ejemplar3.IdEjemplar,
                    IdTransact = transaccion.IdTransact
                };

                _context.DetalleTransaccions.Add(detalle3);
                await _context.SaveChangesAsync();
            }
            
            return Ok("Prestamo Registrado con Exito!");
        }

        [HttpPost]
        [Route("registrarDevolucion")]
        public async Task<IActionResult> ReturnEjemplar(string Codigo)
        {
            var EjemplarRetorno = await _context.Ejemplares.FirstOrDefaultAsync(e => e.Codigo == Codigo);

            if(EjemplarRetorno == null)
            {
                return BadRequest("Codigo Invalido");
            }

            EjemplarRetorno.Estado = 1;
            await _context.SaveChangesAsync();

            var IdLibro = EjemplarRetorno.IdItem;
            var LibroConsult = await _context.Libros.FirstOrDefaultAsync(e => e.IdLibro == IdLibro);
            if(LibroConsult == null)
            {
                return BadRequest("Libro No Existe");
            }

            LibroConsult.Cantidad = LibroConsult.Cantidad + 1;
            await _context.SaveChangesAsync();

            return Ok("Ejemplar Retornado");
        }

        [HttpPost]
        [Route("perdidaEjemplarCliente")]
        public async Task<IActionResult> DeleteEjemplar(int id_libro, int cantidad ,int id_ejemplar, int id_cliente, int tipo_transact)
        {
            var LibroExistente = await _context.Libros.FindAsync(id_libro);
            LibroExistente!.Cantidad = cantidad - 1;

            await _context.SaveChangesAsync();

            var transaccion = new Transaccion
            {
                FechaEntrega = DateOnly.FromDateTime(DateTime.Now),
                IdCliente = id_cliente,
                IdEstado = 2,
                IdTipotran = tipo_transact,
                Direccion = "local",
            };

            _context.Transaccions.Add(transaccion);

            await _context.SaveChangesAsync();

            var detalle = new DetalleTransaccion
            {
                IdEjemplar = id_ejemplar,
                IdTransact = transaccion.IdTransact
            };

            _context.DetalleTransaccions.Add(detalle);
            await _context.SaveChangesAsync();

            //Devolver un mensaje de exito
            return Ok(new { mensaje = "Transacción y detalle registrados correctamente", id_transaccion = transaccion.IdTransact });
        }
    }
}
