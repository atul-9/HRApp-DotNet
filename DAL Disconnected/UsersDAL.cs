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
        public void UpdateUsers(int empno, string password)
        {

        }
        public void DeleteUsers(int empno)
        {

        }
        public void FindUsers(int empno)
        {

        }
        public void ShowAllUsers()
        {

        }
        public void ValidateUser(string username, string password)
        {

        }
    }
}
