using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL_Disconnected;
namespace BAL
{
    public class UserHelper
    {
        public void AddUser(int empno, String username, String password,out bool insertStatus)
        {
            UsersDAL dal=new UsersDAL();
            dal.InsertUsers(empno, username, password, out insertStatus);   
        }

        public void DeleteUser(int empno, out bool delStatus)

        {
            UsersDAL usersDAL =new UsersDAL();
            usersDAL.DeleteUsers(empno, out delStatus);
        }

        public void UpdateUser(int empno, string password, out bool upStatus)
        {
            UsersDAL dal = new UsersDAL();
            dal.UpdateUsers(empno, password, out upStatus);
        }
        public DataRow FindUser(int empno)

        {
            UsersDAL usersDAL = new UsersDAL();
           DataRow row= usersDAL.FindUsers(empno);
            return row;
        }

        public bool ValidateUser(string userid, string password)
        {
            UsersDAL dal = new UsersDAL();
            bool status = dal.ValidateUser(userid, password);
            return status;
        }
    }
}
