using Servicio_Mant.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Servicio_Mant
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IServiceCompraD" in both code and config file together.
    [ServiceContract]
    public interface IServiceCompraD
    {
        [OperationContract]
        CompraD CrearCompraD(CompraD compraDACrear);

        [OperationContract]
        CompraD ObtenerCompraD(int idcomprad);

        [OperationContract]
        CompraD ModificarCompraD(CompraD compraDAModificar);

        [OperationContract]
        void EliminarCompraD(int idcomprad);

        [OperationContract]
        List<CompraD> ListarCompraD(int idcompra);
    }
}
