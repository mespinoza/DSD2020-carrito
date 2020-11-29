using Servicio_Mant.Dominio;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Servicio_Mant.Persistencia
{
    public class ofertaDAO
    {
        private string cadenaConexion = "Data Source=(local); Initial Catalog=Sales2;Integrated Security = SSPI";

        public Ofertac Sb_optener_oferta(string fecha)
        {
            Ofertac ofertaEncontrar = null;
            string sql = "select descripcion,stock ,precio,CAST(fecha_oferta  AS varchar(10)) AS fecha_oferta from ARTICULO where fecha_oferta= CAST(" + "'" + fecha + "'" + " AS DATE)";
            using (SqlConnection cnn = new SqlConnection(cadenaConexion))
            {
                cnn.Open();
                using (SqlCommand cmd = new SqlCommand(sql, cnn))
                {
                    cmd.Parameters.Add(new SqlParameter("@fecha", fecha));
                    using (SqlDataReader resul = cmd.ExecuteReader())
                    {
                        if (resul.Read())
                        {
                            ofertaEncontrar = new Ofertac
                            {
                                nombre = (string)resul["descripcion"],
                                cantidad = (int)resul["stock"],
                                precio = (decimal)resul["precio"],
                                fecha = (string)resul["fecha_oferta"]

                            };
                        }
                    }
                }
            }
            return ofertaEncontrar;
        }

    }
}