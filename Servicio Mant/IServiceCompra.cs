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
        Compra CrearCompra(Compra compraACrear);

        [OperationContract]
        Compra ObtenerCompra(int idcompra);

        [OperationContract]
        Compra ModificarCompra(Compra compraAModificar);

        [OperationContract]
        void EliminarCompra(int idcompra);

        [OperationContract]
        List<Compra> ListarCompra();

    }
}
