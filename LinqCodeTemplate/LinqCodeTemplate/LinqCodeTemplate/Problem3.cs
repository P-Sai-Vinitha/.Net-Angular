using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqCodeTemplate
{
    class Problem3
    {
        static void Main()
        {
            Product product = new Product();
            var products = product.GetProducts();
            var sortedProductsByCode = products.OrderBy(p => p.ProCode).ToList();

            foreach (var item in sortedProductsByCode)
            {
                Console.WriteLine($"Code: {item.ProCode}, Name: {item.ProName}");
            }
        }
    }
}