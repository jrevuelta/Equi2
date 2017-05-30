using System;
using System.Linq;

namespace VentasDia.Utilidades
{
    internal class UtilidadesNumericas
    {
        public static bool IsNumber(string value)
        {
            return value.All(new Func<char, bool>(char.IsDigit));
        }
    }
}
