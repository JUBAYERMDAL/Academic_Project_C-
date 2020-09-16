using Entity;
using Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace App
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void LoginBtn_Click(object sender, EventArgs e)
        {
            LoginRepo lr = new LoginRepo();
            string id = UserTB.Text;
            string password = PassTB.Text;

            Login l = lr.GetUser(id, password);

            if (l != null)
            {
                if (l.Role == 0)
                {

                    DashboardPage hp = new DashboardPage(l);
                    this.Visible = false;
                    hp.Visible = true;
                }

                else if (l.Role == 1)
                {

                    ManagerDashboardPage hp = new ManagerDashboardPage(l);
                    this.Visible = false;
                    hp.Visible = true;
                }

                else if (l.Role == 2)
                {

                    CheffDashboardPage hp = new CheffDashboardPage(l);
                    this.Visible = false;
                    hp.Visible = true;
                }
                else
                {
                    MessageBox.Show("Access Denied User");
                }
            }
            else
            {
                MessageBox.Show("Invalid User");
            }

        }


        private void UserTB_Enter(object sender, EventArgs e)
        {
            if (UserTB.Text == "Username or ID")
            {
                UserTB.Text = "";
            }
        }

        private void UserTB_Leave(object sender, EventArgs e)
        {
            if (UserTB.Text == "")
            {
                UserTB.Text = "Username or ID";
            }
        }

        private void PassTB_Enter(object sender, EventArgs e)
        {
            if (PassTB.Text == "Password")
            {
                PassTB.Text = "";
            }
        }

        private void PassTB_Leave(object sender, EventArgs e)
        {
            if (PassTB.Text == "")
            {
                PassTB.Text = "Password";
            }
        }

        private void ExitBtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void OnFormClose(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void ExitBtn_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }

       
    }
}
