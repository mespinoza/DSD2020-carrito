using Servicio_Mant.Dominio;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace Servicio_Mant.Persistencia
{
    public class CompraDAO
    {//pareja
       
        private string cadenaConexion = "Data Source=(local); Initial Catalog=Sales;Integrated Security = SSPI";

        public Compra CrearCompra(Compra compraACrear)
        {
            int idcompre = 0;

            Compra compraCreada = null;

            string sql = "Sp_Compras";
            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                conexion.Open();
                using (SqlCommand comando = new SqlCommand(sql, conexion))
                {
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.CommandTimeout = 3800;


                    comando.Parameters.Add(new SqlParameter("@descripcion", compraACrear.Descripcion));
                    comando.Parameters.Add(new SqlParameter("@idcliente", compraACrear.IdCliente));
                    comando.Parameters.Add(new SqlParameter("@idpersonal", compraACrear.IdPersonal));
                    comando.Parameters.Add(new SqlParameter("@idtipoestado", compraACrear.IdTipoEstado));
                    comando.Parameters.Add(new SqlParameter("@idtipoentrega", compraACrear.IdTipoEntrega));
                    comando.Parameters.Add(new SqlParameter("@descuentototal", compraACrear.DescuentoTotal));
                    comando.Parameters.Add(new SqlParameter("@sumatotal", compraACrear.SumaTotal));
                    comando.Parameters.Add(new SqlParameter("@fechaentrega", compraACrear.FechaEntrega));
                    comando.Parameters.Add(new SqlParameter("@estado", compraACrear.Estado));
                    comando.Parameters.AddWithValue("@idcomprasalida", SqlDbType.Int).Direction = ParameterDirection.Output;


                    comando.ExecuteNonQuery();

                    idcompre = Convert.ToInt32(comando.Parameters["@idcomprasalida"].Value);
                }
            }

            compraCreada = ObtenerCompra(idcompre);
            return compraCreada;
        }

        public Compra ObtenerCompra(int idcompra)
        {
            Compra compraEncontrada = null;
            string sql = "SELECT * FROM Compra WHERE id_compra = @idcompra";
            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                conexion.Open();
                using (SqlCommand comando = new SqlCommand(sql, conexion))
                {
                    comando.Parameters.Add(new SqlParameter("@idcompra", idcompra));
                    using (SqlDataReader resultado = comando.ExecuteReader())
                    {
                        if (resultado.Read())
                        {
                            compraEncontrada = new Compra()
                            {
                                IdCompra = (int)resultado["id_compra"],
                                Descripcion = (string)resultado["descripcion"],
                                IdCliente = (int)resultado["id_cliente"],
                                IdPersonal = (int)resultado["id_personal"],
                                IdTipoEstado = (int)resultado["id_tipo_estado"],
                                IdTipoEntrega = (int)resultado["id_tipo_entrega"],
                                DescuentoTotal = (Decimal)resultado["descuento_total"],
                                SumaTotal = (Decimal)resultado["sum_total"],
                                FechaEntrega = Convert.ToDateTime(resultado["fecha_entrega"]),
                                Estado = (Boolean)resultado["estado"]
                            };
                        }
                    }
                }
            }
            return compraEncontrada;
        }
        //cambio
        public Compra ModificarCompra(Compra compraAModificar)
        {
            Compra compraModificada = null;
            string sql = "UPDATE Compra SET " +
                "descripcion = @descripcion, " +
                "id_cliente = @idcliente, " +
                "id_personal = @idpersonal, " +
                "id_tipo_estado = @idtipoestado, " +
                "id_tipo_entrega = @idtipoentrega, " +
                "descuento_total = @descuentototal, " +
                "sum_total = @sumatotal, " +
                "fecha_entrega = @fechaentrega, " +
                "estado = @estado " +
                "WHERE id_compra = @idcompra)";
            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                conexion.Open();
                using (SqlCommand comando = new SqlCommand(sql, conexion))
                {
                    comando.Parameters.Add(new SqlParameter("@idcompra", compraAModificar.IdCompra));
                    comando.Parameters.Add(new SqlParameter("@descripcion", compraAModificar.Descripcion));
                    comando.Parameters.Add(new SqlParameter("@idcliente", compraAModificar.IdCliente));
                    comando.Parameters.Add(new SqlParameter("@idpersonal", compraAModificar.IdPersonal));
                    comando.Parameters.Add(new SqlParameter("@idtipoestado", compraAModificar.IdTipoEstado));
                    comando.Parameters.Add(new SqlParameter("@idtipoentrega", compraAModificar.IdTipoEntrega));
                    comando.Parameters.Add(new SqlParameter("@descuentototal", compraAModificar.DescuentoTotal));
                    comando.Parameters.Add(new SqlParameter("@sumatotal", compraAModificar.SumaTotal));
                    comando.Parameters.Add(new SqlParameter("@fechaentrega", compraAModificar.FechaEntrega));
                    comando.Parameters.Add(new SqlParameter("@estado", compraAModificar.Estado));
                    comando.ExecuteNonQuery();
                }
            }
            compraModificada = ObtenerCompra(compraAModificar.IdCompra);
            return compraModificada;
        }

        public void EliminarCompra(int idcompra)
        {
            string sql = "DELETE FROM Compra WHERE id_compra = @idcompra";
            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                conexion.Open();
                using (SqlCommand comando = new SqlCommand(sql, conexion))
                {
                    comando.Parameters.Add(new SqlParameter("@idcompra", idcompra));
                    comando.ExecuteNonQuery();
                }
            }
        }

        public List<Compra> ListarCompras()
        {
            List<Compra> comprasEncontradas = new List<Compra>();
            Compra compraEncontrada = null;
            string sql = "SELECT * FROM Compra";
            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                conexion.Open();
                using (SqlCommand comando = new SqlCommand(sql, conexion))
                {
                    using (SqlDataReader resultado = comando.ExecuteReader())
                    {
                        while (resultado.Read())
                        {
                            compraEncontrada = new Compra()
                            {
                                IdCompra = (int)resultado["id_compra"],
                                Descripcion = (string)resultado["descripcion"],
                                IdCliente = (int)resultado["id_cliente"],
                                IdPersonal = (int)resultado["id_personal"],
                                IdTipoEstado = (int)resultado["id_tipo_estado"],
                                IdTipoEntrega = (int)resultado["id_tipo_entrega"],
                                DescuentoTotal = (Decimal)resultado["descuento_total"],
                                SumaTotal = (Decimal)resultado["sum_total"],
                                FechaEntrega = Convert.ToDateTime(resultado["fecha_entrega"]),
                                Estado = (Boolean)resultado["estado"]
                            };
                            comprasEncontradas.Add(compraEncontrada);
                        }
                    }
                }
            }
            return comprasEncontradas;
        }
        public List<Compra> ListarCompra()
        {
            List<Compra> ComprasEncontrados = new List<Compra>();
            Compra CompraEncontrado = null;
            string sql = "SELECT * from Compra";
            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                conexion.Open();
                using (SqlCommand comando = new SqlCommand(sql, conexion))
                {
                    using (SqlDataReader resultado = comando.ExecuteReader())
                    {
                        while (resultado.Read())
                        {
                            CompraEncontrado = new Compra()
                            {
                                IdCompra = (int)resultado["id_compra"],
                                Descripcion = (string)resultado["descripcion"],
                                IdCliente = (int)resultado["id_cliente"],
                                IdPersonal = (int)resultado["id_personal"],
                                IdTipoEstado = (int)resultado["id_tipo_estado"],
                                IdTipoEntrega = (int)resultado["id_tipo_entrega"],
                                DescuentoTotal = (Decimal)resultado["descuento_total"],
                                SumaTotal = (Decimal)resultado["sum_total"],
                                FechaEntrega = Convert.ToDateTime(resultado["fecha_entrega"]),
                                Estado = (Boolean)resultado["estado"]
                            };
                            ComprasEncontrados.Add(CompraEncontrado);
                        }
                    }
                }
                return ComprasEncontrados;
            }

        }
    }
}