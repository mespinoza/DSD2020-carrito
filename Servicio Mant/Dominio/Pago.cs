using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Servicio_Mant.Dominio
{
    [DataContract]
    public class Pago
    {
        [DataMember]
        public int IdPago { get; set; }

        [DataMember]
        public int IdTipoEntrega { get; set; }

        [DataMember]
        public String Fecha { get; set; }

        [DataMember]
        public int Estado { get; set; }
    }
}