using Front_Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Front_Web
{
    public partial class Usuario : System.Web.UI.Page
    {
        protected void btn_ingresar_Click(object sender, EventArgs e)
        {
            string usu = txt_correo.Text;
            string conta = txt_contraseña.Text;

            UsuarioModel usuarioModel = new UsuarioModel();
            UsuarioWS.ServiceUsuarioClient usuarioLogin = new UsuarioWS.ServiceUsuarioClient();
            var usuario = usuarioLogin.ObtenerUsuario(usu, conta);
            if (usuario != null)
            {
                usuarioModel.Cusuario = usuario.Cusuario;
                usuarioModel.idusuario = usuario.idusuario;
                usuarioModel.descripcion = usuario.descripcion;
                Session["Usuario"] = usuarioModel;
                Response.Redirect("Default.aspx");
            }
            else
            {
                string script = "alert(\"El usuario no pertenece al sistema o contraseña incorrecta.\");";
                ScriptManager.RegisterStartupScript(this, GetType(),
                                      "ServerControlScript", script, true);
            }
        }
    }
}