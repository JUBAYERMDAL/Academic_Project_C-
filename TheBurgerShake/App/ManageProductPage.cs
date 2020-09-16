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
    public partial class ManageProductPage : Form
    {
        Login l;
        ProductRepo pr;
        public ManageProductPage(Login l)
        {
            InitializeComponent();
            this.l = l;
            WelcomeLabel.Text += l.Id;
            this.pr = new ProductRepo();
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
        private void ManageProductPage_Load(object sender, EventArgs e)
        {
            this.ProductRefreshBtn_Click(sender, e);
        }

        private void ExitBtn_Click(object sender, EventArgs e)
        {
            DashboardPage hp = new DashboardPage(l);
            this.Visible = false;
            hp.Visible = true;
        }

       

        private void ProductLoadBtn_Click(object sender, EventArgs e)
        {
            string productId = this.ProductIdTB.Text;
            Product item = pr.GetProduct(productId);

            if (item == null)
            {
                MessageBox.Show("Invalid ID");
            }
            else
            {
                this.ProductNameTB.Text = item.Name;
                this.ProductPriceTB.Text = item.Price + "";
                this.ProductDescTB.Text = item.Description;
                this.ProductRefreshBtn.Enabled = true;
                this.ProductLoadBtn.Enabled = false;
                this.ProductInsertBtn.Enabled = false;
                this.ProductUpdateBtn.Enabled = true;
                this.ProductDeleteBtn.Enabled = true;
                this.ProductIdTB.Enabled = false;
            }
        }

        private void ProductRefreshBtn_Click(object sender, EventArgs e)
        {
            this.ProductIdTB.Text = "";
            this.ProductNameTB.Text = "";
            this.ProductPriceTB.Text = "";
            this.ProductDescTB.Text = "";


            this.ProductRefreshBtn.Enabled = false;
            this.ProductLoadBtn.Enabled = true;
            this.ProductInsertBtn.Enabled = true;
            this.ProductUpdateBtn.Enabled = false;
            this.ProductDeleteBtn.Enabled = false;

            this.ProductIdTB.Enabled = true;
        }

        private void ProductInsertBtn_Click(object sender, EventArgs e)
        {
            Product item = new Product();
            item.ProductId = this.ProductIdTB.Text;
            item.Name = this.ProductNameTB.Text;
            double price = Convert.ToDouble(this.ProductPriceTB.Text);
            item.Price = price;
            item.Description = this.ProductIdTB.Text;

            
            try
            {
             
                if (pr.InsertProduct(item))
                {
                        MessageBox.Show("Product Added");
                        this.ProductRefreshBtn_Click(sender, e);

                }
                else
                {
                    MessageBox.Show("Can Not Add" + item.ProductId);
                }
            }
            catch (Exception exp)
            {
                MessageBox.Show("Invalid Data" + exp.StackTrace);

            }
        }

        private void ProductUpdateBtn_Click(object sender, EventArgs e)
        {
            Product item = new Product();
            item.ProductId = this.ProductIdTB.Text;
            item.Name = this.ProductNameTB.Text;
            double price = Convert.ToDouble(this.ProductPriceTB.Text);
            item.Price = price;
            item.Description = this.ProductIdTB.Text;

            if (pr.UpdateProduct(item))
            {
                MessageBox.Show("Product Updated");
                this.ProductRefreshBtn_Click(sender, e);
            }
            else
            {
                MessageBox.Show("Can NOT Update");
            }
        }

        private void ProductDeleteBtn_Click(object sender, EventArgs e)
        {
            Product item = new Product();
            item.ProductId = this.ProductIdTB.Text;


            if (pr.DeleteProduct(item))
            {
                MessageBox.Show("Product Removed");
                this.ProductRefreshBtn_Click(sender, e);
            }
            else
            {
                MessageBox.Show("Can Not Remove");
            }
        }


    }
}
