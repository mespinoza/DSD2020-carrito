﻿using Front_Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Front_Web
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ConfiguracionMenu();
        }
        public void ConfiguracionMenu()
        {
            var usuario = (UsuarioModel)Session["Usuario"];
            switch (usuario.descripcion)
            {
                case "admin":
                    linkVentas.Visible = true;
                    linkInicio.Visible = true;
                    linkVentas.Visible = true;
                    LinkArticulo.Visible = true;
                    LinkCompras.Visible = true;
                    LinkDespacho.Visible = true;
                    break;
                case "usuario":
                    linkVentas.Visible = false;
                    linkInicio.Visible = true;
                    linkVentas.Visible = false;
                    LinkArticulo.Visible = false;
                    LinkCompras.Visible = false;
                    LinkDespacho.Visible = false;
                    break;
            }
        }

        protected void linkInicio_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }

        protected void LinkArticulo_Click(object sender, EventArgs e)
        {
            Response.Redirect("Articulo.aspx");
        }

        protected void LinkCompras_Click(object sender, EventArgs e)
        {
            Response.Redirect("Compras.aspx");
        }

        protected void LinkDespacho_Click(object sender, EventArgs e)
        {
            Response.Redirect("Despacho.aspx");
        }

        protected void LinSalir_Click(object sender, EventArgs e)
        {
            Session["Usuario"] = null;
            Session.Abandon();
            Response.Redirect("Usuario.aspx");
        }
    }
}