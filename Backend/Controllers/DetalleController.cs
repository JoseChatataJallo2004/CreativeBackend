using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using System.Data;
using System.Xml.Linq;
using Backend.Modelo;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DetalleController : ControllerBase
    {

        private readonly string cadena;
        public DetalleController(IConfiguration config)
        {
            cadena = config.GetConnectionString("JoseChatata");
        }


        [HttpPost]
        public IActionResult GuardarVenta([FromBody] Venta_Model body)
        {
            try
            {
                // Crear un elemento XML para representar la venta
                XElement venta = new XElement("Venta",
                    new XElement("numerodocumento", body.numerodocumento),
                    new XElement("Total", body.Total)
                );

                // Crear un elemento XML para representar los detalles de la venta
                XElement odetalleventa = new XElement("Detalle_Venta");
                foreach (Detalle_Venta_Model item in body.LSTDetalleventa)
                {
                    odetalleventa.Add(new XElement("Item",
                        new XElement("producto", item.producto),
                        new XElement("precio", item.precio),
                        new XElement("cantidad", item.cantidad),
                        new XElement("Total", item.Total)
                    ));
                }

                // Agregar los detalles de la venta al elemento de venta
                venta.Add(odetalleventa);

                // Guardar la venta en la base de datos utilizando un procedimiento almacenado
                using (SqlConnection conexion = new SqlConnection(cadena))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_guardar_venta", conexion);
                    cmd.Parameters.Add("@venta_xml", SqlDbType.Xml).Value = venta.ToString();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }

            

                // Retornar una respuesta exitosa
                return Ok(new { respuesta = true });
            }
            catch (Exception ex)
            {
                // Retornar un error en caso de que ocurra una excepción
                return StatusCode(500, new { error = ex.Message });
            }
        }


        }
}
