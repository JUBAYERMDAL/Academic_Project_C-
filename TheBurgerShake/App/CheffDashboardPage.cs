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
    public partial class CheffDashboardPage : Form
    {
        Login l;
        public CheffDashboardPage(Login l)
        {
            InitializeComponent();

            this.l = l;
            WelcomeLabel.Text += l.Id;
        }

        private void CheffDashboardPage_Load(object sender, EventArgs e)
        {

        }

        private void LogoutBtn_Click(object sender, EventArgs e)
        {

            LoginForm hp = new LoginForm();
            this.Visible = false;
            hp.Visible = true;
        }
    }
}
