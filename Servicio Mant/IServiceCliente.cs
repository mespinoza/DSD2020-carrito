using Servicio_Mant.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Servicio_Mant
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IServiceCliente" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IServiceCliente
    {
        [OperationContract]
        Cliente CrearCliente(Cliente clienteCrear);

        [OperationContract]
        Cliente ObtenerCliente(int idcliente);

        [OperationContract]
        Cliente ModificarCliente(Cliente clienteModificar);

        [OperationContract]
        void EliminarCliente(int idcliente);

        [OperationContract]
        List<Cliente> ListarCliente();
    }
}
