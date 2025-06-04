using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqCodeTemplate
{
    class Problem11
    {
        static void Main()
        {
            Product product = new Product();
            var products = product.GetProducts();
            int fmcgCount = products.Where(p => p.ProCategory == "FMCG").Count();
            Console.WriteLine("Total number of FMCG products: " + fmcgCount);

        }
    }
}