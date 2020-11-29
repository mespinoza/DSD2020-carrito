using Servicio_Mant.Dominio;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Servicio_Mant.Persistencia
{
    public class usuarioDAO
    {
        private string cadenaConexion = "Data Source=(local); Initial Catalog=Sales2;Integrated Security = SSPI";

        public Usuarioc Sb_usuario_obtener(string usua, string contra)
        {
            Usuarioc usuarioEncontrar = null;
            string sql = "select correo from usuario where correo=@usua AND clave=@contra AND estado=CAST(1 AS BIT)";
            using (SqlConnection cnn = new SqlConnection(cadenaConexion))
            {
                cnn.Open();
                using (SqlCommand cmd = new SqlCommand(sql, cnn))
                {
                    cmd.Parameters.Add(new SqlParameter("@usua", usua));
                    cmd.Parameters.Add(new SqlParameter("@contra", contra));
                    using (SqlDataReader resul = cmd.ExecuteReader())
                    {
                        if (resul.Read())
                        {
                            usuarioEncontrar = new Usuarioc
                            {
                                Cusuario = (string)resul["correo"],
                                // Ccontrasena = (string)resul["clave"]
                            };
                        }
                    }
                }
            }
            return usuarioEncontrar;
        }
    }
}