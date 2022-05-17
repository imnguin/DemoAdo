using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class UserDBAccessLayer
    {
        Connection connection = new Connection();
        public List<UserEntities> GetAllUsers()
        {
            connection.connection();
            List<UserEntities> UserList = new List<UserEntities>();

            SqlCommand com = new SqlCommand("GetUsers", connection.con);
            com.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();

            connection.con.Open();
            da.Fill(dt);
            connection.con.Close();   
            foreach (DataRow dr in dt.Rows)
            {
                UserList.Add(
                    new UserEntities
                    {

                        Id = Convert.ToInt32(dr["Id"]),
                        FullName = Convert.ToString(dr["FullName"]),
                        UserName = Convert.ToString(dr["UserName"]),
                        PassWord = Convert.ToString(dr["PassWord"])
                    }
                    );
            }
            return UserList;
        }
        public bool AddUser(UserEntities obj)
        {
            connection.connection();
            SqlCommand com = new SqlCommand("AddNewUserDetails", connection.con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@FullName", obj.FullName);
            com.Parameters.AddWithValue("@UserName", obj.UserName);
            com.Parameters.AddWithValue("@PassWord", obj.PassWord);

            connection.con.Open();
            int i = com.ExecuteNonQuery();
            connection.con.Close();
            if (i >= 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool UpdateUser(int Id, UserEntities obj)
        {

            connection.connection();
            SqlCommand com = new SqlCommand("UpdateUsers", connection.con);

            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@Id", Id);
            com.Parameters.AddWithValue("@FullName", obj.FullName);
            com.Parameters.AddWithValue("@UserName", obj.UserName);
            com.Parameters.AddWithValue("@PassWord", obj.PassWord);
            connection.con.Open();
            int i = com.ExecuteNonQuery();
            connection.con.Close();
            if (i >= 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }  
        public bool DeleteUser(int Id)
        {

            connection.connection();
            SqlCommand com = new SqlCommand("DeleteUserId", connection.con);

            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@Id", Id);

            connection.con.Open();
            int i = com.ExecuteNonQuery();
            connection.con.Close();
            if (i >= 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
