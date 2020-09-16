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
    public class ProductRepo : IProductRepo
    {
        DatabaseConnectionClass dcc;
        public ProductRepo()
        {
            dcc = new DatabaseConnectionClass();
        }

        public bool InsertProduct(Product item)
        {
            string query = "INSERT into Products VALUES ('" + item.ProductId + "', '" + item.Name + "', " + item.Price + ",'" + item.Description + "' )";
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
        public bool DeleteProduct(Product item)
        {


            string query = "DELETE from Products WHERE ProductId = '" + item.ProductId + "'";
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

        public bool UpdateProduct(Product item)
        {
            string query = "UPDATE Products SET Name = '" + item.Name + "', Price = " + item.Price + ", Description = '" + item.Description + "' WHERE ProductId = '" + item.ProductId + "'";
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

        public Product GetProduct(string productId)
        {
            Product item = null;
            string query = "SELECT * from Products WHERE ProductId = '" + productId + "'";

            dcc.ConnectWithDB();
            SqlDataReader sdr = dcc.GetData(query);

            while (sdr.Read())
            {
                item = new Product();
                item.ProductId = sdr["ProductId"].ToString();
                item.Name = sdr["Name"].ToString();
                item.Price = Convert.ToDouble(sdr["Price"].ToString());
                item.Description = sdr["Description"].ToString();
            }

            dcc.CloseConnection();
            return item;
        }




        public List<Product> GetAllProducts()
        {
            List<Product> listOfProduct = new List<Product>();
            string query ="SELECT * from Products";


            dcc.ConnectWithDB();
            SqlDataReader sdr = dcc.GetData(query);

            while (sdr.Read())
            {

                Product item = new Product();
                item.ProductId = sdr["ProductId"].ToString();
                item.Name = sdr["Name"].ToString();
                item.Price = Convert.ToDouble(sdr["Price"].ToString());
                item.Description = sdr["Description"].ToString();

                listOfProduct.Add(item);
            }

            dcc.CloseConnection();

            return listOfProduct;
        }


    }
}
