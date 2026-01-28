using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace DataMigrationWeb
{
    public static class MigrationService
    {
        public static void MigrateTable(TableMigrationConfig config)
        {

            var sourceConnStr = ConfigurationManager.ConnectionStrings["SourceDb"].ConnectionString;
            var destConnStr = ConfigurationManager.ConnectionStrings["DestinationDb"].ConnectionString;

            try
            {
                using (var sourceConn = new SqlConnection(sourceConnStr))
                using (var destConn = new SqlConnection(destConnStr))
                {
                    sourceConn.Open();
                    destConn.Open();

                    using (var cmd = new SqlCommand(config.SelectQuery, sourceConn))
                    {
                        cmd.CommandTimeout = 0;

                        using (var reader = cmd.ExecuteReader(CommandBehavior.SequentialAccess))
                        using (var bulk = new SqlBulkCopy(destConn,
                            SqlBulkCopyOptions.TableLock |
                            SqlBulkCopyOptions.UseInternalTransaction,
                            null))
                        {
                            bulk.BatchSize = 50000;
                            bulk.BulkCopyTimeout = 0;
                            bulk.DestinationTableName = config.DestinationTable;

                            bulk.WriteToServer(reader);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                var logError = new LogError();
                var messageError = logError.IngestBulkData(ex);

                throw new ApplicationException(messageError, ex);
            }
        }
    }
}