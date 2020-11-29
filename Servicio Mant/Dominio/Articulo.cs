using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Servicio_Mant.Dominio
{
    [DataContract]
    public class Articulo
    { 
        [DataMember]
        public int idArticulo { get; set;}
        [DataMember]
        public int idCategoria { get; set; }
        [DataMember]
        public string descArticulo { get; set;}
        [DataMember]
        public int idUnidadMedida { get; set; }
        [DataMember]
        public int stock { get; set; }
        [DataMember]
        public decimal precio { get; set; }
        [DataMember(IsRequired =true)]
        public bool estado { get; set; }

    }
}