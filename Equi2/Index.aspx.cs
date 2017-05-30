using System;
using Equi2_Core.Servicios;


namespace Equi2
{
    public partial class Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            ServicioDeLogin servicioDeLogin = new ServicioDeLogin();
            if (servicioDeLogin.esLoginCorrecto(inpUsuario.Text, inpPassword.Text))
            {
                // Vamos a la pantalla principal
            }
            else
            {
                // Mostramos cuadro de error
            }
        }
    }
}