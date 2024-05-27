using Backend.Modelo;
using System.Data.SqlClient;

namespace Backend.Acceso_Datos
{
    public class AC_Clientes
    {

        private readonly string cadena;
        public AC_Clientes(IConfiguration config)
        {
            cadena = config.GetConnectionString("JoseChatata");
        }

        public List<Cliente_Model> buscarDNI(string dni)
        {
            List<Cliente_Model> lista = new List<Cliente_Model>();
            try
            {
                using (SqlConnection oconexion = new SqlConnection(cadena))
                {
                    string sql = "select nombre,apellido,correo,celular from Cliente where dn=@dni";
                    
                    SqlCommand cmd = new SqlCommand(sql, oconexion);
                    cmd.Parameters.AddWithValue("@dni", dni);
                    oconexion.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new Cliente_Model
                            {
                                nombre = dr["nombre"].ToString(),
                                apellido = dr["apellido"].ToString(),
                                correo = dr["correo"].ToString(),
                                celular = dr["celular"].ToString(),

                            });
                        }
                    }
                }
            }
            catch
            {

                lista = new List<Cliente_Model>();
            }
            return lista;
        }


    }
}
