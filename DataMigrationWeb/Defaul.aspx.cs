using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace DataMigrationWeb
{
    public partial class Defaul : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Al cargar la página (GET / refresco)
                ClearControls();
            }
        }

        protected void btnMigrate_Click(object sender, EventArgs e)
        {
            if (txtTabla.Text == "") { lblStatus.Text = "Tabla Requerida"; return; }
            if (txtOriginQuery.Text == "") { lblStatus.Text = "Consulta Requerida"; return; }
            migrate();
        }

        private void migrate()
        {
            try
            {
                var table = new TableMigrationConfig
                {
                    DestinationTable = txtTabla.Text,
                    SelectQuery = txtOriginQuery.Text
                };

                MigrationService.MigrateTable(table);

                lblStatus.Text = "Migration completed successfully. Tabla: " + txtTabla.Text + " Consulta: " + txtOriginQuery.Text;
                txtTabla.Text = "";
                txtOriginQuery.Text = "";
            }
            catch (Exception ex)
            {
                lblStatus.Text = ex.ToString();
            }
        }

        private void ClearControls()
        {
            txtTabla.Text = "";
            txtOriginQuery.Text = "";
            lblStatus.Text = "";
        }

    }
}