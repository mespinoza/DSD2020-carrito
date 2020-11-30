using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Front_Web.Models
{
    public class CompraModel
    {
       
        public int IdCompra { get; set; }

       
        public string Descripcion { get; set; }

       
        public int IdCliente { get; set; }

       
        public int IdPersonal { get; set; }

       
        public int IdTipoEstado { get; set; }

       
        public int IdTipoEntrega { get; set; }

       
        public Decimal DescuentoTotal { get; set; }

       
        public Decimal SumaTotal { get; set; }

       
        public DateTime FechaEntrega { get; set; }

       
        public Boolean Estado { get; set; }
    }
}