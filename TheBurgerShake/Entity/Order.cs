using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entity
{
    public class Order
    {
        string id;
        string productId;
        double totalPrice;
        double discount;
        double paid;
        int orderStatus;

        public string Id
        {
            get { return id; }
            set { id = value; }
        }

        public string ProductId
        {
            get { return productId; }
            set { productId = value; }
        }

        public double TotalPrice
        {
            get { return totalPrice; }
            set { totalPrice = value; }
        }
        public double Discount
        {
            get { return discount; }
            set { discount = value; }
        }
        public double Paid
        {
            get { return paid; }
            set { paid = value; }
        }
        public int OrderStatus
        {
            get { return orderStatus; }
            set { orderStatus = value; }
        }

    }


}
