using Servicio_Mant.Dominio;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;


namespace Servicio_Mant.Persistencia
{
    public class ArticuloDAO
    {
        private string cadenaConexion = "Data Source=(local); Initial Catalog=Sales;Integrated Security = SSPI";

        public Articulo crear(Articulo articuloCrear)
        {
            Articulo articuloNuevo = null;
            string query = "insert dbo.Articulo(descripcion,id_categoria,id_unidad_medida,stock,precio,estado) values(@Descripcion,@IdCategoria,@IdUnidadMedida,@Stock,@Precio,@Estado)";
            using(SqlConnection con=new SqlConnection(cadenaConexion))
            {
                con.Open();
                using(SqlCommand cmd= new SqlCommand(query,con))
                {
                    //cmd.Parameters.Add(new SqlParameter("@IdArticulo", articuloCrear.idArticulo));
                    cmd.Parameters.Add(new SqlParameter("@Descripcion", articuloCrear.descArticulo));
                    cmd.Parameters.Add(new SqlParameter("@IdCategoria", articuloCrear.idCategoria));
                    cmd.Parameters.Add(new SqlParameter("@IdUnidadMedida", articuloCrear.idUnidadMedida));
                    cmd.Parameters.Add(new SqlParameter("@Stock", articuloCrear.stock));
                    cmd.Parameters.Add(new SqlParameter("@Precio", articuloCrear.precio));
                    cmd.Parameters.Add(new SqlParameter("@Estado", articuloCrear.estado));
                    cmd.ExecuteNonQuery();
                }
            }
            articuloNuevo = obtener(articuloCrear.idArticulo);
            return articuloNuevo;
        }
        public Articulo obtener(int idArticulo)
        {
            Articulo articuloEncontrado = null;
            string query = "Select * from dbo.Articulo where Id_Articulo=@IdArticulo";
            using (SqlConnection con = new SqlConnection(cadenaConexion))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.Add(new SqlParameter("@IdArticulo", idArticulo));
                   using(SqlDataReader resultado=cmd.ExecuteReader())
                    {
                        if (resultado.Read())
                        {
                            articuloEncontrado = new Articulo()
                            {
                                idArticulo = (int)resultado["id_articulo"],
                                descArticulo = (string)resultado["descripcion"],
                                idCategoria = (int)resultado["id_categoria"],
                                idUnidadMedida = (int)resultado["id_unidad_medida"],
                                stock = (int)resultado["stock"],
                                precio = (decimal)resultado["precio"],
                                estado = (bool)resultado["estado"]
                            };
                        }
                    }
                }
            }
            return articuloEncontrado;
        }
        public Articulo obtenerByDescripcion(string descripcion)
        {
            Articulo articuloEncontrado = null;
            string query = "Select * from dbo.Articulo where descripcion=@descripcion";
            using (SqlConnection con = new SqlConnection(cadenaConexion))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.Add(new SqlParameter("@descripcion", descripcion));
                    using (SqlDataReader resultado = cmd.ExecuteReader())
                    {
                        if (resultado.Read())
                        {
                            articuloEncontrado = new Articulo()
                            {
                                idArticulo = (int)resultado["id_articulo"],
                                descArticulo = (string)resultado["descripcion"],
                                idCategoria = (int)resultado["id_categoria"],
                                idUnidadMedida = (int)resultado["id_unidad_medida"],
                                stock = (int)resultado["stock"],
                                precio = (decimal)resultado["precio"],
                                estado = (bool)resultado["estado"]
                            };
                        }
                    }
                }
            }
            return articuloEncontrado;
        }
        public Articulo modificar(Articulo articuloCrear)
        {
            Articulo articuloNuevo = null;
            string query = "update dbo.Articulo set " +
                "descripcion=@Descripcion,id_categoria=@IdCategoria,id_unidad_medida=@IdUnidadMedida,stock=@Stock,precio=@Precio,estado=@Estado where id_articulo=@IdArticulo";
            using (SqlConnection con = new SqlConnection(cadenaConexion))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.Add(new SqlParameter("@IdArticulo", articuloCrear.idArticulo));
                    cmd.Parameters.Add(new SqlParameter("@Descripcion", articuloCrear.descArticulo));
                    cmd.Parameters.Add(new SqlParameter("@IdCategoria", articuloCrear.idCategoria));
                    cmd.Parameters.Add(new SqlParameter("@IdUnidadMedida", articuloCrear.idUnidadMedida));
                    cmd.Parameters.Add(new SqlParameter("@Stock", articuloCrear.stock));
                    cmd.Parameters.Add(new SqlParameter("@Precio", articuloCrear.precio));
                    cmd.Parameters.Add(new SqlParameter("@Estado", articuloCrear.estado));
                    cmd.ExecuteNonQuery();
                }
            }
            articuloNuevo = obtener(articuloCrear.idArticulo);
            return articuloNuevo;
        }
        public void eliminar(int idArticulo)
        {
            string query = "delete dbo.Articulo where id_articulo=@IdArticulo";
            using (SqlConnection con = new SqlConnection(cadenaConexion))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.Add(new SqlParameter("@IdArticulo", idArticulo));
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public List<Articulo> Listar()
        {
            List<Articulo> articulos = new List<Articulo>();
            Articulo articuloEncontrado = null;
            string query = "Select * from dbo.Articulo";
            using (SqlConnection con = new SqlConnection(cadenaConexion))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    using (SqlDataReader resultado = cmd.ExecuteReader())
                    {
                        while (resultado.Read())
                        {
                            articuloEncontrado = new Articulo()
                            {
                                idArticulo = (int)resultado["id_articulo"],
                                descArticulo = (string)resultado["descripcion"],
                                idCategoria = (int)resultado["id_categoria"],
                                idUnidadMedida = (int)resultado["id_unidad_medida"],
                                stock = (int)resultado["stock"],
                                precio = (decimal)resultado["precio"],
                                estado = (bool)resultado["estado"]
                            };
                            articulos.Add(articuloEncontrado);
                        }
                    }
                }
            }
            return articulos;
        }
    }
}