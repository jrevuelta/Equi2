using Equi2.Utilidades;
using Equi2_Core.Modelo.Plataforma;
using System.Collections.Generic;

namespace Equi2_Core.DAO
{
    public class ProvinciaDAO
    {
        private static int N_CAMPOS = 2;
        private Configuracion config;

        public ProvinciaDAO (string usuario)
        {
            config = new Configuracion();
            config.setBaseDatosUsusario(usuario);
        }

        /// <summary>
        /// Obtiene un objeto de tipo ProvinciaVO a partir del identificador
        /// </summary>
        /// <param name="idProvincia">Identificador de la provincia</param>
        /// <returns>ProvinciaVO contiene los datos de la provincia - Null si no existe</returns>
        public ProvinciaVO recuperarProvinciaPorID(int idProvincia)
        {
            ProvinciaVO provincia = null;

            string sql = "select * from Provincia where IdProvincia=" + idProvincia;

            List<object> resultado = UtilidadesBaseDatos.consultaSelectListaMultiple(config, N_CAMPOS, sql);
            foreach (object o in resultado)
            {
                provincia = crearProvincia((object[])o);
            }


            return provincia;
        }

        /// <summary>
        /// Obtiene un listado de todas las Provincias
        /// </summary>
        /// <returns>List<ProvinciaVO> - listado de provincias</returns>
        public List<ProvinciaVO> listarTodasProvincias()
        {
            List<ProvinciaVO> listaDeProvincias = new List<ProvinciaVO>();
            
            string sql = "select * from Provincia";

            List<object> resultado = UtilidadesBaseDatos.consultaSelectListaMultiple(config, N_CAMPOS, sql);
           
            foreach (object o in resultado)
            {
                listaDeProvincias.Add(crearProvincia((object[])o));
            }


            return listaDeProvincias;
        }

        /// <summary>
        /// Crea un objeto ProvinciaVO a partir de un array
        /// </summary>
        /// <param name="array">object[]</param>
        /// <returns>ProvinciaVO</returns>
        private ProvinciaVO crearProvincia (object[] array)
        {

            ProvinciaVO provincia = new ProvinciaVO();
            provincia.idProvincia = (int)array[0];
            provincia.nombre = array[1].ToString();

            return provincia;
        }
    }
}