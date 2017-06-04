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
            IrpfVO irpf = new IrpfVO();
            irpf.idIRPF = 4;
            irpf.irpfValor = 50;
            IrpfDAO irpfDAO = new IrpfDAO(usuario);

            // Insertar nuevo

            irpfDAO.insertarNuevoTipoDeIRPF(irpf);

            // modificar
            irpf.irpfValor = 33;
            irpfDAO.modificarTipoDeIRPF(irpf);

            // recuperar por id
            irpf = irpfDAO.recuperarIRPFporID(irpf.idIRPF);

            // eliminar

            irpfDAO.eliminarTipoDeIRPF(irpf);

            // listar

            List<IrpfVO> listaIRPF = irpfDAO.listarTodosIRPF();

            int tamano = listaIRPF.Count;

        }
    }
}