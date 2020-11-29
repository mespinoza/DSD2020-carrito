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
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "ServiceCompra" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione ServiceCompra.svc o ServiceCompra.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class ServiceCompra : IServiceCompra
    {
        private CompraDAO compraDAO = new CompraDAO();
        public List<Compra> ListarCompra()
        {
            return compraDAO.ListarCompra();
        }
    }
}
