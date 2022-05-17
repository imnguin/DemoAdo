using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class Connection
    {
        public SqlConnection con;
        public void connection()
        {
            string constr = @"Data Source=DESKTOP-FAPVBHC\SQLEXPRESS;Initial Catalog=WebApi;Integrated Security=True";
            con = new SqlConnection(constr);
        }
    }
}
