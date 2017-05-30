using System;
using System.IO;

namespace Equi2.Utilidades
{
	public class Configuracion
	{
        private static string PREFIJO_BD = "D:\\Desarrollo\\BDD\\EQUI2\\";
        public static string rutaBDDefault = PREFIJO_BD + "equi2.mdb";
        public static string rutaMDW = PREFIJO_BD+ "VIA.MDW";

       
        private static string BD_USUARIO = "Data.mdb";
        private string usuario;

        public string rutaTrabajo;

		public Configuracion()
		{
            this.rutaTrabajo = rutaBDDefault;
		}

        public void setBaseDatosUsusario (String usuario)
        {
            this.usuario = usuario;
            rutaTrabajo = PREFIJO_BD + usuario + "\\" + BD_USUARIO;
        }

        public string getBaseDatosUsuario()
        {
            return rutaTrabajo;
        }

        public Boolean esUsuarioActivo (String usuario)
        {
            return usuario.CompareTo(this.usuario) == 1;
        }
	}
}
