﻿using BAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HRApp
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e) { 
            Console.WriteLine($"User: {txtUsername.Text} \n Password: {txtPassword.Text}");
            if (txtUsername.Text == "")
            {
                label1.Visible = true;
            }
            if (txtPassword.Text == "")
            {
                label2.Visible = true;


            }

            UserHelper helper= new UserHelper();
            bool status = helper.ValidateUser(txtUsername.Text, txtPassword.Text);
            if (status)
            {
                MessageBox.Show("Login");
            }
            else
            {
                MessageBox.Show("Incorrect");
            }

        }
private void clearBtn_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            UserMgt form2 = new UserMgt();
            form2.Show();

            
        }
    
           
        

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
