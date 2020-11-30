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
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IServiceCompra" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IServiceCompra
    {
        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "CrearCompra", ResponseFormat = WebMessageFormat.Json)]
        Compra CrearCompra(Compra compraACrear);

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "ObtenerCompra/{idcompra}", ResponseFormat = WebMessageFormat.Json)]
        Compra ObtenerCompra(int idcompra);

        [OperationContract]
        [WebInvoke(Method = "PUT", UriTemplate = "CompraModif", ResponseFormat = WebMessageFormat.Json)]
        Compra ModificarCompra(Compra compraAModificar);

        [OperationContract]
        [WebInvoke(Method = "DELETE", UriTemplate = "CompraElim/{idcompra}", ResponseFormat = WebMessageFormat.Json)]
        void EliminarCompra(int idcompra);

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "ListarCompra", ResponseFormat = WebMessageFormat.Json)]
        List<Compra> ListarCompra();

    }
}
