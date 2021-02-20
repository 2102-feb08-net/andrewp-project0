using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Storefront
{
    /// <summary>
    /// The store outputter class that handles all the output of the console application
    /// </summary>
    public class StoreOutputter
    {
        /// <summary>
        /// Print the string value to the console
        /// </summary>
        /// <param name="output">The string output</param>
        public void printString(string output)
        {
            Console.WriteLine(output);
        }

        /// <summary>
        /// Print the cart to the console
        /// </summary>
        /// <param name="inventory">Inventory dictionary</param>
        /// <param name="cart">Cart dictionary</param>
        public void printCart(Dictionary<int, Product> inventory, Dictionary<int, int> cart)
        {
            Console.WriteLine("");
            Console.WriteLine(String.Format("{0,-15} {1,-15} {2,-15}", "Name", "Price", "Amount"));
            foreach (var product in cart)
            {
                var inventoryProduct = inventory[product.Key];
                Console.WriteLine(String.Format("{0,-15} {1,-15} {2,-15}", inventoryProduct.Name, inventoryProduct.Price.ToString("0.00"), product.Value));
            }
            Console.WriteLine("");
        }

        /// <summary>
        /// Print all customers to the console
        /// </summary>
        /// <param name="customers">List of Customers</param>
        public void printAllCustomers(List<Customer> customers)
        {
            Console.WriteLine("");
            Console.WriteLine(String.Format("{0,-10} {1,-15} {2,-15}", "CustomerId", "First", "Last"));
            foreach (var customer in customers)
            {
                Console.WriteLine(String.Format("{0,-10} {1,-15} {2,-15}", customer.CustomerId, customer.FirstName, customer.LastName));
            }
            Console.WriteLine("");
        }

        /// <summary>
        /// Print all orders to the console
        /// </summary>
        /// <param name="orders">List of Orders</param>
        public void printOrders(List<Order> orders)
        {
            Console.WriteLine("");
            Console.WriteLine(String.Format("{0,-10} {1,-15} {2,-15} {3,-10} {4,-10}", "OrderId", "CustomerId", "Product Name", "Price", "Amount"));
            foreach (var order in orders)
            {
                foreach (var product in order.Products)
                    Console.WriteLine(String.Format("{0,-10} {1,-15} {2,-15} {3,-10} {4,-10}", order.OrderId, order.CustomerId, product.Name, product.Price.ToString("0.00"), product.Amount));
            }
            Console.WriteLine("");
        }

        /// <summary>
        /// Print all stored locations to the console
        /// </summary>
        /// <param name="locations">List of location strings</param>
        public void printAllLocations(List<string> locations)
        {
            Console.WriteLine("");
            Console.WriteLine(String.Format("{0,-10}", "Location"));
            foreach (var location in locations)
            {
                Console.WriteLine(String.Format("{0,-10}", location));
            }
            Console.WriteLine("");
        }

        /// <summary>
        /// Print the inventory to the console
        /// </summary>
        /// <param name="inventory">The inventory dictionary</param>
        public void printInventory(Dictionary<int, Product> inventory)
        {
            Console.WriteLine(String.Format("{0,-10} | {1,-15} | {2,-15} | {3,-10}", "ProductID", "Name", "Price", "Stock"));
            foreach (var entry in inventory)
            {
                Console.WriteLine(String.Format("{0,-10} | {1,-15} | {2,-15} | {3,-10}", entry.Key, entry.Value.Name, entry.Value.Price.ToString("0.00"), entry.Value.Amount));
            }
            Console.WriteLine("");
        }
    }
}
