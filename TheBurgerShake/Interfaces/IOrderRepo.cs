using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    public interface IOrderRepo
    {
        bool InsertOrder(Order item);
        bool DeleteOrder(Order item);
        bool UpdateOrder(Order item);
        Order GetOrder(string Id);
        List<Order> GetAllOrders();

    }
}
