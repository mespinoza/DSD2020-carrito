﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Front_Web
{
    public partial class Despacho : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ComprasWS.ServiceCompraClient servicioCompra = new ComprasWS.ServiceCompraClient();
            GvCompras.DataSource = servicioCompra.ListarCompra();
            GvCompras.DataBind();
        }
        private void Limpiar()
        {
            TxtCompra.Text = "";
            TxtFecha.Text = "";
            LblDireccion.Visible = false;
        }
        protected void GvCompras_SelectedIndexChanged(object sender, EventArgs e)
        {
            btncancelar.Visible = true;
            btndespachar.Visible = true;
            Paneltabla.Visible = true;
            Limpiar();
            TxtCompra.Text = Server.HtmlDecode(this.GvCompras.Rows[this.GvCompras.SelectedIndex].Cells[1].Text);
        }
    
            protected void btndespachar_Click(object sender, EventArgs e)
        {

            if (TxtFecha.Text == "")
            {
                ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "alerta", "alert('Seleccione Fecha')", true);
                TxtFecha.Focus();
            }
            else
            {
                //ComprasWS.ServiceCompraClient servicioCompra = new ComprasWS.ServiceCompraClient();
                //servicioCompra.ModificarCompra(new ComprasWS.Compra()
                //{
             
                //});

                DespachoWS.ServiceDespachoClient servicioDespacho = new DespachoWS.ServiceDespachoClient();
                servicioDespacho.CrearDespacho(new DespachoWS.Despacho()
                {
                    fecha = Convert.ToDateTime(TxtFecha.Text),
                    id_compra = Convert.ToInt32(TxtCompra.Text),
                    id_tipo_estado = 1,
                    estado = true
                });

                ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "alerta", "alert('Compra Despachada con Exito')", true);
                Paneltabla.Visible = false;
                Limpiar();
            }
        }
        protected void btncancelar_Click(object sender, EventArgs e)
        {

            Limpiar();
            btncancelar.Visible = false;
            btndespachar.Visible = false;
            Paneltabla.Visible = false;
        }
        protected void BtnUbicacion_Click(object sender, EventArgs e)
        {
            LblDireccion.Visible = true;
            LblDireccion.Text = "Dirección Referencia >>> "  + TxtDireccion.Text;
        }
    }
}