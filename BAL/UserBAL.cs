using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL
{
    public class UserBAL
    {
		private int _Empno;

		public int EmpNo
		{
			get { return _Empno; }
			set { _Empno = value; }
		}
		private String _UserID;

		public String UserID
		{
			get { return _UserID; }
			set { _UserID = value; }
		}
		private string _Password;

		public string Pasword
		{
			get { return _Password; }
			set { _Password = value; }
		}



	}
}
