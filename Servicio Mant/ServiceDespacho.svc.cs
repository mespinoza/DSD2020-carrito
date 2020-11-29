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
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "ServiceDespacho" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione ServiceDespacho.svc o ServiceDespacho.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class ServiceDespacho : IServiceDespacho
    {
        private DespachoDAO despachoDAO = new DespachoDAO();
        public Despacho CrearDespacho(Despacho DespachoACrear)
        {
            if (despachoDAO.Obtener(DespachoACrear.id_compra) != null)//existe
            {
                throw new FaultException<RepetidoException>(
                    new RepetidoException()
                    {
                        Codigo = "101",
                        Descripcion = "Despacho ya Existe"
                    }, new FaultReason("Error al intentar la Creación"));

            }
            return despachoDAO.CrearDespacho(DespachoACrear);
        }

        public List<Despacho> ListarDespachos()
        {
            return despachoDAO.ListarDespacho();
        }

        public Despacho ObtenerDespacho(int id_compra)
        {
            return despachoDAO.Obtener(id_compra);
        }
    }
}
