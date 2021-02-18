using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storefront
{
    class Program
    {
        static void Main(string[] args)
        {
            StoreInputter inputter = new StoreInputter();
            StoreOutputter outputter = new StoreOutputter();

            StoreIO storeio = new StoreIO(inputter, outputter);
            storeio.mainLoop();

            //List<Product> products = new List<Product>();
            //products.Add(new Product(0, "Pizza", 4.99, 5));
            //products.Add(new Product(1, "Cheese", 2.99, 10));
            //products.Add(new Product(2, "Computer", 9.99, 15));
            //Dictionary<string, List<Product>> inventory = new Dictionary<string, List<Product>>();
            //inventory.Add("ca", products);

            //outputter.saveAllInventory(inventory);
        }
    }
}
