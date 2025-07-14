using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ServicioApi.Helpers;
using ServicioApi.Models;

namespace ServicioApi.Controllers
{
    public class UsuarioController : ControllerBase
    {
        private readonly EvaluacionContext _context;
        private readonly JwtTokenGenerator _tokenGenerator;

        public UsuarioController(EvaluacionContext context, JwtTokenGenerator tokenGenerator)
        {
            _context = context;
            _tokenGenerator = tokenGenerator;
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] Login request)
        {
            var usuario = await (from u in _context.Usuarios
                                 join p in _context.Perfils on u.IdPerfil equals p.IdPerfil
                                 where u.Codigo == request.Codigo && u.Clave == request.Clave
                                 select new UsuarioLogin
                                 {
                                     IdUser = u.IdUser,
                                     Codigo = u.Codigo,
                                     Clave = u.Clave,
                                     Estado = u.Estado,
                                     Correo = u.Correo,
                                     IdPerfil = u.IdPerfil,
                                     NombrePerfil = p.Nombre,
                                     Usuarios = p.Usuarios,
                                     Clientes = p.Clientes,
                                     Ventas = p.Ventas,
                                     Reportes = p.Reportes,
                                     Lista_Negra = p.ListaNegra,
                                 }).FirstOrDefaultAsync();

            if (usuario == null)
            {
                return NotFound();
            }

            var token = _tokenGenerator.GenerateToken(usuario);

            return Ok(new
            {
                Token = token,
                Usuario = usuario
            });
        }

        [Authorize]
        [HttpPost]
        [Route("crearUsuario")]
        public async Task<IActionResult> CrearUsuario([FromBody] Usuario Usuario)
        {
            await _context.Usuarios.AddAsync(Usuario);
            await _context.SaveChangesAsync();

            return Ok();
        }

        [Authorize]
        [HttpGet]
        [Route("listarUsuarios")]
        public async Task<ActionResult<IEnumerable<Usuario>>> GetUsuario()
        {
            var usuarios = await (
            from u in _context.Usuarios
            join p in _context.Perfils on u.IdPerfil equals p.IdPerfil
            select new UsuarioLogin
            {
                IdUser = u.IdUser,
                Codigo = u.Codigo,
                Clave = u.Clave,
                Estado = u.Estado,
                Correo = u.Correo,
                IdPerfil = u.IdPerfil,
                NombrePerfil = p.Nombre
            }).ToListAsync();

            return Ok(usuarios);
        }

        [Authorize]
        [HttpGet]
        [Route("verUsuario")]
        public async Task<IActionResult> GetUsuario(int id_Usuario)
        {
            //obtener el Usuario de la base de datos
            Usuario Usuario = await _context.Usuarios.FindAsync(id_Usuario);

            //devolver el Usuario
            if (Usuario == null)
            {
                return NotFound();
            }

            return Ok(Usuario);
        }

        [Authorize]
        [HttpPut]
        [Route("editarUsuario")]
        public async Task<IActionResult> UpdateUsuario(int id_Usuario, [FromBody] Usuario Usuario)
        {
            //Actualizar el Usuario en la base de datos
            var UsuarioExistente = await _context.Usuarios.FindAsync(id_Usuario);
            UsuarioExistente!.Codigo = Usuario.Codigo;
            UsuarioExistente.Clave = Usuario.Clave;

            await _context.SaveChangesAsync();

            //devolver un mensaje de exito
            return Ok();
        }


        [Authorize]
        [HttpDelete]
        [Route("eliminarUsuario")]
        public async Task<IActionResult> DeleteUsuario(int id_Usuario)
        {
            //Eliminar Usuario de la base de datos
            var UsuarioBorrado = await _context.Usuarios.FindAsync(id_Usuario);
            _context.Usuarios.Remove(UsuarioBorrado!);

            await _context.SaveChangesAsync();

            return Ok();
        }

        [Authorize]
        [HttpGet]
        [Route("listarPerfiles")]
        public async Task<ActionResult<IEnumerable<Perfil>>> GetPerfil()
        {
            var perfiles = await (
            from u in _context.Perfils
            join p in _context.Perfils on u.IdPerfil equals p.IdPerfil
            select new Perfil
            {
                IdPerfil = u.IdPerfil,
                Nombre = u.Nombre,
                Usuarios = u.Usuarios,
                Clientes = u.Clientes,
                Ventas = u.Ventas,
                Reportes = u.Reportes,
                ListaNegra = p.ListaNegra
            }).ToListAsync();

            return Ok(perfiles);
        }

    }
}
