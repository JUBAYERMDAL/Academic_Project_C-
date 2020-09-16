using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    public interface IProductRepo
    {
        bool InsertProduct(Product item);
        bool DeleteProduct(Product item);
        bool UpdateProduct(Product item);
        Product GetProduct(string productId);
        List<Product> GetAllProducts();


    }
}
