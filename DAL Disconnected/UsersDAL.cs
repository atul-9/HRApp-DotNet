using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySqlConnector;

namespace DAL_Disconnected
{
    public class UsersDAL
    {
        public void InsertUsers(int empno,String username,String password,out bool insertStatus)
        {
            string cnstring = "server=localhost;userid=root;password=xyz;database=employeee";
            MySqlConnection cn = new MySqlConnection(cnstring);
            MySqlDataAdapter da = new MySqlDataAdapter("select * from users;", cn);
            DataSet ds= new DataSet("My DataSet");
            da.Fill(ds, "users");

            DataRow drow=ds.Tables["users"].NewRow();
            drow["Empno"] = empno;
            drow["UserID"] = username;
            drow["Password"] = password;
            ds.Tables["users"].Rows.Add(drow);
            MySqlCommandBuilder bldr = new MySqlCommandBuilder(da);
            da.Update(ds.Tables["users"]);
            insertStatus = true; 
            


        }
        public void DeleteUsers(int empno, out bool delStatus)
        {
            string cnstring = "server=localhost;userid=root;password=xyz;database=employeee";
            MySqlConnection cn = new MySqlConnection(cnstring);
            MySqlDataAdapter da = new MySqlDataAdapter("select * from users;", cn);
            DataSet ds = new DataSet("My DataSet");
            da.MissingSchemaAction = MissingSchemaAction.AddWithKey;
            da.Fill(ds, "users");

            DataRow drow = ds.Tables["users"].Rows.Find(empno);
            if (drow!=null)
            {
                drow.Delete();
                MySqlCommandBuilder bldr = new MySqlCommandBuilder(da);
                da.Update(ds.Tables["users"]);
                delStatus = true;
            }
            else
            {
                delStatus=false;
            }




        }
        public void UpdateUsers(int empno, string password, out bool upStatus)
        {
            string cnstring = "server=localhost;userid=root;password=xyz;database=employeee";
            MySqlConnection cn = new MySqlConnection(cnstring);
            MySqlDataAdapter da = new MySqlDataAdapter("select * from users;", cn);
            DataSet ds = new DataSet("My DataSet");
            da.MissingSchemaAction = MissingSchemaAction.AddWithKey;
            da.Fill(ds, "users");

            DataRow drow = ds.Tables["users"].Rows.Find(empno);
            if (drow != null)
            {
                drow["password"]=password;
                MySqlCommandBuilder bldr = new MySqlCommandBuilder(da);
                da.Update(ds.Tables["users"]);
                upStatus = true;

            }
            else
            {
                upStatus=false;
            }
        }
        public DataRow FindUsers(int empno)
        {
            string cnstring = "server=localhost;userid=root;password=xyz;database=employeee";
            MySqlConnection cn = new MySqlConnection(cnstring);
            MySqlDataAdapter da = new MySqlDataAdapter("select * from users;", cn);
            DataSet ds = new DataSet("My DataSet");
            da.MissingSchemaAction = MissingSchemaAction.AddWithKey;
            da.Fill(ds, "users");

            DataRow drow = ds.Tables["users"].Rows.Find(empno);
            return drow;

        }
        public void ShowAllUsers()
        {

        }
        public bool ValidateUser(string username, string password)
        {
            string cnstring = "server=localhost;userid=root;password=xyz;database=employeee";
            MySqlConnection cn = new MySqlConnection(cnstring);
            MySqlCommand cmd = new MySqlCommand("sp_validateData", cn);
            int user_count = 0;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_userid", username);
            cmd.Parameters.AddWithValue("p_password", password);
            cmd.Parameters.Add("user_count",MySqlDbType.Int32);
            cn.Open();
            //cmd.Parameters[2].ParameterName = "user_count";
            //cmd.Parameters[2].Direction = ParameterDirection.Output;
            cmd.ExecuteNonQuery();

            user_count = Convert.ToInt32(cmd.Parameters[2].Value);
            cn.Close();
            if(user_count != 0)
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
