using Backend.Modelo;
using System.Data;
using System.Data.SqlClient;
namespace Backend.Acceso_Datos
{
    public class AC_Administrador
    {

        private readonly string cadena;
        public AC_Administrador(IConfiguration config)
        {
            cadena = config.GetConnectionString("JoseChatata");
        }

        public List<Administrador_Model> listar()
        {
            List<Administrador_Model> lista = new List<Administrador_Model>();
            try
            {
                using (SqlConnection oconexion = new SqlConnection(cadena))
                {
                    string sql = "select correo,clave from Administrador";
                    SqlCommand cmd = new SqlCommand(sql, oconexion);
                    oconexion.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new Administrador_Model
                            {
                                correo = dr["correo"].ToString(),
                                clave = dr["clave"].ToString(),
                               
                            });
                        }
                    }
                }
            }
            catch
            {

                lista = new List<Administrador_Model>();
            }
            return lista;
        }

    }
}
