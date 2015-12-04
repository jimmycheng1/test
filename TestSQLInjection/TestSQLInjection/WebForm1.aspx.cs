using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
namespace TestSQLInjection
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string TaskID = "T";
            string strSQL_P = @"SELECT ScanRequests.TaskID FROM ScanRequestswith (nolock) WHERE 1=1 ";
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["CxDB"].ConnectionString;
            DataSet ds = new DataSet();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(strSQL_P, con);                
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
            }
        }
    }
}