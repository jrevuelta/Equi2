using Equi2.Utilidades;
using Equi2_Core.Modelo.Plataforma;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Equi2_Core.DAO
{
    public class ClienteTipoDAO
    {
        private static int N_CAMPOS = 2;
        Configuracion config;

        public ClienteTipoDAO(string usuario)
        {
            config = new Configuracion();
            config.setBaseDatosUsusario(usuario);
        }

        /// <summary>
        /// Recupera la información de la tabla ClienteTipo a través de su identificador
        /// </summary>
        /// <param name="idClienteTipo">Identificador del cliente tipo</param>
        /// <returns>ClienteTipoVO - Información del tipo de cliente. NULL si no lo encuentra</returns>
        public ClienteTipoVO recuperarClienteTipoPorID(int idClienteTipo)
        {
            ClienteTipoVO ct = null;
            string sql = "select * from ClienteTipo where IdClienteTipo=" + idClienteTipo;

            List<object> resultado = UtilidadesBaseDatos.consultaSelectListaMultiple(config, N_CAMPOS, sql);
            foreach (object o in resultado)
            {
                ct = new ClienteTipoVO();
                object[] array = (object[])o;
                ct.idClienteTipo = (int)array[0];
                ct.clienteTipo = array[1].ToString();
            }
            return ct;
        }

        /// <summary>
        /// Obtiene todos los elementos de la tabla ClienteTipo
        /// </summary>
        /// <returns>List<ClienteTipoVO> lista con los elementos de la tabla. Lista vacía si no encuentra ninguno</returns>
        public List<ClienteTipoVO> listarTodosClienteTipo()
        {
            List<ClienteTipoVO> listaClienteTipo = new List<ClienteTipoVO>();
            string sql = "select * from ClienteTipo";

            List<object> resultado = UtilidadesBaseDatos.consultaSelectListaMultiple(config, N_CAMPOS, sql);
            ClienteTipoVO ct = null;
            foreach (object o in resultado)
            {
                ct = new ClienteTipoVO();
                object[] array = (object[])o;
                ct.idClienteTipo = (int)array[0];
                ct.clienteTipo = array[1].ToString();

                listaClienteTipo.Add(ct);
            }
            return listaClienteTipo;
        }

        /// <summary>
        /// Crea una nueva fila en la tabla ClienteTipo con los valores establecidos en los parámetros
        /// </summary>
        /// <param name="clienteTipo">ClienteTipoVO - Contiene la información relativa al cliente tipo</param>
        /// <returns>int - Número de filas afectadas</returns>
        public int insertarNuevoClienteTipo(ClienteTipoVO clienteTipo)
        {
            int filasInsertadas = 0;

            string sql = "insert into ClienteTipo (ClienteTipo) values ('" + clienteTipo.clienteTipo + "')";
            filasInsertadas = UtilidadesBaseDatos.insertRow(config, sql);

            return filasInsertadas;
        }

        /// <summary>
        /// Modifica los valores de la tabla ClienteTipo que coincidan con su id
        /// </summary>
        /// <param name="clienteTipo">ClienteTipoVO - Contiene la información del clienteTipo</param>
        /// <returns>int - número de filas modificadas </returns>
        public int modificarClienteTipo(ClienteTipoVO clienteTipo)
        {
            int filasAfectadas = 0;
            string sql = "update ClienteTipo set clienteTipo = '" + clienteTipo.clienteTipo + "' where IdClienteTipo = " + clienteTipo.clienteTipo;
            filasAfectadas = UtilidadesBaseDatos.insertRow(config, sql);
            return filasAfectadas;
        }

        /// <summary>
        /// Elimina una fila de la tabla ClienteTipo cuyo identificador coincida con el del parámetro
        /// </summary>
        /// <param name="clienteTipo">ClienteTipoVO - Contiene la información relativa al clienteTipo</param>
        /// <returns>int - Número de filas eliminadas</returns>
        public int eliminarClienteTipo(ClienteTipoVO clienteTipo)
        {
            int filasBorradas = 0;

            string sql = "delete * from ClienteTipo where IdClienteTipo = " + clienteTipo.idClienteTipo;
            filasBorradas = UtilidadesBaseDatos.insertRow(config, sql);
            return filasBorradas;
        }
    }
}

