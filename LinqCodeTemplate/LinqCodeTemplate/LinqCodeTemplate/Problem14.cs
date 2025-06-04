using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqCodeTemplate
{
    class Problem14
    {
        static void Main()
        {
            Product product = new Product();
            var products = product.GetProducts();
            var allBelow30 = products.All(p => p.ProMrp < 30);
            Console.WriteLine(allBelow30 ? "All products are below 30" : "All products are not below 30");

        }
    }
}