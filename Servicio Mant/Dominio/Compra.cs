using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Servicio_Mant.Dominio
{
    [DataContract]
    public class Compra
    {
        [DataMember]
        public int IdCompra { get; set; }

        [DataMember]
        public string Descripcion { get; set; }

        [DataMember]
        public int IdCliente { get; set; }

        [DataMember]
        public int IdPersona { get; set; }

        [DataMember]
        public int IdTipoEstado { get; set; }

        [DataMember]
        public int IdTipoEntrega { get; set; }

        [DataMember]
        public Decimal DescuentoTotal { get; set; }

        [DataMember]
        public Decimal SumaTotal { get; set; }

        [DataMember]
        public DateTime FechaEntrega { get; set; }

        [DataMember]
        public Boolean Estado { get; set; }
    }
}