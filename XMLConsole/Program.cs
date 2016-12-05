using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace XMLConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            PostMethod();

            Console.ReadKey();
        }

        private static async void PostMethod()
        {
            Console.WriteLine("Please enter your Aggregator: ");
            var aggregator = Console.ReadLine();
            Console.WriteLine("Your wrote " + aggregator);

            Console.WriteLine("Please enter your Products: ");
            var products = Console.ReadLine();
            Console.WriteLine("Your wrote " + products);

            Console.WriteLine("Please enter your Brands: ");
            var brands = Console.ReadLine();
            Console.WriteLine("Your wrote " + brands);

            using (var client = new HttpClient())
            {
                var values = new Dictionary<string, string>
                {
                    {"DropDownListAggregator", aggregator},
                    {"DropDownListProducts", products},
                    {"DropDownListBrands", brands}
                };

                var content = new FormUrlEncodedContent(values);

                var response = await client.PostAsync("http://peg-ctmcoruqt02.comparethemarket.local:65000/", content);

                using (var responseStream = await response.Content.ReadAsStreamAsync())
                {
                    XDocument document = XDocument.Load(responseStream);

                    Console.WriteLine(document);
                }             
            }
        }
    }
}
