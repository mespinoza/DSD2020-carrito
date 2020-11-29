using Servicio_Mant.Dominio;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Servicio_Mant.Persistencia
{
    public class DespachoDAO
    {
        private string cadenaConexion = "Data Source=(local); Initial Catalog=Sales;Integrated Security = SSPI";

        public Despacho CrearDespacho(Despacho DespachoACrear)
        {
            Despacho DespachoCreado = null;
            string sql = "INSERT INTO Despacho VALUES ( @fecha, @id_compra, @id_tipo_estado, @estado)";
            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                conexion.Open();
                using (SqlCommand comando = new SqlCommand(sql, conexion))
                {
                    comando.Parameters.Add(new SqlParameter("@fecha", DespachoACrear.fecha));
                    comando.Parameters.Add(new SqlParameter("@id_compra", DespachoACrear.id_compra));
                    comando.Parameters.Add(new SqlParameter("@id_tipo_estado", DespachoACrear.id_tipo_estado));
                    comando.Parameters.Add(new SqlParameter("@estado", DespachoACrear.estado));
                    comando.ExecuteNonQuery();
                }
            }       
            DespachoCreado = Obtener(DespachoACrear.id_compra);
            return DespachoCreado;
        }
        /*OBTENER DESPACHO */
        public Despacho Obtener(int id_compra)
        {

            Despacho DespachoEncontrado = null;
            string sql = "SELECT * FROM Despacho WHERE id_compra=@id_compra";
            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                conexion.Open();
                using (SqlCommand comando = new SqlCommand(sql, conexion))
                {
                    comando.Parameters.Add(new SqlParameter("@id_compra", id_compra));
                    using (SqlDataReader resultado = comando.ExecuteReader())
                    {
                        if (resultado.Read())
                        {
                            DespachoEncontrado = new Despacho()
                            {
                                fecha = (DateTime)resultado["fecha"],
                                id_compra = (int)resultado["id_compra"],
                                id_tipo_estado = (int)resultado["id_tipo_estado"],
                                estado = (Boolean)resultado["estado"]

                            };
                        }
                    }

                }

            }
            return DespachoEncontrado;
        }
        /* LISTRA DESPACHO */
        public List<Despacho> ListarDespacho()
        {
            List<Despacho> DespachosEncontrados = new List<Despacho>();
            Despacho DespachoEncontrado = null;
            string sql = "SELECT * from Despacho";

            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                conexion.Open();
                using (SqlCommand comando = new SqlCommand(sql, conexion))
                {

                    using (SqlDataReader resultado = comando.ExecuteReader())
                    {
                        while (resultado.Read())
                        {
                            DespachoEncontrado = new Despacho()
                            {
                                fecha = (DateTime)resultado["fecha"],
                                id_compra = (int)resultado["id_compra"],
                                id_tipo_estado = (int)resultado["id_tipo_estado"],
                                estado = (Boolean)resultado["estado"]
                            };
                            DespachosEncontrados.Add(DespachoEncontrado);
                        }
                    }
                }
                return DespachosEncontrados;
            }

        }
    }
}