using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DataMigrationWeb
{
    public class TableMigrationConfig
    {
        public string DestinationTable { get; set; }
        public string SelectQuery { get; set; }
    }
}