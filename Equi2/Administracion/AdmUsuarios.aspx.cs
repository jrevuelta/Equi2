using Equi2.Utilidades;
using Equi2_Core.Modelo.VO;
using Equi2_Core.Servicios;
using System;

namespace Equi2.Administracion
{
    public partial class AdmUsuarios : System.Web.UI.Page
    {

        Configuracion conf;  // Se usa para establecer la ruta de la base de datos a la que tiene que atacar el cliente
        UsuarioVO usuario; // Contiene la información y algunos datos de un usuario de la aplicación
        ServicioDeLogin servicioDeLogin; // Contiene funciones relacionadas con el login y el usuario



        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Usuario"] != null)
            {
                servicioDeLogin = new ServicioDeLogin();
                conf = new Configuracion();
                usuario = new UsuarioVO();
                usuario.usuario = (String)Session["Usuario"];
                usuario = servicioDeLogin.obtenerUsuarioPorLogin(usuario.usuario);
                lblNombreUsuario.Text = "Bienvenido: " + usuario.usuario;
                conf.setBaseDatosUsusario(usuario.usuario);
                //Button1.Visible = usuario.admin;

                if (!usuario.admin)
                {
                    Response.Redirect("/App/Principal.aspx");
                }
            }
            else
            {
                Response.Redirect("/Index.aspx");
            }

        }
    }
}