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
        int UsuarioSession = 0;
        void CargaProductos()
        {
            ArticuloWS.ServiceArticuloClient asc = new ArticuloWS.ServiceArticuloClient();
            GvArticulos.DataSource = asc.ListaArticulos();
            GvArticulos.DataBind();

        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                CargaProductos();
            } 
 
        }

        protected void BtnGrabar_Click(object sender, EventArgs e)
        {

            bool validacion = false;
            Decimal precioval = 0;

            foreach (GridViewRow row in GvArticulos.Rows)
            {
                if (row.RowType == DataControlRowType.DataRow)
                {
                    CheckBox chkRow = (row.Cells[0].FindControl("chbItem") as CheckBox);

                    if (chkRow.Checked)
                    {
                        validacion = true;

                        string codarticulo = row.Cells[1].Text;
                        string precio = row.Cells[3].Text;
                        string cantidad = (row.Cells[4].FindControl("txtCant") as TextBox).Text;

                        if (cantidad == "")
                        {
                            validacion = false;
                            ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "alerta", "alert('Ingrese una cantidad')", true);
                            return;
                        }

                        precioval = precioval + (Convert.ToDecimal(precio) * Convert.ToDecimal(cantidad));


                    }
                }
            }

            if (validacion)
            {

                UsuarioSession = (int)Session["IdUsuario"];

                ComprasWS.ServiceCompraClient svccompra = new ComprasWS.ServiceCompraClient();
                ComprasWS.Compra comprareturn = new ComprasWS.Compra();
                ComprasWS.Compra compra = new ComprasWS.Compra();
                compra.Descripcion = TxtCupo.Text;
                compra.IdCliente = Convert.ToInt32(UsuarioSession);
                compra.IdPersonal = 1;
                compra.IdTipoEstado = 1;
                compra.IdTipoEntrega = Convert.ToInt32(DDLTipoEntrega.SelectedValue);
                compra.DescuentoTotal = 0;
                compra.SumaTotal = precioval;
                compra.FechaEntrega = DateTime.Now;
                compra.Estado = true;

                int idcompratemp= svccompra.CrearCompra(compra).IdCompra;
                
                ComprasDetalleWS.ServiceCompraDClient svccomprad = new ComprasDetalleWS.ServiceCompraDClient();
                ComprasDetalleWS.CompraD comprad = new ComprasDetalleWS.CompraD();

                int cont = 0;

                foreach (GridViewRow row in GvArticulos.Rows)
                {
                    if (row.RowType == DataControlRowType.DataRow)
                    {

                        CheckBox chkRowTemp = (row.Cells[0].FindControl("chbItem") as CheckBox);

                        if (chkRowTemp.Checked)
                        {

                            cont = cont + 1;

                            string codarticulotemp = row.Cells[1].Text;
                            string preciotemp = row.Cells[3].Text;
                            string cantidadtemp = (row.Cells[4].FindControl("txtCant") as TextBox).Text;

                            comprad.IdCompraD = cont;
                            comprad.IdCompra = idcompratemp;
                            comprad.IdArticulo = Convert.ToInt32(codarticulotemp);
                            comprad.Cantidad = Convert.ToInt32(cantidadtemp);
                            comprad.Descuento = 0;
                            comprad.Precio = Convert.ToDecimal(preciotemp);
                            comprad.Subtotal = (Convert.ToDecimal(preciotemp) * Convert.ToDecimal(cantidadtemp));
                            comprad.Total = (Convert.ToDecimal(preciotemp) * Convert.ToDecimal(cantidadtemp)); ;
                            comprad.Estado = true;

                            svccomprad.CrearCompraD(comprad);

                        }

                    }
                }


                //ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "alerta", "alert('Compra Registrada con Exito - N° : '" + idcompratemp.ToString() + ")", true);
                string mensaje = "Compra Registrada con Exito - N° : " + idcompratemp.ToString();
                ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "alerta", "alert('" + mensaje + "')", true);

                limpiar();

            }
            else {
                ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "alerta", "alert('Seleccione un producto')", true);

            }

        }

        private void limpiar() {
            TxtCupo.Text = "";
            CargaProductos();
        }

    }
}