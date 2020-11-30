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
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "ServiceUsuario" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione ServiceUsuario.svc o ServiceUsuario.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class ServiceUsuario : IServiceUsuario
    {
        private usuarioDAO Usuariodao = new usuarioDAO();//este es nuevo
        public Usuarioc ObtenerUsuario(string Iusua, string Icontra)
        {
            //if (Usuariodao.Sb_usuario_obtener(Iusua, Icontra) == null)
            //{
            //    throw new FaultException<UsuarioExecepcion>(
            //         new UsuarioExecepcion()
            //         {
            //             Codigo = "102",
            //             Descripcion = "El usuario no existe"
            //         },
            //         new FaultReason("Error al intentar obtener usuario")
            //    );
            //}

            return Usuariodao.Sb_usuario_obtener(Iusua, Icontra);
        }
    }
}
