using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqCodeTemplate
{
    class Problem12
    {
        static void Main()
        {
            Product product = new Product();
            var products = product.GetProducts();
            var maxPrice = products.Max(p => p.ProMrp);
            Console.WriteLine("Maximum Product Price: " + maxPrice);
        }
    }
}