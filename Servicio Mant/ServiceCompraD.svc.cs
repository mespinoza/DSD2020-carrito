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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ServiceCompraD" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select ServiceCompraD.svc or ServiceCompraD.svc.cs at the Solution Explorer and start debugging.
    public class ServiceCompraD : IServiceCompraD
    {

        private CompraDAOD compraDAOD = new CompraDAOD();

        public CompraD CrearCompraD(CompraD compraDACrear)
        {
            return compraDAOD.CrearCompraD(compraDACrear);
        }

        public void EliminarCompraD(int idcomprad)
        {
            compraDAOD.EliminarCompraD(idcomprad);
        }

        public List<CompraD> ListarCompraD(int idcompra)
        {
            return compraDAOD.ListarComprasD(idcompra);
        }

        public CompraD ModificarCompraD(CompraD compraDAModificar)
        {
            return compraDAOD.ModificarCompraD(compraDAModificar);
        }

        public CompraD ObtenerCompraD(int idcomprad)
        {
            return compraDAOD.ObtenerCompraD(idcomprad);
        }
    }
}
