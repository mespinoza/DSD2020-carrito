using Front_Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Front_Web
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            var usuario = (UsuarioModel)Session["Usuario"];
            //lblUsuario.Text = "jhon@upc.edu.pe";
            if (usuario == null)
            {
                lblUsuario.Text = "Falta Registrarse";
            }
            else
            {
                lblUsuario.Text = usuario.Cusuario;
            }

        }

        //articulos que se encuentran en oferta
        private void sb_listar_articulos_oferta()
        {
            //OfertaWS.ServiceOfertaClient oferta = new OfertaWS.ServiceOfertaClient();
            //GvCompras.DataSource = servicioCompra.ListarCompra();
            //GvCompras.DataBind();
        }

    }
}