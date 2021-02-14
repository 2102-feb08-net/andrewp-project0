using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Storefront
{
    public class StoreOutputter
    {
        public void printString(string output)
        {
            Console.WriteLine(output);
        }

        public void createNewCustomer(int customerId, string firstName, string lastName, double balance)
        {
            try
            {
                using(var sw = new StreamWriter("C:\\revature\\andrewp-project0\\Storefront\\customers.txt", true))
                {
                    sw.WriteLine($"{customerId} {firstName} {lastName} {balance}");
                }
            }
            catch(Exception)
            {
                Console.WriteLine("Error creating new customer");
            }
        }

        public void printInventory(Dictionary<int, Product> inventory)
        {
            Console.WriteLine(String.Format("{0,-10} | {1,-15} | {2,-15} | {3,-10}", "ProductID", "Name", "Price", "Stock"));
            foreach (var entry in inventory)
            {
                Console.WriteLine(String.Format("{0,-10} | {1,-15} | {2,-15} | {3,-10}", entry.Key, entry.Value.Name, entry.Value.Price, entry.Value.Amount));
            }
            Console.WriteLine("");
        }
    }
}
