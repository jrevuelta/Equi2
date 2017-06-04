using Equi2.Utilidades;
using Equi2_Core.Modelo.Plataforma;
using System.Collections.Generic;

namespace Equi2_Core.DAO
{
    public class IvaDAO
    {
        Configuracion config;

        public IvaDAO(string usuario)
        {
            config = new Configuracion();
            config.setBaseDatosUsusario(usuario);
        }

        /// <summary>
        /// Recupera la información de la tabla IVA a través de su identificador
        /// </summary>
        /// <param name="idIVA">Identificador del tipo de IVA</param>
        /// <returns>Iva VO - Información del tipo de iva. NULL si no lo encuentra</returns>
        public IvaVO recuperarTipoDeIVAporID(int idIVA)
        {
            IvaVO iva = null;

            string sql = "select IdIVA,IVAValor,IvaTipo from IVA where IdIVA = " + idIVA;

            List<object> resultado =  UtilidadesBaseDatos.consultaSelectListaMultiple(config, 3, sql);

            foreach (object o in resultado)
            {
                iva = new IvaVO();
                object[] array = (object[])o;
                iva.idIva = (int)array[0];
                iva.ivaValor = (int)array[1];
                iva.ivaTipo = (string)array[2];
            }

            return iva;
        }

        /// <summary>
        /// Obtiene todos los elementos de la tabla IVA
        /// </summary>
        /// <returns>List<IvaVO> lista con los elementos de la tabla. Lista vacía si no encuentra ninguno</returns>
        public List<IvaVO> listarTodosIVA()
        {
            List<IvaVO> listaIVA = new List<IvaVO>();
            string sql = "select * from IVA";
            // En esta consulta no ponemos los campos uno a uno pero sabemos que son 3
            List<object> resultado = UtilidadesBaseDatos.consultaSelectListaMultiple(config, 3, sql);
            IvaVO iva = null;
            foreach (object o in resultado)
            {
                iva = new IvaVO();
                object[] array = (object[])o;
                iva.idIva = (int)array[0];
                iva.ivaValor = (int)array[1];
                iva.ivaTipo = array[2].ToString();
                
                
                listaIVA.Add(iva);
            }
            return listaIVA;
        }

        /// <summary>
        /// Crea una nueva fila en la tabla IVA con los valores establecidos en los parámetros
        /// </summary>
        /// <param name="iva">IvaVO - Contiene la información relativa al tipo de IVA</param>
        /// <returns>int - Número de filas afectadas</returns>
        public int insertarNuevoTipoDeIVA(IvaVO iva)
        {
            int filasInsertadas = 0;

            string sql = "insert into IVA (ivavalor,ivatipo) values ("+iva.ivaValor+", '"+iva.ivaTipo+"') ";
            filasInsertadas = UtilidadesBaseDatos.insertRow(config, sql);

            return filasInsertadas;
        }

        /// <summary>
        /// Modifica los valores de la tabla IVA que coincidan con su id
        /// </summary>
        /// <param name="iva">IvaVO - Contiene la información del IVA</param>
        /// <returns>int - número de filas modificadas </returns>
        public int modificarTipoDeIVA(IvaVO iva)
        {
            int filasAfectadas = 0;
            string sql = "update IVA set ivavalor =" + iva.ivaValor + ", ivatipo = '" + iva.ivaTipo + "' where IdIVA = " + iva.idIva;
            filasAfectadas = UtilidadesBaseDatos.insertRow(config, sql);
            return filasAfectadas;
        }

        /// <summary>
        /// Elimina una fila de la tabla IVA cuyo identificador coincida con el del parámetro
        /// </summary>
        /// <param name="iva">IvaVO - Contiene la información relativa al tipo de IVA</param>
        /// <returns>int - Número de filas eliminadas</returns>
        public int eliminarTipoDeIVA(IvaVO iva)
        {
            int filasBorradas = 0;
            // delete * from IVA where IdIVA = 5 
            string sql = "delete * from IVA where IdIVA = " + iva.idIva;
            filasBorradas = UtilidadesBaseDatos.insertRow(config, sql);
            return filasBorradas;
        }
    }
}
