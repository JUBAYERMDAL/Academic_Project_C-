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
    public partial class ManageTablePage : Form
    {
        Login l;
        TableRepo tr;
        Table t;

        public ManageTablePage(Login l)
        {

            InitializeComponent();

            this.tr = new TableRepo();

            this.t = new Table();

            this.l = l;
            WelcomeLabel.Text += l.Id;
        }

        private void OnFormClose(object sender, FormClosedEventArgs e)
        {
            Application.Exit();

        }

        private void DashboardBtn_Click(object sender, EventArgs e)
        {
            DashboardPage hp = new DashboardPage(l);
            this.Visible = false;
            hp.Visible = true;
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
            this.TableRefreshBtn_Click(sender, e);
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

        private void TableLoadBtn_Click(object sender, EventArgs e)
        {
            int tableId = Convert.ToInt32(this.TableIdTB.Text);
            //MessageBox.Show(""+tableId);
            Table table = tr.GetTable(tableId);

            if (table == null)
            {
                MessageBox.Show("Invalid ID");
            }
            else
            {
                this.TableNosTB.Text = table.NumberOfSeats + "";
                this.TableStatusTB.Text = table.Status + "";
                
                this.TableRefreshBtn.Enabled = true;
                this.TableLoadBtn.Enabled = false;
                this.TableInsertBtn.Enabled = false;
                this.TableUpdateBtn.Enabled = true;
                this.TableDeleteBtn.Enabled = true;
                this.TableIdTB.Enabled = false;
            }
        }

        private void TableInsertBtn_Click(object sender, EventArgs e)
        {

        }

        private void TableUpdateBtn_Click(object sender, EventArgs e)
        {

        }

        private void TableDeleteBtn_Click(object sender, EventArgs e)
        {

        }

        private void TableRefreshBtn_Click(object sender, EventArgs e)
        {

        }

        private void ExitBtn_Click(object sender, EventArgs e)
        {

        }

        private void ManageTablePage_Load(object sender, EventArgs e)
        {

        }
    }
}
