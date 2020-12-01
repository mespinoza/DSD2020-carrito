using Servicio_Mant.Dominio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Servicio_Mant.Persistencia
{
    public class ClienteDAO
    {
        //private string cadenaConexion = "Data Source=(local); Initial Catalog=Sales;Integrated Security = SSPI";
        private string cadenaConexion = "Data Source=10.2.10.173;Initial Catalog=Sales;User ID=USR_DEVRRHH;Password=d3vrrhhu5r";

        public Cliente Crear(Cliente clientecrear)
        {
            Cliente clientecreado = null;
            string sql = "Sp_Cliente";
            int codcliente = 0;
            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                conexion.Open();
                using (SqlCommand comando = new SqlCommand(sql, conexion))
                {
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.CommandTimeout = 3800;
                    comando.Parameters.AddWithValue("@nombre", clientecrear.nombre);
                    comando.Parameters.AddWithValue("@apellido1", clientecrear.apellido1);
                    comando.Parameters.AddWithValue("@apellido2", clientecrear.apellido2);
                    comando.Parameters.AddWithValue("@dni", clientecrear.dni);
                    comando.Parameters.AddWithValue("@correo", clientecrear.correo);
                    comando.Parameters.AddWithValue("@clave", clientecrear.clave);
                    comando.Parameters.AddWithValue("@direccion", clientecrear.direccion);
                    comando.Parameters.AddWithValue("@referencia", clientecrear.referencia);
                    comando.Parameters.AddWithValue("@estado", clientecrear.estadoUsu);
                    comando.Parameters.AddWithValue("@idcliente", SqlDbType.Int).Direction = ParameterDirection.Output;
                    comando.ExecuteNonQuery();



                    codcliente = Convert.ToInt32(comando.Parameters["@idcliente"].Value);

                }
            }
            clientecreado = Obtener(codcliente);
            return clientecreado;
        }
        public void Notificar(string correo, int idUsuario)
        {
            string sql = "Sp_NotificarRegistro";
            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                conexion.Open();
                using (SqlCommand comando = new SqlCommand(sql, conexion))
                {
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.CommandTimeout = 3800;
                    comando.Parameters.Add(new SqlParameter("@Correo", correo));
                    comando.Parameters.Add(new SqlParameter("@IdUsuario", idUsuario));
                    comando.ExecuteNonQuery();
                }
            }
        }
        public Cliente Obtener(int idcliente)
        {
            Cliente clientecreado = null;
            //string sql = "select * from cliente WHERE id_cliente=@id_cliente";
            string sql = "select c.*,u.clave,u.estado from cliente c inner join usuario u on u.id_usuario=c.id_usuario WHERE id_cliente=@id_cliente";
            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                conexion.Open();
                using (SqlCommand comando = new SqlCommand(sql, conexion))
                {
                    comando.Parameters.Add(new SqlParameter("@id_cliente", idcliente));
                    using (SqlDataReader resultado = comando.ExecuteReader())
                    {
                        if (resultado.Read())
                        {
                            clientecreado = new Cliente()
                            {
                                id_cliente = (int)resultado["id_cliente"],
                                nombre = (string)resultado["nombre"],
                                apellido1 = (string)resultado["apellido1"],
                                apellido2 = (string)resultado["apellido2"],
                                dni = (string)resultado["dni"],
                                correo = (string)resultado["correo"],
                                direccion = (string)resultado["direccion"],
                                referencia = (string)resultado["referencia"],
                                id_usuario = (int)resultado["id_usuario"],
                                estadoUsu = (bool)resultado["estado"],
                                clave = (string)resultado["clave"]
                            };
                        }

                    }
                }
            }

            return clientecreado;
        }

        public Cliente Modificar(Cliente clientemodif)
        {
            Cliente clientemodificado = null;
            string sql = "Sp_Cliente_Update";
            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                conexion.Open();
                using (SqlCommand comando = new SqlCommand(sql, conexion))
                {

                    comando.CommandType = CommandType.StoredProcedure;
                    comando.CommandTimeout = 3800;
                    comando.Parameters.AddWithValue("@idcliente", clientemodif.id_cliente);
                    comando.Parameters.AddWithValue("@nombre", clientemodif.nombre);
                    comando.Parameters.AddWithValue("@apellido1", clientemodif.apellido1);
                    comando.Parameters.AddWithValue("@apellido2", clientemodif.apellido2);
                    comando.Parameters.AddWithValue("@dni", clientemodif.dni);
                    comando.Parameters.AddWithValue("@correo", clientemodif.correo);
                    comando.Parameters.AddWithValue("@clave", clientemodif.clave);
                    comando.Parameters.AddWithValue("@direccion", clientemodif.direccion);
                    comando.Parameters.AddWithValue("@referencia", clientemodif.referencia);
                    comando.Parameters.AddWithValue("@estado", clientemodif.estadoUsu);
                    comando.ExecuteNonQuery();

                }
            }
            clientemodificado = Obtener(clientemodif.id_cliente);
            return clientemodificado;
        }


        public void Eliminar(int idcliente)
        {
            string sql = "Sp_Cliente_Elim";
            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                conexion.Open();
                using (SqlCommand comando = new SqlCommand(sql, conexion))
                {
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.CommandTimeout = 3800;
                    comando.Parameters.Add(new SqlParameter("@idcliente", idcliente));
                    comando.ExecuteNonQuery();
                }
            }
        }

        public List<Cliente> Listar()
        {

            List<Cliente> listencontrados = new List<Cliente>();
            Cliente clientescontrado = null;

            string sql = "select c.*,u.clave,u.estado from cliente c inner join usuario u on u.id_usuario=c.id_usuario";

            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                conexion.Open();
                using (SqlCommand comando = new SqlCommand(sql, conexion))
                {
                    using (SqlDataReader resultado = comando.ExecuteReader())
                    {

                        while (resultado.Read())
                        {
                            clientescontrado = new Cliente()
                            {
                                id_cliente = (int)resultado["id_cliente"],
                                nombre = (string)resultado["nombre"],
                                apellido1 = (string)resultado["apellido1"],
                                apellido2 = (string)resultado["apellido2"],
                                dni = (string)resultado["dni"],
                                correo = (string)resultado["correo"],
                                direccion = (string)resultado["direccion"],
                                referencia = (string)resultado["referencia"],
                                id_usuario = (int)resultado["id_usuario"],
                                estadoUsu = (bool)resultado["estado"],
                                clave = (string)resultado["clave"]
                            };
                            listencontrados.Add(clientescontrado);

                        }
                    }
                }
            }

            return listencontrados;
        }

    }
}