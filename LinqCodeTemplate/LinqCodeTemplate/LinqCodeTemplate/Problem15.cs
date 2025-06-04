using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqCodeTemplate
{
    class Problem15
    {
        static void Main()
        {
            Product product = new Product();
            var products = product.GetProducts();
            var anyBelow30 = products.Any(p => p.ProMrp < 30);
            Console.WriteLine(anyBelow30 ? "Yes,some of the products are below 30" : "None of the products are below 30");

        }
    }
}