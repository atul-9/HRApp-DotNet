using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BAL;

namespace HRApp
{
    public partial class UserMgt : Form
    {
        public UserMgt()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            UserHelper helper= new UserHelper();
            UserBAL bal = new UserBAL();
            bal.EmpNo = Convert.ToInt32(textBox1.Text);
            bal.Username = textBox2.Text;
            bal.Password = textBox3.Text;
            helper.AddUser(bal.EmpNo,bal.Username, bal.Password, out bool status);
            if (status)
            {
                MessageBox.Show("User inserted");
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void UserCreation_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            UserHelper helper = new UserHelper();
            helper.UpdateUser(Convert.ToInt32(textBox1.Text),textBox3.Text ,out bool status);
            if (status)
            {
                MessageBox.Show("User Updated");
            }
            else
            {
                MessageBox.Show("Not able to Update");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            UserHelper helper = new UserHelper();
            helper.DeleteUser(Convert.ToInt32(textBox1.Text), out bool status);
            if (status)
            {
                MessageBox.Show("User Deleted");
            }
            else
            {
                MessageBox.Show("Not able to Delete");
            }

        }

        private void button6_Click(object sender, EventArgs e)
        {
            UserHelper helper = new UserHelper();
            DataRow data= helper.FindUser(Convert.ToInt32(textBox1.Text));
            if (data == null) {
                MessageBox.Show("User Not Found");
            }
            else
            {
                textBox2.Text = data["userID"].ToString();
                textBox3.Text = data["password"].ToString();
            }
        }
    }
}
