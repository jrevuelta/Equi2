using Equi2.Utilidades;
using Equi2_Core.Modelo.Plataforma;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Equi2_Core.DAO
{
    public class EmpresaDatosDAO
    {

        private static int N_CAMPOS = 9;
        Configuracion config;

        public EmpresaDatosDAO(string usuario)
        {
            config = new Configuracion();
            config.setBaseDatosUsusario(usuario);
        }

        /// <summary>
        /// Recupera la información de la tabla EmpresaDatos a través de su identificador
        /// </summary>
        /// <param name="idDatosEmpresa">Identificador del cliente tipo</param>
        /// <returns>DatosEmpresaVO - Información del tipo de cliente. NULL si no lo encuentra</returns>
        public DatosEmpresaVO recuperarDatosEmpresaPorID(int idDatosEmpresa)
        {
            DatosEmpresaVO dEmpresa = null;
            string sql = "select * from EmpresaDatos where IdDatosEmpresa = " + idDatosEmpresa;

            List<object> resultado = UtilidadesBaseDatos.consultaSelectListaMultiple(config, N_CAMPOS, sql);
            foreach (object o in resultado)
            {
                object[] array = (object[])o;
                dEmpresa = crearDatosEmpresa(array);
            }
            return dEmpresa;
        }

        /// <summary>
        /// Obtiene todos los elementos de la tabla EmpresaDatos
        /// </summary>
        /// <returns>List<DatosEmpresaVO> lista con los elementos de la tabla. Lista vacía si no encuentra ninguno</returns>
        public List<DatosEmpresaVO> listarTodasEmpresaDatos()
        {
            List<DatosEmpresaVO> listaEmpresaDatos = new List<DatosEmpresaVO>();
            string sql = "select * from EmpresaDatos";

            List<object> resultado = UtilidadesBaseDatos.consultaSelectListaMultiple(config, N_CAMPOS, sql);
            DatosEmpresaVO dEmpresa = null;
            foreach (object o in resultado)
            {
                object[] array = (object[])o;
                dEmpresa = crearDatosEmpresa(array);
                listaEmpresaDatos.Add(dEmpresa);
            }
            return listaEmpresaDatos;
        }

        /// <summary>
        /// Crea una nueva fila en la tabla EmpresaDatos con los valores establecidos en los parámetros
        /// </summary>
        /// <param name="eD">DatosEmpresaVO - Contiene la información relativa a la empresa</param>
        /// <returns>int - Número de filas afectadas</returns>
        public int insertarNuevoEmpresaDatos(DatosEmpresaVO eD)
        {
            int filasInsertadas = 0;

            string sql = "insert into EmpresaDatos (Linea1, Linea2, Linea3, Linea4, Linea5, Linea6, Pie) values('" + eD.linea1 + "', '" + eD.linea2 + "', '" + eD.linea3 + "', '" + eD.linea4 + "', '" + eD.linea5 + "', '" + eD.linea6 + "', '" + eD.pie + "')";
            filasInsertadas = UtilidadesBaseDatos.insertRow(config, sql);

            return filasInsertadas;
        }

        /// <summary>
        /// Modifica los valores de la tabla EmpresaDatos que coincidan con su id
        /// </summary>
        /// <param name="eD">DatosEmpresaVO - Contiene la información del clienteTipo</param>
        /// <returns>int - número de filas modificadas </returns>
        public int modificarEmpresaDatos(DatosEmpresaVO eD)
        {
            int filasAfectadas = 0;
            string sql = "update EmpresaDatos set Linea1 = '" + eD.linea1 + "',Linea2 = '" + eD.linea2 + "',Linea3 = '" + eD.linea3 + "',Linea4 = '" + eD.linea4 + "',Linea5='" + eD.linea5 + "',Linea6='" + eD.linea6 + "',Pie ='" + eD.pie + "' where IdDatosEmpresa = " +eD.idDatosEmpresa;
            filasAfectadas = UtilidadesBaseDatos.insertRow(config, sql);
            return filasAfectadas;
        }

        /// <summary>
        /// Elimina una fila de la tabla EmpresaDatos cuyo identificador coincida con el del parámetro
        /// </summary>
        /// <param name="datosEmpresa">DatosEmpresaVO - Contiene la información relativa a los datos de empresa</param>
        /// <returns>int - Número de filas eliminadas</returns>
        public int eliminarEmpresaDatos(DatosEmpresaVO datosEmpresa)
        {
            int filasBorradas = 0;

            string sql = "delete * from EmpresaDatos where IdDatosEmpresa = " + datosEmpresa.idDatosEmpresa;
            filasBorradas = UtilidadesBaseDatos.insertRow(config, sql);
            return filasBorradas;
        }


        /// <summary>
        /// Crea un objeto DatosEmpresaVO a partir de un array de base de datos
        /// </summary>
        /// <param name="array">object[] - Contiene la información de la base de datos</param>
        /// <returns>DatosEmpresaVO</returns>
        private DatosEmpresaVO crearDatosEmpresa(object[] array)
        {
            DatosEmpresaVO dEmpresa = new DatosEmpresaVO();
            dEmpresa.idDatosEmpresa = (int)array[0];
            dEmpresa.empresaLogo = "";
            dEmpresa.linea1 = array[2].ToString();
            dEmpresa.linea2 = array[3].ToString();
            dEmpresa.linea3 = array[4].ToString();
            dEmpresa.linea4 = array[5].ToString();
            dEmpresa.linea5 = array[6].ToString();
            dEmpresa.linea6 = array[7].ToString();
            // FIXME: Comprobar que se puede leer
            dEmpresa.pie = array[8].ToString();

            return dEmpresa;
        }

    }
}
