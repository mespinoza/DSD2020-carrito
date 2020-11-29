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
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "ServiceArticulo" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione ServiceArticulo.svc o ServiceArticulo.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class ServiceArticulo : IServiceArticulo
    {
        private ArticuloDAO articuloDAO = new ArticuloDAO();
        public Articulo CrearArticulo(Articulo articulo)
        {
            if(articuloDAO.obtenerByDescripcion(articulo.descArticulo)!=null)
            {
                throw new FaultException<RepetidoException>(
                    new RepetidoException()
                    {
                        Codigo = "101",
                        Descripcion = "El Articulo ya Existe"
                    }, new FaultReason("Error al crear Articulo"));
            }
            return articuloDAO.crear(articulo);
        }

        public void EliminarArticulo(int IdArticulo)
        {
            articuloDAO.eliminar(IdArticulo);
        }
        public List<Articulo> ListaArticulos()
        {
            return articuloDAO.Listar();
        }

        public Articulo ModificarArticulo(Articulo articulo)
        {
            return articuloDAO.modificar(articulo);
        }

        public Articulo ObtenerArticulo(int IdArticulo)
        {
            return articuloDAO.obtener(IdArticulo);
        }
    }
}
