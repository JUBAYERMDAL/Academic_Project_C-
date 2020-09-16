using Entity;
using Interfaces;
using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Repository
{
    public class OrderRepo : IOrderRepo
    {
        DatabaseConnectionClass dcc;
        public OrderRepo()
        {
            dcc = new DatabaseConnectionClass();
        }

        public bool InsertOrder(Order order)
        {
            string query = "INSERT into Orders VALUES ('" + order.Id + "', '" + order.ProductId + "', " + order.TotalPrice + ", " + order.Discount + "," + order.Paid + "," + order.OrderStatus + " )";
            try
            {
                dcc.ConnectWithDB();
                int n = dcc.ExecuteSQL(query);

                dcc.CloseConnection();
                return true;
            }
            catch (Exception exp)
            {
                return false;
            }
        }
        public bool DeleteOrder(Order order)
        {


            string query = "DELETE from Orders WHERE OrderId = '" + order.Id + "'";
            try
            {
                dcc.ConnectWithDB();
                int n = dcc.ExecuteSQL(query);
                dcc.CloseConnection();
                return true;
            }
            catch (Exception exp)
            {
                return false;
            }
        }

        public bool UpdateOrder(Order order)
        {
           // string query = "UPDATE Orders SET Name = '" + order.Name + "', Price = " + order.Price + ", Description = '" + order.Description + "' WHERE ProductId = '" + order.ProductId + "'";
            try
            {
                dcc.ConnectWithDB();
                //int n = dcc.ExecuteSQL(query);
                dcc.CloseConnection();
                return true;
            }
            catch (Exception exp)
            {
                return false;
            }
        }

        public Order GetOrder(string Id)
        {
            Order order = null;
            string query = "SELECT * from Orders WHERE Id = '" + Id + "'";

            dcc.ConnectWithDB();
            SqlDataReader sdr = dcc.GetData(query);

            while (sdr.Read())
            {
                order = new Order();
                order.Id = sdr["Id"].ToString();
                order.ProductId = sdr["ProductId"].ToString();
                order.TotalPrice = Convert.ToDouble(sdr["TotalPrice"].ToString());
                order.Discount = Convert.ToDouble(sdr["Discount"].ToString());
                order.Paid = Convert.ToDouble(sdr["Paid"].ToString());
                order.OrderStatus = Convert.ToInt32(sdr["OrderStatus"].ToString());
            }

            dcc.CloseConnection();
            return order;
        }



        public List<Order> GetAllOrders()
        {
            List<Order> listOfOrder = new List<Order>();
            string query = "SELECT * from Order";


            dcc.ConnectWithDB();
            SqlDataReader sdr = dcc.GetData(query);

            while (sdr.Read())
            {

                Order order = new Order();
                order = new Order();
                order.Id = sdr["Id"].ToString();
                order.ProductId = sdr["ProductId"].ToString();
                order.TotalPrice = Convert.ToDouble(sdr["TotalPrice"].ToString());
                order.Discount = Convert.ToDouble(sdr["Discount"].ToString());
                order.Paid = Convert.ToDouble(sdr["Paid"].ToString());
                order.OrderStatus = Convert.ToInt32(sdr["Status"].ToString());

                listOfOrder.Add(order);
            }

            dcc.CloseConnection();

            return listOfOrder;
        }


    }
}
