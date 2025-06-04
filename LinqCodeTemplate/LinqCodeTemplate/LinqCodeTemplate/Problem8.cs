using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqCodeTemplate
{
    class Problem8
    {
        static void Main()
        {
            Product product = new Product();
            var products = product.GetProducts();
            var groupedProductsByMrp = products.GroupBy(p => p.ProMrp).ToList();

            foreach (var group in groupedProductsByMrp)
            {
                Console.WriteLine($"MRP: {group.Key}");
                foreach (var item in group)
                {
                    Console.WriteLine($"\tCode: {item.ProCode}, Name: {item.ProName}, Category: {item.ProCategory}, MRP: {item.ProMrp}");
                }
            }

        }
    }
}