using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace Equi2_Core.Utilidades
{
    public class UtilidadesTablas
    {
        /// <summary>
        /// Crea la estructura de una tabla html a partir de su número de campos y de sus cabeceras
        /// </summary>
        /// <param name="tabla">Table - es el objeto contenedor de la información</param>
        /// <param name="nCampos">int - número de columnas que va a tener la tabla</param>
        /// <param name="cabeceras">string[] - contiene los textos de las cabeceras de la tabla</param>
        /// <returns>Table - Tabla html con la información creada</returns>
        public static Table esqueletoTabla(Table tabla, int nCampos,string []cabeceras)
        {
            TableHeaderRow tableHeaderRow = new TableHeaderRow();
            for (int i = 0; i < nCampos; i++)
            {
                TableHeaderCell thc = new TableHeaderCell();
                thc.Text = cabeceras[i];
                tableHeaderRow.Cells.Add(thc);
            }
            tableHeaderRow.TableSection = TableRowSection.TableHeader;
            tabla.Rows.Add(tableHeaderRow);

            return tabla;
        }
    }
}
