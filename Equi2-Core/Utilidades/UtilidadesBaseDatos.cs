using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;

namespace Equi2.Utilidades
{
	public class UtilidadesBaseDatos
	{
		public static string cadenaConexion(Configuracion config)
		{
            string cadenaConexion = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + config.getBaseDatosUsuario()+"; Jet OLEDB:System database="+Configuracion.rutaMDW+";User ID=usuario;Password=;";
            return cadenaConexion;
		}

		public static object consultaSelect(Configuracion configuracion, string selectSql)
		{
			object result = null;
			try
			{
				List<object> list = UtilidadesBaseDatos.consultaSelectLista(configuracion, selectSql);
				if (list != null && list.Any<object>())
				{
					result = list[0];
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.ToString());
			}
			return result;
		}

        

		public static List<object> consultaSelectLista(Configuracion configuracion, string selectSql)
		{
			List<object> list = new List<object>();
			using (OleDbConnection oleDbConnection = new OleDbConnection(UtilidadesBaseDatos.cadenaConexion(configuracion)))
			{
				OleDbCommand oleDbCommand = new OleDbCommand(selectSql, oleDbConnection);
				oleDbConnection.Open();
				OleDbDataReader oleDbDataReader = oleDbCommand.ExecuteReader();
				while (oleDbDataReader.Read())
				{
					object item = oleDbDataReader[0];
					list.Add(item);
				}
				oleDbDataReader.Close();
			}
			return list;
		}

		public static List<object> consultaSelectListaMultiple(Configuracion configuracion, int parametros, string selectSql)
		{
			List<object> list = new List<object>();
			using (OleDbConnection oleDbConnection = new OleDbConnection(UtilidadesBaseDatos.cadenaConexion(configuracion)))
			{
				OleDbCommand oleDbCommand = new OleDbCommand(selectSql, oleDbConnection);
				oleDbConnection.Open();
				OleDbDataReader oleDbDataReader = oleDbCommand.ExecuteReader();
				while (oleDbDataReader.Read())
				{
					object[] array = new object[parametros];
					for (int i = 0; i < parametros; i++)
					{
						array[i] = oleDbDataReader[i];
					}
					list.Add(array);
				}
				oleDbDataReader.Close();
			}
			return list;
		}

		public static int insertRow(Configuracion configuracion, string insertSQL)
		{
			int result = 0;
			using (OleDbConnection oleDbConnection = new OleDbConnection(UtilidadesBaseDatos.cadenaConexion(configuracion)))
			{
				OleDbCommand oleDbCommand = new OleDbCommand(insertSQL, oleDbConnection);
				oleDbCommand.Connection.Open();
				try
				{
					result = oleDbCommand.ExecuteNonQuery();
				}
				catch (Exception ex)
				{
					Console.WriteLine(ex.Message);
				}
			}
			return result;
		}


        public static String anadirBetween(String campo, DateTime fechaInicio, DateTime fechaFin)
        {
            return campo + " Between(DateSerial(" + fechaInicio.Year + "," + fechaInicio.Month + "," + fechaInicio.Day + ") + TimeSerial(0, 0, 0)) And(DateSerial(" + fechaFin.Year + ", " + fechaFin.Month + ", " + fechaFin.Day + ") + TimeSerial(23, 59, 59))";            
        }
	}
}
