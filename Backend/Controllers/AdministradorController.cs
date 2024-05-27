using Backend.Acceso_Datos;
using Backend.Modelo;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class AdministradorController : ControllerBase
    {

        private readonly AC_Administrador _administrador;
        public AdministradorController(AC_Administrador aadministrador)
        {
            _administrador = aadministrador;
        }


        [HttpPost("login")]
        public IActionResult Login([FromBody] Administrador_Model login)
        {
            var admin = _administrador.listar().FirstOrDefault(a => a.correo == login.correo && a.clave == login.clave);
            if (admin == null)
            {
                return Unauthorized("Correo o contraseña no válidos");

            }
           
                return Ok(new { message = "Inicio de sesión exitoso" });

        }


    }
}
