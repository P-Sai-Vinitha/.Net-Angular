using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqCodeTemplate
{
    class Problem9
    {
        static void Main()
        {
            Product product = new Product();
            var products = product.GetProducts();
            var highestPricedFmcgProduct = products.Where(p => p.ProCategory == "FMCG").OrderByDescending(p => p.ProMrp).FirstOrDefault();

            if (highestPricedFmcgProduct != null)
            {
                Console.WriteLine($"{highestPricedFmcgProduct.ProCode}\t{highestPricedFmcgProduct.ProName}\t{highestPricedFmcgProduct.ProMrp}");
            }
            else
            {
                Console.WriteLine("No product found in FMCG category.");
            }

            Console.ReadLine();
        }
    }
}