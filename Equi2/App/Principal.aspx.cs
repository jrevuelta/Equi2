using Equi2.Utilidades;
using Equi2_Core.Modelo.VO;
using Equi2_Core.Servicios;
using System;

namespace Equi2.App
{
    public partial class Principal : System.Web.UI.Page
    {
        Configuracion conf;
        UsuarioVO usuario;
        ServicioDeLogin servicioDeLogin;
        

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Usuario"] != null)
            {
                servicioDeLogin = new ServicioDeLogin();
                conf = new Configuracion();
                usuario = new UsuarioVO();

                usuario.usuario = (String)Session["Usuario"];
                usuario = servicioDeLogin.obtenerUsuarioPorLogin(usuario.usuario);
                hlNombreUsuario.Text = "Bienvenido: " + usuario.usuario;
                conf.setBaseDatosUsusario(usuario.usuario);
                hlAdmin.Visible = usuario.admin;
                
            }
            else
            {
                Response.Redirect("/Index.aspx");
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
           

        }
    }
}