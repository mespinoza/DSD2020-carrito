using Servicio_Mant.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace Servicio_Mant
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IServiceCliente" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IServiceCliente
    {
        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "Clientes", ResponseFormat = WebMessageFormat.Json)]
        Cliente CrearCliente(Cliente clienteCrear);

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "Clientes/Confirmar?idUsuario={idUsuario}", ResponseFormat = WebMessageFormat.Json)]
        Cliente ConfirmarCliente(int idUsuario);

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "Clientes?idcliente={idcliente}", ResponseFormat = WebMessageFormat.Json)]
        Cliente ObtenerCliente(int idcliente);

        [OperationContract]
        [WebInvoke(Method = "PUT", UriTemplate = "Clientes", ResponseFormat = WebMessageFormat.Json)]
        Cliente ModificarCliente(Cliente clienteModificar);

        [OperationContract]
        [WebInvoke(Method = "DELETE", UriTemplate = "Clientes?idcliente={idcliente}", ResponseFormat = WebMessageFormat.Json)]
        void EliminarCliente(int idcliente);

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "Clientes", ResponseFormat = WebMessageFormat.Json)]
        List<Cliente> ListarCliente();
    }
}
