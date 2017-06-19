using Equi2.Utilidades;
using Equi2_Core.Modelo.Plataforma;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Equi2_Core.DAO
{
    public class ClienteDAO
    {
        private static int N_CAMPOS = 29;
        Configuracion config;
        private IvaDAO ivaDAO;
        private IrpfDAO irpfDAO;
        private ClienteTipoDAO clienteTipoDAO;
        private EmpresaDatosDAO empresaDatosDAO;
        private ProvinciaDAO provinciaDAO;
    //    private VeterinarioDAO veterinarioDAO;

        public ClienteDAO(string usuario)
        {
            config = new Configuracion();
            config.setBaseDatosUsusario(usuario);
            ivaDAO = new IvaDAO(usuario);
            irpfDAO = new IrpfDAO(usuario);
            empresaDatosDAO = new EmpresaDatosDAO(usuario);
            clienteTipoDAO = new ClienteTipoDAO(usuario);
            provinciaDAO = new ProvinciaDAO(usuario);
        }

        /// <summary>
        /// Recupera la información de la tabla Cliente a través de su identificador
        /// </summary>
        /// <param name="idCliente">Identificador del cliente</param>
        /// <returns>ClienteVO - Información del cliente. NULL si no lo encuentra</returns>
        public ClienteVO recuperarClientePorID(int idCliente)
        {
            ClienteVO cliente = null;
            string sql = "select * from Cliente where IdCliente=" + idCliente;

            List<object> resultado = UtilidadesBaseDatos.consultaSelectListaMultiple(config, N_CAMPOS, sql);
            foreach (object o in resultado)
            {
                cliente = crearCliente((object[])o);
            }
            return cliente;
        }

        /// <summary>
        /// Obtiene todos los elementos de la tabla Cliente
        /// </summary>
        /// <returns>List<ClienteVO> lista con los elementos de la tabla. Lista vacía si no encuentra ninguno</returns>
        public List<ClienteVO> listarTodosClientes()
        {
            List<ClienteVO> listaClienteTipo = new List<ClienteVO>();
            string sql = "select * from Cliente";

            List<object> resultado = UtilidadesBaseDatos.consultaSelectListaMultiple(config, N_CAMPOS, sql);
            ClienteVO cliente = null;
            foreach (object o in resultado)
            {
                cliente = crearCliente((object[])o);
                listaClienteTipo.Add(cliente);
            }
            return listaClienteTipo;
        }

        /// <summary>
        /// Crea una nueva fila en la tabla Cliente con los valores establecidos en los parámetros
        /// </summary>
        /// <param name="clienteTipo">ClienteVO - Contiene la información relativa al cliente</param>
        /// <returns>int - Número de filas afectadas</returns>
        public int insertarNuevoClienteTipo(ClienteVO clienteTipo)
        {
            int filasInsertadas = 0;

            string sql = "insert into Cliente (Cliente) values ('" + clienteTipo.clienteTipo + "')";
            filasInsertadas = UtilidadesBaseDatos.insertRow(config, sql);

            return filasInsertadas;
        }

        /// <summary>
        /// Modifica los valores de la tabla Cliente que coincidan con su id
        /// </summary>
        /// <param name="clienteTipo">ClienteVO - Contiene la información del clienteTipo</param>
        /// <returns>int - número de filas modificadas </returns>
        public int modificarClienteTipo(ClienteVO clienteTipo)
        {
            int filasAfectadas = 0;
            string sql = "update Cliente set clienteTipo = '" + clienteTipo.clienteTipo + "' where IdClienteTipo = " + clienteTipo.clienteTipo;
            filasAfectadas = UtilidadesBaseDatos.insertRow(config, sql);
            return filasAfectadas;
        }

        /// <summary>
        /// Elimina una fila de la tabla Cliente cuyo identificador coincida con el del parámetro
        /// </summary>
        /// <param name="clienteTipo">ClienteVO - Contiene la información relativa al clienteTipo</param>
        /// <returns>int - Número de filas eliminadas</returns>
        public int eliminarClienteTipo(ClienteVO clienteTipo)
        {
            int filasBorradas = 0;

            string sql = "delete * from Cliente where IdClienteTipo = " + clienteTipo.idCliente;
            filasBorradas = UtilidadesBaseDatos.insertRow(config, sql);
            return filasBorradas;
        }


        private ClienteVO crearCliente(object[] array)
        {
            ClienteVO cliente = new ClienteVO();
            cliente.idCliente = (int)array[0];
            //TODO Campo 1 del array será el id de veterinario;
            cliente.datosEmpresa = empresaDatosDAO.recuperarDatosEmpresaPorID((int)array[2]);
            cliente.clienteTipo = clienteTipoDAO.recuperarClienteTipoPorID((int)array[3]);
            cliente.clienteNombre = array[4].ToString();
            cliente.clienteDireccion = array[5].ToString();
            cliente.clienteLocalidad = array[6].ToString();
            cliente.clienteProvincia = provinciaDAO.recuperarProvinciaPorID((int)array[7]);
            cliente.clienteCP = array[8].ToString();
            cliente.clienteNif = array[9].ToString();
            cliente.clienteTelefono = array[10].ToString();
            cliente.clienteTelefMovil = array[11].ToString();
            cliente.clienteFax = array[12].ToString();
            cliente.clienteMail = array[13].ToString();
            cliente.facturaNombre = array[14].ToString();
            cliente.facturaDireccion = array[15].ToString();
            cliente.facturaLocalidad = array[16].ToString();
            cliente.facturaProvincia = provinciaDAO.recuperarProvinciaPorID((int)array[17]);
            cliente.facturaCP = array[18].ToString();
            cliente.facturaTelefono = array[19].ToString();
            cliente.facturaFax = array[20].ToString();
            cliente.facturaMail = array[21].ToString();
            cliente.facturaNIF = array[22].ToString();
            cliente.facturaIRPF = irpfDAO.recuperarIRPFporID((int)array[23]);
            cliente.facturaIVA = ivaDAO.recuperarTipoDeIVAporID((int)array[24]);
            cliente.contacto = array[25].ToString();
            cliente.personaContacto = array[26].ToString();
            cliente.telefonoContacto = array[27].ToString();
            cliente.observaciones = array[28].ToString();

            return cliente;
        }
    }
}
