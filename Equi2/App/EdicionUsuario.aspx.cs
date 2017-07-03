using Equi2.Utilidades;
using Equi2_Core.Modelo.VO;
using Equi2_Core.Servicios;
using Equi2_Core.Utilidades;
using System;

namespace Equi2.App
{
    public partial class EdicionUsuario : System.Web.UI.Page
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

                txtContrasena1.Attributes["type"] = "password";
                txtContrasena2.Attributes["type"] = "password";
            }

            else
            {
                Response.Redirect("/Index.aspx");
            }
            if (!IsPostBack)
            {
                // Especifico de esta pantalla
                this.txtContrasena1.Text = usuario.password;
                this.txtContrasena2.Text = usuario.password;
                this.txtEmail.Text = usuario.email;
                this.txtTelefono.Text = usuario.telefono;
            }
            
        }

        protected void btnGuardarDatosUsuario_Click(object sender, EventArgs e)
        {
            bool hayError = false;
            string textoError = "";

            if (txtContrasena1.Text.Equals(txtContrasena2.Text))
            {
                if (txtContrasena1.Text.Length > 5)
                {
                    usuario.password = Encriptacion.Encriptar(txtContrasena1.Text);
                }
                else
                {
                    hayError = true;
                    textoError = "La contraseña debe tener al menos 6 caracteres";
                }
                
            }
            else
            {
                hayError = true;
                textoError = "Las contraseñas deben de ser iguales";
            }
            
            if (!hayError)
            {
                usuario.telefono = txtTelefono.Text;
                usuario.email = txtEmail.Text;
                int resultado = servicioDeLogin.actualizarDatosDeUsusario(usuario);
                if (resultado == 0)
                {
                    panelError.Visible = true;
                    lblMensajeError.Text = "No se han guardado los datos del usuario";
                }
                else
                {
                    Response.Redirect("./Principal.aspx");
                }
            }
            else
            {
                lblMensajeError.Text = textoError;
                panelError.Visible = true;
            }
            
        }
    }
}