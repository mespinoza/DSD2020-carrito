using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Front_Web
{
    public partial class Cliente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            const string URL = "http://localhost:53331/ServiceCliente.svc/Clientes";

            if (txtNombre.Text == "")
            {
                ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "alerta", "alert('Ingresar Nombre')", true);
                txtNombre.Focus();
            }

            try
            {
                Object cliente = new
                {
                    id_cliente = 0,
                    nombre = txtNombre.Text,
                    apellido1 = txtPaterno.Text,
                    apellido2 = txtMaterno.Text,
                    dni = txtDni.Text,
                    correo = txtCorreo.Text,
                    direccion = txtDireccion.Text,
                    referencia = txtReferencia.Text,
                    id_usuario = 1,
                    estadoUsu = true,
                    clave = "1234"
                };

                string inputJson = (new JavaScriptSerializer()).Serialize(cliente);

                HttpClient client = new HttpClient();
                HttpResponseMessage response = client.PostAsync(
                    URL,
                    new StringContent(inputJson, Encoding.UTF8, "application/json")
                    ).Result;

                var re = response.Content.ReadAsStringAsync().Result;
                Console.WriteLine(re);

                ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "alerta", "alert('Registro exitoso. Para terminar el proceso debe confirmar desde el correo ingresado')", true);

            }
            catch
            {

            }

        }
    }
}