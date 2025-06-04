using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqCodeTemplate
{
    class Problem4
    {
        static void Main()
        {
            Product product = new Product();
            var products = product.GetProducts();
            var sortedProductsByCategory = products.OrderBy(p => p.ProCategory).ToList();

            foreach (var item in sortedProductsByCategory)
            {
                Console.WriteLine($"Code: {item.ProCode}, Name: {item.ProName}, Category: {item.ProCategory}");
            }
        }
    }
}