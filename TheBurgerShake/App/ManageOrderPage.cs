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
    public partial class ManageOrderPage : Form
    {

        OrderRepo or;
        Login l;
        Order orr;
        ProductRepo pr;

        public ManageOrderPage(Login l)
        {
            InitializeComponent();
            this.pr = new ProductRepo();
            this.or = new OrderRepo();
            this.orr = new Order();
            this.l = new Login();

            this.l = l;
            WelcomeLabel.Text += l.Id;
        }

        private void LoadBtn_Click(object sender, EventArgs e)
        {
            string orderId = this.OrdertIdTB.Text;
            Order orr = or.GetOrder(orderId);

            if (orr == null)
            {
                MessageBox.Show("Invalid ID");
            }
            else
            {
                /*
                foreach (Order orr in Order)
                {
                    Order order = new Order();

                    int n = CartGirdView.Rows.Add();
                    CartGirdView.Rows[n].Cells[0].Value = order.ProductId;
                    CartGirdView.Rows[n].Cells[1].Value = order.TotalPrice;
                    CartGirdView.Rows[n].Cells[2].Value = order.Discount;
                    CartGirdView.Rows[n].Cells[3].Value = order.Paid;
                    CartGirdView.Rows[n].Cells[4].Value = order.OrderStatus;

                    MessageBox.Show("Please Select " + order.ProductId);
                }
                 * */

            }
        }

        private void ManageOrder_Click(object sender, EventArgs e)
        {
            ManageOrderPage mpr = new ManageOrderPage(l);
            this.Visible = false;
            mpr.Visible = true;

        }

        private void DashboardBtn_Click(object sender, EventArgs e)
        {

            ManagerDashboardPage mpr = new ManagerDashboardPage(l);
            this.Visible = false;
            mpr.Visible = true;

        }

        private void PlaceOrderMainBtn_Click(object sender, EventArgs e)
        {
            PlaceOrderPage mpr = new PlaceOrderPage(l);
            this.Visible = false;
            mpr.Visible = true;
        }

        private void ChangePassword_Click(object sender, EventArgs e)
        {
        }

        private void ManageOrderPage_Load(object sender, EventArgs e)
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
