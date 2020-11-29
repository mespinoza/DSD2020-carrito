using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Servicio_Mant.Dominio
{
    [DataContract]
    public class Cliente
    {
        [DataMember]
        public int id_cliente { get; set; }
        [DataMember]
        public string nombre { get; set; }
        [DataMember]
        public string apellido1 { get; set; }
        [DataMember]
        public string apellido2 { get; set; }
        [DataMember]
        public string dni { get; set; }
        [DataMember]
        public string correo { get; set; }

        [DataMember]
        public string direccion { get; set; }
        [DataMember]
        public string referencia { get; set; }
        [DataMember]
        public int id_usuario { get; set; }
        [DataMember]
        public string clave { get; set; }
        [DataMember]
        public bool estadoUsu { get; set; }
    }
}