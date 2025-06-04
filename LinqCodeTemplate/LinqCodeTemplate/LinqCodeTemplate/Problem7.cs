using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqCodeTemplate
{
    class Problem7
    {
        static void Main()
        {
            Product product = new Product();
            var products = product.GetProducts();
            var groupedProductsByCategory = products.GroupBy(p => p.ProCategory).ToList();

            foreach (var group in groupedProductsByCategory)
            {
                Console.WriteLine($"Category: {group.Key}");
                foreach (var item in group)
                {
                    Console.WriteLine($"\tCode: {item.ProCode}, Name: {item.ProName}, Category: {item.ProCategory}");
                }
            }

        }
    }
}