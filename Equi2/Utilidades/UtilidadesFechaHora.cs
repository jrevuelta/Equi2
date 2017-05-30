using System;

namespace VentasDia.Utilidades

{
	public class UtilidadesFechaHora
	{
		public static bool fechasIguales(DateTime finicial, DateTime ffinal)
		{
			return finicial.Year == ffinal.Year && finicial.Month == ffinal.Month && finicial.Day == ffinal.Day;
		}

		public static int numeroDeHoraAbierto()
		{
			int result = 0;
			DateTime now = DateTime.Now;
			if (now.Hour > 0 && now.Hour < 10)
			{
				result = 1;
			}
			if (now.Hour >= 10 && now.Hour < 14)
			{
				result = now.Hour - 8;
			}
			if (now.Hour >= 14 && now.Hour < 17)
			{
				result = 5;
			}
			if (now.Hour >= 17 && now.Hour < 22)
			{
				result = now.Hour - 11;
			}
			if (now.Hour > 22)
			{
				result = 10;
			}
			return result;
		}

        public static DateTime obtenerMesAnterior(DateTime fecha)
        {
            int mes, ano,dia;

            dia = fecha.Day;
            mes = fecha.Month;
            ano = fecha.Year;

            if (fecha.Month == 1)
            {
                ano = fecha.Year - 1;
                mes = 12;
            }
            else
            {
                mes = fecha.Month - 1;
            }

            return (new DateTime(ano, mes, dia));
        }

        public static string obtenerFechaFormateada(DateTime fecha)
        {
            return ""+fecha.Day+"/"+fecha.Month+"/"+fecha.Year;
        }

        public static string obtenerFechaFormatoAmericano (DateTime fecha)
        {
            string aux = "";
            aux = aux + fecha.Year;
            if (fecha.Month < 10)
            {
                aux = aux + "0";
            }
            aux = aux + "" + fecha.Month;
            if (fecha.Day < 10)
            {
                aux = aux + "0";
            }
            aux = aux + "" + fecha.Day;

            return aux;
        }
	}
}
