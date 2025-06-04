using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqCodeTemplate
{
    class Problem6
    {
        static void Main()
        {
            Product product = new Product();
            var products = product.GetProducts();
            var sortedProductsByMrpInDescending = products.OrderByDescending(p => p.ProMrp).ToList();

            foreach (var item in sortedProductsByMrpInDescending)
            {
                Console.WriteLine($"Code: {item.ProCode}, Name: {item.ProName}, MRP: {item.ProMrp}");
            }
        }
    }
}