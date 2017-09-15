using Equi2.Utilidades;
using Equi2_Core.Modelo.VO;
using Equi2_Core.Servicios;
using Equi2_Core.Utilidades;
using System;
using System.Collections.Generic;
using System.Web.Services;
using System.Web.UI.WebControls;

namespace Equi2.Administracion
{
    public partial class AdmUsuarios : System.Web.UI.Page
    {

        Configuracion conf;  // Se usa para establecer la ruta de la base de datos a la que tiene que atacar el cliente
        UsuarioVO usuario; // Contiene la información y algunos datos de un usuario de la aplicación
        ServicioDeLogin servicioDeLogin; // Contiene funciones relacionadas con el login y el usuario
        List<UsuarioVO> listaDeUsuarios;

        /// <summary>
        /// Método que se ejecuta cuando se carga la pantalla
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
                // Logica de la pantalla
                UtilidadesTablas.esqueletoTabla(tblUsuarios, 6, new string[6] { "Id", "Nombre", "E-mail", "Teléfono", "Admin", "Borrado" });
                listaDeUsuarios = servicioDeLogin.obtenerTodosLosUsuarios();
                tblUsuarios = cargarTablaUsuarios(tblUsuarios, listaDeUsuarios);

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

        /// <summary>
        /// Carga la información en la tabla de usuarios
        /// </summary>
        /// <param name="tabla"></param>
        /// <param name="listaDeUsuarios"></param>
        /// <returns></returns>
        private Table cargarTablaUsuarios(Table tabla, List<UsuarioVO> listaDeUsuarios)
        {

            foreach (UsuarioVO usu in listaDeUsuarios)
            {
                TableRow fila = new TableRow();
                TableCell tc = new TableCell();
                tc.Text = usu.idUsuario.ToString();
                fila.Cells.Add(tc);
                tc = new TableCell();
                tc.Text = usu.usuario;
                fila.Cells.Add(tc);
                tc = new TableCell();
                tc.Text = (string)usu.email;
                fila.Cells.Add(tc);
                tc = new TableCell();
                tc.Text = (string)usu.telefono;
                fila.Cells.Add(tc);
                tc = new TableCell();
                tabla.Rows.Add(fila);
                tc = new TableCell();
                tc.Text = usu.getAdmin();
                fila.Cells.Add(tc);
                tc = new TableCell();
                tc.Text = usu.getBorrado();
                fila.Cells.Add(tc);
            }
            return tabla;
        }




        //----------------------------------
        //         Llamadas desde Ajax
        //-----------------------------------
        [WebMethod]
        public static string AltaModificacionUsuarios(int idUsuario,string usuario,string contrasena,string email,string telefono,bool admin, bool borrado)
        {
            string nFilas = "";

            ServicioDeLogin servicioDeLogin = new ServicioDeLogin();
            UsuarioVO usu = new UsuarioVO();
            usu.idUsuario = idUsuario;
            usu.usuario = usuario;
            usu.password = contrasena;
            usu.email = email;
            usu.telefono = telefono;
            usu.borrado = borrado;
            usu.admin = admin;

            if (usu.idUsuario == 0)
            {
                // Creamos uno nuevo
                nFilas = ""+servicioDeLogin.crearNuevoUsuario(usu);
            }
            else
            {
                UsuarioVO uaux = servicioDeLogin.obtenerUsuarioPorID(usu.idUsuario);
                uaux.password = (usu.password == "") ? uaux.password : usu.password;
                uaux.email = (usu.email== "") ? uaux.email : usu.email;
                uaux.telefono = (usu.telefono != "") ? uaux.telefono : usu.telefono;
                uaux.admin = usu.admin;
                uaux.borrado = usu.borrado;
                // Modificamos el usuario
                nFilas =""+ servicioDeLogin.actualizarDatosDeUsusario(uaux);
            }

            return nFilas;
            
        }

    }
}