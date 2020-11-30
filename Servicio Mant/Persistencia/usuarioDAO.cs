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
        private string cadenaConexion = "Data Source=(local); Initial Catalog=Sales;Integrated Security = SSPI";

        public Usuarioc Sb_usuario_obtener(string usua, string contra)
        {
            Usuarioc usuarioEncontrar = null;
            string sql = "select u.id_usuario,u.correo,r.descripcion from usuario u inner join ROL r on u.id_rol=r.id_rol " +
                    " where u.correo = @usua AND u.clave =@contra AND u.estado = CAST(1 AS BIT)";
            using (SqlConnection cnn = new SqlConnection(cadenaConexion))
            {
                cnn.Open();
                using (SqlCommand cmd = new SqlCommand(sql, cnn))
                {
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.Parameters.Add(new SqlParameter("@usua", usua));
                    cmd.Parameters.Add(new SqlParameter("@contra", contra));
                    using (SqlDataReader resul = cmd.ExecuteReader())
                    {
                        if (resul.Read())
                        {
                            usuarioEncontrar = new Usuarioc
                            {
                                idusuario = (int)resul["id_usuario"],
                                Cusuario = (string)resul["correo"],
                                descripcion = (string)resul["descripcion"],
                            };
                        }
                    }
                }
            }
            return usuarioEncontrar;
        }
    }
}