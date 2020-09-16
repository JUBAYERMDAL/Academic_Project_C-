using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Repository;
using Entity;

namespace App
{
    public partial class ManagerDashboardPage : Form
    {
        Login l;
        public ManagerDashboardPage(Login l)
        {
            InitializeComponent();

            this.l = l;
            WelcomeLabel.Text += l.Id;
        }

        private void DashboardBtn_Click(object sender, EventArgs e)
        {

        }

        private void ManagerDashboardPage_Load(object sender, EventArgs e)
        {
        }


        private void PlaceOrderMainBtn_Click(object sender, EventArgs e)
        {

            PlaceOrderPage hp = new PlaceOrderPage(l);
            this.Visible = false;
            hp.Visible = true;

        }
        private void ManageOrder_Click(object sender, EventArgs e)
        {
            ManageOrderPage mpr = new ManageOrderPage(l);
            this.Visible = false;
            mpr.Visible = true;
        }

        

        private void ChangePassword_Click(object sender, EventArgs e)
        {

        }

        private void LogoutBtn_Click(object sender, EventArgs e)
        {

            LoginForm hp = new LoginForm();
            this.Visible = false;
            hp.Visible = true;
        }

        private void OnFormClose(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void ManageOrder_Click_1(object sender, EventArgs e)
        {
            ManageOrderPage mpr = new ManageOrderPage(l);
            this.Visible = false;
            mpr.Visible = true;
        }
      

       
    }
}
