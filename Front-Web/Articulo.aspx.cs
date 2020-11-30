using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Front_Web
{
    public partial class Articulo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ArticuloWS.ServiceArticuloClient servicioArticulos = new ArticuloWS.ServiceArticuloClient();
            GvArticulos.DataSource = servicioArticulos.ListaArticulos();
            GvArticulos.DataBind();
        }
        private void Limpiar()
        {
            TxtDescripcion.Text = "";
            DDLCategoria.SelectedIndex =  0;
            TxtStock.Text  = "";
            txtPRecio.Text = "";
        }


        protected void GvArticulos_SelectedIndexChanged(object sender, EventArgs e)
        {
            //btncancelar.Visible = true;
            //BtnGrabar.Visible = true;
            //Limpiar();
           //TxtCompra.Text = Server.HtmlDecode(this.GvCompras.Rows[this.GvCompras.SelectedIndex].Cells[1].Text);

        }
        protected void btncancelar_Click(object sender, EventArgs e)
        {
            Limpiar();
            btncancelar.Visible = false;
            BtnGrabar.Visible = false;
            BtnNuevo.Visible = true;
            Paneltabla.Visible = false;
        }
        protected void BtnNuevo_Click(object sender, EventArgs e)
        {
            Limpiar();
            btncancelar.Visible = true;
            BtnGrabar.Visible = true;
            BtnNuevo.Visible = false;
            Paneltabla.Visible = true;
        }


        protected void BtnGrabar_Click(object sender, EventArgs e)
        {
            ArticuloWS.ServiceArticuloClient servicioArticulo= new ArticuloWS.ServiceArticuloClient();
            servicioArticulo.CrearArticulo(new ArticuloWS.Articulo()
            {
                descArticulo = TxtDescripcion.Text,
                idCategoria = Convert.ToInt32(DDLCategoria.SelectedValue),
                stock = Convert.ToInt32(TxtStock.Text),
                precio = Convert.ToDecimal(txtPRecio.Text),
                estado = true
            }); 

            ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "alerta", "alert('Articulo Registrado')", true);
            Paneltabla.Visible = false;
            Limpiar();
            btncancelar.Visible = false;
            BtnGrabar.Visible = false;
            BtnNuevo.Visible = true;

            ArticuloWS.ServiceArticuloClient servicioArticulos = new ArticuloWS.ServiceArticuloClient();
            GvArticulos.DataSource = servicioArticulos.ListaArticulos();
            GvArticulos.DataBind();
        }
    }
}