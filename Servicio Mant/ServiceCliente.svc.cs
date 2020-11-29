using Servicio_Mant.Dominio;
using Servicio_Mant.Persistencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Servicio_Mant
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "ServiceCliente" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione ServiceCliente.svc o ServiceCliente.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class ServiceCliente : IServiceCliente
    {
        private ClienteDAO asedao = new ClienteDAO();
        public Cliente CrearCliente(Cliente clienteCrear)
        {

            return asedao.Crear(clienteCrear);
        }

        public Cliente ObtenerCliente(int idcliente)
        {
            return asedao.Obtener(idcliente);
        }

        public Cliente ModificarCliente(Cliente clienteModificar)
        {
            return asedao.Modificar(clienteModificar);
        }

        public void EliminarCliente(int idcliente)
        {
            asedao.Eliminar(idcliente);
        }

        public List<Cliente> ListarCliente()
        {
            return asedao.Listar();
        }
    }
}
