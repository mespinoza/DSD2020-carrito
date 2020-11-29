using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Servicio_Mant.Dominio
{
    [DataContract]
    public class Despacho
    {
        [DataMember]
        public int id_despacho { get; set; }
        [DataMember]
        public DateTime fecha { get; set; }
        [DataMember]
        public int id_compra { get; set; }
        [DataMember]
        public int id_tipo_estado { get; set; }
        [DataMember]
        public Boolean estado { get; set; }
    }
}