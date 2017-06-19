using Equi2.Utilidades;
using Equi2_Core.DAO;
using Equi2_Core.Modelo.Plataforma;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Equi2.App
{
    public partial class Principal : System.Web.UI.Page
    {
        Configuracion conf;
        string usuario;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Usuario"] != null)
            {
                conf = new Configuracion();
                usuario = (String)Session["Usuario"];
                conf.setBaseDatosUsusario(usuario);
              
            }
            else
            {
                Response.Redirect("/Index.aspx");
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            ClienteDAO clienteDAO = new ClienteDAO(usuario);
            ClienteVO cliente = clienteDAO.recuperarClientePorID(1);

            List<ClienteVO> listaDeClientes = clienteDAO.listarTodosClientes();
            listaDeClientes.Count();

        }
    }
}