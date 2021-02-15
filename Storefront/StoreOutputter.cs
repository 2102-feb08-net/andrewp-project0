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

        public void printCart(Dictionary<int, Product> inventory, Dictionary<int, int> cart)
        {
            Console.WriteLine("");
            Console.WriteLine(String.Format("{0,-15} {1,-15} {2,-15}", "Name", "Price", "Amount"));
            foreach (var product in cart)
            {
                var inventoryProduct = inventory[product.Key];
                Console.WriteLine(String.Format("{0,-15} {1,-15} {2,-15}", inventoryProduct.Name, inventoryProduct.Price, product.Value));
            }
            Console.WriteLine("");
        }

        public void printAllCustomers(List<(int, string, string)> customers)
        {
            Console.WriteLine("");
            Console.WriteLine(String.Format("{0,-10} {1,-15} {2,-15}", "CustomerId", "First", "Last"));
            foreach (var customer in customers)
            {
                Console.WriteLine(String.Format("{0,-10} {1,-15} {2,-15}", customer.Item1, customer.Item2, customer.Item3));
            }
            Console.WriteLine("");
        }

        public void printAllLocations(HashSet<string> locations)
        {
            Console.WriteLine("");
            Console.WriteLine(String.Format("{0,-10}", "Location"));
            foreach (var location in locations)
            {
                Console.WriteLine(String.Format("{0,-10}", location));
            }
            Console.WriteLine("");
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

        public void newOrder(Order finalOrder)
        {
            try
            {
                using (var sw = new StreamWriter("C:\\revature\\andrewp-project0\\Storefront\\orders.txt", true))
                {
                    foreach (var product in finalOrder.getProducts())
                    {
                        sw.WriteLine($"{finalOrder.OrderId} {finalOrder.CustomerId}" +
                            $" {finalOrder.Location} {product.Name} " +
                            $"{product.Price} {product.Amount} {finalOrder.Time.ToShortDateString()} {product.ProductId}");
                    }
                }
            }
            catch(Exception)
            {
                Console.WriteLine("Error creating new orders");
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
