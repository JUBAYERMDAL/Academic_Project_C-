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
    public partial class PlaceOrderPage : Form
    {
        OrderRepo or;


        double totalPrice = 0;
        double subTotal = 0;
        string id;
        string name;



        double sum = 0;
        double discount = 0;
        double cashReceived = 0;
        string price ;
        Login l;
        ProductRepo pr;
        public PlaceOrderPage(Login l)
        {
            this.pr = new ProductRepo();
            InitializeComponent();
            this.or = new OrderRepo();

            this.l = l;
            WelcomeLabel.Text += l.Id;
        }

        private void PlaceOrderPage_Load(object sender, EventArgs e)
        {
            List<Product> listOfProduct = pr.GetAllProducts();

            foreach (Product item in listOfProduct)
            {
                //MessageBox.Show("Invalid ID" + item);
                SelectProductTB.Items.Add(item.ProductId+ "> " +item.Name + " < " + item.Price);
                ResetBtn_Click(sender, e);
                
            }

        }

        private void ProductPriceTB_TextChanged(object sender, EventArgs e)
        {

        }

        private void AddToCartBtn_Click(object sender, EventArgs e)
        {
            

            if (SelectProductTB.Text != "" && ProductQuantityTB.Text != "")
            {
                GetId();
                GetPrice();
                int n = CartGirdView.Rows.Add();
                string quantity = this.ProductQuantityTB.Text;
                double total = Convert.ToDouble(price) * Convert.ToDouble(quantity);

                CartGirdView.Rows[n].Cells[0].Value = id;
                CartGirdView.Rows[n].Cells[1].Value = name;
                CartGirdView.Rows[n].Cells[2].Value = price;
                CartGirdView.Rows[n].Cells[3].Value = quantity;
                CartGirdView.Rows[n].Cells[4].Value = total.ToString();
                CartGirdView.Rows[n].Cells[5].Value = "Remove";
                CalcTotal();
                ResetBtn_Click(sender, e);

                this.ResetBtn.Enabled = true;
            }

            else 
            {
                MessageBox.Show("Please Select fields");
            }
        }

        private void ResetBtn_Click(object sender, EventArgs e)
        {
            this.ProductQuantityTB.Text = "";
            this.SelectProductTB.Text = "";
            this.ProductDescTB.Text = "";
            this.ResetBtn.Enabled = false;

        }

        private void SelectProduct_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void OnFormClose(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void GetPrice() 
        {
            string sub1 = SelectProductTB.Text;
            string sub2 = "<";

            bool b = sub1.Contains(sub2);
            
            if (b)
            {
                int index = sub1.IndexOf(sub2);
                price = sub1.Substring(index+1);
                //MessageBox.Show("" + price);
               
            } 
        }


        private void GetId()
        {
            string sub1 = SelectProductTB.Text;
            string sub2 = ">";
            string sub3 = "<";

            bool b = sub1.Contains(sub2);

            if (b)
            {
                int index = sub1.IndexOf(sub2);
                id = sub1.Substring(0, index);

                int index2 = sub1.IndexOf(sub3)-3;

                name = sub1.Substring(index+1, index2);

               // MessageBox.Show(""+id +name);
            }
        }

        private void CalcTotal()
        {

            double calcPrice = 0;

            for (int i = 0; i < CartGirdView.Rows.Count; i++)
            {
                calcPrice += Convert.ToDouble(CartGirdView.Rows[i].Cells[4].Value);
                this.TotalTB.Text = calcPrice.ToString();

               // totalPrice = Convert.ToDouble(this.TotalTB.Text);
            }
            totalPrice = calcPrice;
           

        }

 

        private void CashCalculation()
        {
            cashReceived = Convert.ToDouble(this.RecievedTB.Text);
            if (cashReceived > subTotal)
            {
                double topay = subTotal - cashReceived;
                this.PayTB.Text = topay.ToString();
            }
            else
            {
                MessageBox.Show("Customer Have To Pay More Money");
                this.PayTB.Text = "0";
            }
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void CartGirdView_Enter(object sender, DataGridViewCellEventArgs e)
        {

          
        }

        private void DicountTB_Enter(object sender, EventArgs e)
        {
        }

        private void RecievedTV_LEave(object sender, EventArgs e)
        {
            //Calculation();
        }

        private void DiscountTB_Leave(object sender, EventArgs e)
        {
            discount = Convert.ToDouble(this.DiscountTB.Text);
            if (totalPrice > discount)
            {
                subTotal = totalPrice - discount;

                //MessageBox.Show("" + totalPrice);
                SubTotalTB.Text = subTotal.ToString();
            }
            else
            {
                MessageBox.Show("Discount Is Greater Then Total Price");
                this.DiscountTB.Text = "0";
            }
        }

        private void RecievedTB_Leave(object sender, EventArgs e)
        {
            CashCalculation();
        }

        private void PlaceOrder_Click(object sender, EventArgs e)
        {
            bool b = false;
            try
            {

                int p = new Random().Next(9999) + 1000;

                for (int i = 0; i < CartGirdView.Rows.Count; i++)
                {
                    Order order = new Order();
                    order.Id = p + "";
                    order.ProductId = CartGirdView.Rows[i].Cells[0].Value.ToString();
                    order.TotalPrice = Convert.ToDouble(TotalTB.Text);
                    order.Discount = Convert.ToDouble(DiscountTB.Text);
                    order.Paid = Convert.ToDouble(SubTotalTB.Text);
                    double customerPaid = Convert.ToDouble(RecievedTB.Text);
                    order.OrderStatus = 0;
                    if (order.Paid > customerPaid)
                    {
                       MessageBox.Show("Cousomer Can't Have Due");
                    }

                    else
                    {
                         b = true;
                         or.InsertOrder(order);
                    }

                }

                if (b == true)
                {
                    MessageBox.Show("Order Placed");
                    ResetCartBtn_Click(sender, e);
                }
                else
                {
                    MessageBox.Show("Something Wrong");
                }
            }
            catch
            {
                MessageBox.Show("Something Wrong");
            }

           
        }

        private void ResetCartBtn_Click(object sender, EventArgs e)
        {
            CartGirdView.Rows.Clear();
            CartGirdView.Refresh();

            TotalTB.Text= "0";
            SubTotalTB.Text= "";
            RecievedTB.Text= "0";
            DiscountTB.Text= "0";
            PayTB.Text = "0";
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

        private void LogoutBtn_Click(object sender, EventArgs e)
        {

            LoginForm hp = new LoginForm();
            this.Visible = false;
            hp.Visible = true;
        }
    }
}