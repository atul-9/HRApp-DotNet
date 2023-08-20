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
		private String _Username;

		public String Username
		{
			get { return _Username; }
			set { _Username = value; }
		}
		private string _Password;

		public string Password
		{
			get { return _Password; }
			set { _Password = value; }
		}



	}
}
