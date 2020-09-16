using Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Repository;

namespace App
{

    public partial class DashboardPage : Form
    {

        Login l;
        public DashboardPage(Login l)
        {
            InitializeComponent();
            this.l = l;
            WelcomeLabel.Text += l.Id;
        }

        private void OnFormClose(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }


        private void DashboardBtn_Click(object sender, EventArgs e)
        {

        }
        private void ManageEmpBtn_Click(object sender, EventArgs e)
        {
            ManageEmployeePage hp = new ManageEmployeePage(l);
            this.Visible = false;
            hp.Visible = true;
        }
        private void ManageProduct_Click(object sender, EventArgs e)
        {
            ManageProductPage hp = new ManageProductPage(l);
            this.Visible = false;
            hp.Visible = true;
        }


        private void ManageTable_Click(object sender, EventArgs e)
        {
            ManageTablePage hp = new ManageTablePage(l);
            this.Visible = false;
            hp.Visible = true;
        }

        private void ChangePassword_Click(object sender, EventArgs e)
        {
            ChangePasswordPage hp = new ChangePasswordPage();
            this.Visible = false;
            hp.Visible = true;
        }

        private void LogoutBtn_Click(object sender, EventArgs e)
        {
            LoginForm hp = new LoginForm();
            this.Visible = false;
            hp.Visible = true;
        }

        private void DashboardPage_Load(object sender, EventArgs e)
        {

        }
    }
}
