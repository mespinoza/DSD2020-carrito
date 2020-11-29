using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Servicio_Mant.Dominio
{
    [DataContract]
    public class Ofertac
    {
        [DataMember]
        public string nombre { get; set; }

        [DataMember]
        public int cantidad { get; set; }

        [DataMember]
        public decimal precio { get; set; }

        [DataMember]
        public string fecha { get; set; }
    }
}