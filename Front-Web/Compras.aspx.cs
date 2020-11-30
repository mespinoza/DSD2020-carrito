using Front_Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Front_Web
{
    public partial class Compras : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ArticuloWS.ServiceArticuloClient asc = new ArticuloWS.ServiceArticuloClient();
            GvArticulos.DataSource = asc.ListaArticulos();
            GvArticulos.DataBind();
        }

        protected void BtnGrabar_Click(object sender, EventArgs e)
        {
            ComprasWS.ServiceCompraClient svccompra = new ComprasWS.ServiceCompraClient();
            ComprasWS.Compra compra = new ComprasWS.Compra();
            compra.Descripcion = TxtCupo.Text;
            compra.IdCliente = 1;
            compra.IdPersonal = 1;
            compra.IdTipoEstado = 1;
            compra.IdTipoEntrega = Convert.ToInt32(DDLTipoEntrega.SelectedValue);
            compra.DescuentoTotal = 0;
            compra.SumaTotal = 0;
            compra.FechaEntrega = DateTime.Now;
            compra.Estado = true;

            svccompra.CrearCompra(compra);

            ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "alerta", "alert('Compra Registrada con Exito')", true);
        }

    }
}