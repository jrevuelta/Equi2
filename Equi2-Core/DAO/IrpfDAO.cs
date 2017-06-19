using Equi2.Utilidades;
using Equi2_Core.Modelo.Plataforma;
using System.Collections.Generic;

namespace Equi2_Core.DAO
{
    public class IrpfDAO
    {
        private static int N_CAMPOS = 2;

        Configuracion config;

        public IrpfDAO(string usuario)
        {
            config = new Configuracion();
            config.setBaseDatosUsusario(usuario);
        }

        /// <summary>
        /// Recupera la información de la tabla IRPF a través de su identificador
        /// </summary>
        /// <param name="idIRPF">Identificador del tipo de IRPF</param>
        /// <returns>IrpfVO - Información del tipo de IRPF. NULL si no lo encuentra</returns>
        public IrpfVO recuperarIRPFporID(int idIRPF)
        {
            IrpfVO irpf = null;
            // La tabla IRPF tiene 2 campos solo
            string sql = "select * from IRPF where IdIRPF=" + idIRPF;

            List<object> resultado = UtilidadesBaseDatos.consultaSelectListaMultiple(config, N_CAMPOS, sql);

            foreach (object o in resultado)
            {
                irpf = new IrpfVO();
                object[] array = (object[])o;
                irpf.idIRPF = (int)array[0];
                irpf.irpfValor = (int)array[1];
            }

            return irpf;
        }

        /// <summary>
        /// Obtiene todos los elementos de la tabla IRPF
        /// </summary>
        /// <returns>List<IrpfVO> lista con los elementos de la tabla. Lista vacía si no encuentra ninguno</returns>
        public List<IrpfVO> listarTodosIRPF()
        {
            List<IrpfVO> listaIRPF = new List<IrpfVO>();
            string sql = "select * from IRPF";
            
            List<object> resultado = UtilidadesBaseDatos.consultaSelectListaMultiple(config, N_CAMPOS, sql);
            IrpfVO irpf = null;
            foreach (object o in resultado)
            {
                irpf = new IrpfVO();
                object[] array = (object[])o;
                irpf.idIRPF= (int)array[0];
                irpf.idIRPF = (int)array[1];
                
                listaIRPF.Add(irpf);
            }
            return listaIRPF;
        }

        /// <summary>
        /// Crea una nueva fila en la tabla IRPF con los valores establecidos en los parámetros
        /// </summary>
        /// <param name="irpf">IrpfVO - Contiene la información relativa al tipo de IRPF</param>
        /// <returns>int - Número de filas afectadas</returns>
        public int insertarNuevoTipoDeIRPF(IrpfVO irpf)
        {
            int filasInsertadas = 0;

            string sql = "insert into IRPF (IRPFValor) values ("+irpf.irpfValor+")";
            filasInsertadas = UtilidadesBaseDatos.insertRow(config, sql);

            return filasInsertadas;
        }

        /// <summary>
        /// Modifica los valores de la tabla IRPF que coincidan con su id
        /// </summary>
        /// <param name="irpf">IrpfVO - Contiene la información del IRPF</param>
        /// <returns>int - número de filas modificadas </returns>
        public int modificarTipoDeIRPF(IrpfVO irpf)
        {
            int filasAfectadas = 0;
            string sql = "update IRPF set IRPFValor =" + irpf.irpfValor+ " where IdIRPF = " + irpf.idIRPF;
            filasAfectadas = UtilidadesBaseDatos.insertRow(config, sql);
            return filasAfectadas;
        }

        /// <summary>
        /// Elimina una fila de la tabla IRPF cuyo identificador coincida con el del parámetro
        /// </summary>
        /// <param name="irpf">IrpfVO - Contiene la información relativa al tipo de IRPF</param>
        /// <returns>int - Número de filas eliminadas</returns>
        public int eliminarTipoDeIRPF(IrpfVO irpf)
        {
            int filasBorradas = 0;
            
            string sql = "delete * from IRPF where IdIRPF = " + irpf.idIRPF;
            filasBorradas = UtilidadesBaseDatos.insertRow(config, sql);
            return filasBorradas;
        }
    }

}
