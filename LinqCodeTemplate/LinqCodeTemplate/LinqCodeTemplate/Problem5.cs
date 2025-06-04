using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqCodeTemplate
{
    class Problem5
    {
        static void Main()
        {
            Product product = new Product();
            var products = product.GetProducts();
            var sortedProductsByMrp = products.OrderBy(p => p.ProMrp).ToList();

            foreach (var item in sortedProductsByMrp)
            {
                Console.WriteLine($"Code: {item.ProCode}, Name: {item.ProName}, MRP: {item.ProMrp}");
            }
        }
    }
}