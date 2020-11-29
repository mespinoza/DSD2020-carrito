using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Servicio_Mant.Dominio
{
    [DataContract]
    public class Usuarioc
    {
        [DataMember]
        public string Cusuario { get; set; }

        [DataMember]
        public string Ccontrasena { get; set; }
    }
}