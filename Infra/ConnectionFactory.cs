using System.Configuration;
using System.Data.SqlClient;

namespace Blog.Infra
{
    public class ConnectionFactory
    {
        public static SqlConnection CriaConexao()
        {
            string stringConnection = ConfigurationManager.ConnectionStrings["blog"].ConnectionString;
            SqlConnection cnx = new SqlConnection(stringConnection);
            cnx.Open();
            return cnx;
        }
    }
}