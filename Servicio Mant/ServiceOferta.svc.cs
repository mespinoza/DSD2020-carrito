using Servicio_Mant.Dominio;
using Servicio_Mant.Errores;
using Servicio_Mant.Persistencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Servicio_Mant
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "ServiceOferta" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione ServiceOferta.svc o ServiceOferta.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class ServiceOferta : IServiceOferta
    {
        private ofertaDAO Ofertadao = new ofertaDAO();//este es nuevo
        public Ofertac Oferta(string fecha)
        {
            if (Ofertadao.Sb_optener_oferta(fecha) == null)
            {
                throw new FaultException<UsuarioExecepcion>(
                     new UsuarioExecepcion()
                     {
                         Codigo = "102",
                         Descripcion = "No existe articulos de oferta"
                     },
                     new FaultReason("No existe articulos de oferta")
                );
            }

            return Ofertadao.Sb_optener_oferta(fecha);
        }
    }
}
