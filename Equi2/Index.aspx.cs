using System;
using Equi2_Core.Servicios;


namespace Equi2
{
    public partial class Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Usuario"] != null)
            {
                Session["Usuario"] = null;
            }
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            lblMensajeError.Text = "";
            bool error = false;
            if (inpUsuario.Text.Length == 0)
            {
                lblMensajeError.Text = "- El nombre de usuario no puede estar vacio.\n";
                error = true;
            }
            else
            {
                if (inpPassword.Text.Length == 0)
                {
                    lblMensajeError.Text += "- Debe introducir una contraseña.\n";
                    error = true;
                }
            }
            
            if (lblMensajeError.Text.Length == 0)
            {
                ServicioDeLogin servicioDeLogin = new ServicioDeLogin();
                if (servicioDeLogin.esLoginCorrecto(inpUsuario.Text, inpPassword.Text))
                {
                    // Vamos a la pantalla principal
                    Session["Usuario"] = inpUsuario.Text;
                    Response.Redirect("/App/Principal.aspx");
                }
                else
                {
                    lblMensajeError.Text += "- Usuario o contraseña incorrectos.";
                    error = true;
                }
            }
            panelError.Visible = error;
        }
    }
}