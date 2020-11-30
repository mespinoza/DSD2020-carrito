using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Servicio_Mant.Dominio
{
    [DataContract]
    public class CompraD
    {
        [DataMember]
        public int IdCompraD { get; set; }

        [DataMember]
        public int IdCompra { get; set; }

        [DataMember]
        public int IdArticulo { get; set; }

        [DataMember]
        public int Cantidad { get; set; }

        [DataMember]
        public Decimal Descuento { get; set; }

        [DataMember]
        public Decimal Precio { get; set; }

        [DataMember]
        public Decimal Subtotal { get; set; }

        [DataMember]
        public Decimal Total { get; set; }

        [DataMember]
        public Boolean Estado { get; set; }
    }
}