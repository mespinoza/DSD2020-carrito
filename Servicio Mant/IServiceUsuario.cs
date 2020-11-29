using Servicio_Mant.Dominio;
using Servicio_Mant.Errores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Servicio_Mant
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IServiceUsuario" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IServiceUsuario
    {
        [FaultContract(typeof(UsuarioExecepcion))]
        [OperationContract]
        Usuarioc ObtenerUsuario(string Iusua, string Icontra);
    }
}
