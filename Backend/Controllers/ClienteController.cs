using Backend.Acceso_Datos;
using Backend.Modelo;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly AC_Clientes dao;
        public ClienteController(AC_Clientes _dao)
        {
            dao = _dao;
        }

        [HttpGet("BuscarClienteDNI/{dni}")]
        public List<Cliente_Model> BuscarClienteDNI(string dni)
        {
            var listado = dao.buscarDNI(dni);
            return listado;
        }


       

    }
}
