using Servicio_Mant.Dominio;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Servicio_Mant.Persistencia
{
    public class CompraDAOD
    {
        private string cadenaConexion = "Data Source=(local); Initial Catalog=Sales;Integrated Security = SSPI";
        //private string cadenaConexion = "server=SISTEMASRW;uid=sa;password=adm123$$;database=sales;";
        public CompraD CrearCompraD(CompraD compraDACrear)
        {
            CompraD compraDCreada = null;
            string sql = "INSERT INTO COMPRA_D VALUES (@idcomprad,@idcompra, @idarticulo, " +
                                "@cantidad, @descuento, @precio, @subtotal, " +
                                "@total, @estado)";
            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                conexion.Open();
                using (SqlCommand comando = new SqlCommand(sql, conexion))
                {
                    comando.Parameters.Add(new SqlParameter("@idcomprad", compraDACrear.IdCompraD));
                    comando.Parameters.Add(new SqlParameter("@idcompra", compraDACrear.IdCompra));
                    comando.Parameters.Add(new SqlParameter("@idarticulo", compraDACrear.IdArticulo));
                    comando.Parameters.Add(new SqlParameter("@cantidad", compraDACrear.Cantidad));
                    comando.Parameters.Add(new SqlParameter("@descuento", compraDACrear.Descuento));
                    comando.Parameters.Add(new SqlParameter("@precio", compraDACrear.Precio));
                    comando.Parameters.Add(new SqlParameter("@subtotal", compraDACrear.Subtotal));
                    comando.Parameters.Add(new SqlParameter("@total", compraDACrear.Total));
                    comando.Parameters.Add(new SqlParameter("@estado", compraDACrear.Estado));
                    comando.ExecuteNonQuery();
                }
            }

            compraDCreada = ObtenerCompraD(compraDACrear.IdCompraD);
            return compraDCreada;
        }

        public CompraD ObtenerCompraD(int idcomprad)
        {
            CompraD compraDEncontrada = null;
            string sql = "SELECT * FROM COMPRA_D WHERE id_compra_d = @idcomprad";
            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                conexion.Open();
                using (SqlCommand comando = new SqlCommand(sql, conexion))
                {
                    comando.Parameters.Add(new SqlParameter("@idcomprad", idcomprad));
                    using (SqlDataReader resultado = comando.ExecuteReader())
                    {
                        if (resultado.Read())
                        {
                            compraDEncontrada = new CompraD()
                            {
                                IdCompraD = (int)resultado["id_compra_d"],
                                IdCompra = (int)resultado["id_compra"],
                                IdArticulo = (int)resultado["id_articulo"],
                                Cantidad = (int)resultado["cantidad"],                                
                                Descuento = (Decimal)resultado["descuento"],
                                Precio = (Decimal)resultado["precio"],
                                Subtotal = (Decimal)resultado["subtotal"],
                                Total = (Decimal)resultado["total"],
                                Estado = (Boolean)resultado["estado"]
                            };
                        }
                    }
                }
            }
            return compraDEncontrada;
        }
        //cambio
        public CompraD ModificarCompraD(CompraD compraDAModificar)
        {
            CompraD compraDModificada = null;
            string sql = "UPDATE COMPRA_D SET " +
                "id_compra = @idcompra, " +
                "id_articulo = @idarticulo, " +
                "cantidad = @cantidad, " +
                "descuento = @descuento, " +
                "precio = @precio, " +
                "subtotal = @subtotal, " +
                "total = @total, " +
                "estado = @estado " +
                "WHERE id_compra_d = @idcomprad)";
            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                conexion.Open();
                using (SqlCommand comando = new SqlCommand(sql, conexion))
                {
                    comando.Parameters.Add(new SqlParameter("@idcomprad", compraDAModificar.IdCompra));
                    comando.Parameters.Add(new SqlParameter("@idcompra", compraDAModificar.IdCompraD));
                    comando.Parameters.Add(new SqlParameter("@idarticulo", compraDAModificar.IdArticulo));
                    comando.Parameters.Add(new SqlParameter("@cantidad", compraDAModificar.Cantidad));
                    comando.Parameters.Add(new SqlParameter("@descuento", compraDAModificar.Descuento));
                    comando.Parameters.Add(new SqlParameter("@precio", compraDAModificar.Precio));
                    comando.Parameters.Add(new SqlParameter("@subtotal", compraDAModificar.Subtotal));
                    comando.Parameters.Add(new SqlParameter("@total", compraDAModificar.Total));
                    comando.Parameters.Add(new SqlParameter("@estado", compraDAModificar.Estado));
                    comando.ExecuteNonQuery();
                }
            }
            compraDModificada = ObtenerCompraD(compraDAModificar.IdCompraD);
            return compraDModificada;
        }

        public void EliminarCompraD(int idcomprad)
        {
            string sql = "DELETE FROM COMPRA_D WHERE id_compra_d = @idcomprad";
            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                conexion.Open();
                using (SqlCommand comando = new SqlCommand(sql, conexion))
                {
                    comando.Parameters.Add(new SqlParameter("@idcomprad", idcomprad));
                    comando.ExecuteNonQuery();
                }
            }
        }

        public List<CompraD> ListarComprasD(int idcompra)
        {
            List<CompraD> comprasDEncontradas = new List<CompraD>();
            CompraD compraDEncontrada = null;
            string sql = "SELECT * FROM COMPRA_D WHERE ID_COMPRA = @idcompra";
            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                conexion.Open();
                using (SqlCommand comando = new SqlCommand(sql, conexion))
                {
                    comando.Parameters.Add(new SqlParameter("@idcompra", idcompra));
                    using (SqlDataReader resultado = comando.ExecuteReader())
                    {
                        while (resultado.Read())
                        {
                            compraDEncontrada = new CompraD()
                            {
                                IdCompraD = (int)resultado["id_compra_d"],
                                IdCompra = (int)resultado["id_compra"],
                                IdArticulo = (int)resultado["id_articulo"],
                                Cantidad = (int)resultado["cantidad"],
                                Descuento = (Decimal)resultado["descuento"],
                                Precio = (Decimal)resultado["precio"],
                                Subtotal = (Decimal)resultado["subtotal"],
                                Total = (Decimal)resultado["total"],
                                Estado = (Boolean)resultado["estado"]
                            };
                            comprasDEncontradas.Add(compraDEncontrada);
                        }
                    }
                }
            }
            return comprasDEncontradas;
        }
        
    }
}