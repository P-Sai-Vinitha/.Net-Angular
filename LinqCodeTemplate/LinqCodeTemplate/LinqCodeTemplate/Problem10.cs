using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqCodeTemplate
{
    class Problem10
    {
        static void Main()
        {
            Product product = new Product();
            var products = product.GetProducts();
            int totalProducts = products.Count();
            Console.WriteLine("Total number of products: " + totalProducts);
        }
    }
}