using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DataMigrationWeb
{
    public class LogError
    {
        public string IngestBulkData(Exception ex)
        {
            // Errores comunes de SqlBulkCopy
            if (ex.Message.Contains("Received an invalid column length"))
                return "Uno o más campos tienen datos más largos de lo permitido.";

            if (ex.Message.Contains("The given ColumnMapping"))
                return "La estructura de los datos no coincide con la tabla destino.";

            if (ex.Message.Contains("Cannot insert the value NULL"))
                return "Faltan datos obligatorios en una o más columnas.";

            if (ex.Message.Contains("Violation of PRIMARY KEY"))
                return "Existen registros duplicados que no se pueden insertar.";

            if (ex.Message.Contains("String or binary data would be truncated"))
                return "Algunos datos exceden el tamaño permitido en la base de datos.";

            /*if (ex. == 2627 || ex.Number == 2601)
                return "Se encontraron registros duplicados.";

            if (ex.Number == 547)
                return "El registro viola una relación entre tablas.";*/

            // Mensaje genérico
            return "Ocurrió un error al procesar la migración. Verifique los datos de origen." + ex.Message;
        }
    }
}