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

        public void printOrders(List<Order> orders)
        {
            Console.WriteLine("");
            Console.WriteLine(String.Format("{0,-10} {1,-15} {2,-15} {3,-10} {4,-10}", "OrderId", "CustomerId", "Product Name", "Price", "Amount"));
            foreach (var order in orders)
            {
                foreach (var product in order.Products)
                    Console.WriteLine(String.Format("{0,-10} {1,-15} {2,-15} {3,-10} {4,-10}", order.OrderId, order.CustomerId, product.Name, product.Price, product.Amount));
            }
            Console.WriteLine("");
        }

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

        public void saveAllInventory(Dictionary<string, List<Product>> inventory)
        {
            try
            {
                using (var sw = new StreamWriter("C:\\revature\\andrewp-project0\\Storefront\\inventory.txt", false))
                {
                    sw.WriteLine(JsonSerializer.Serialize(inventory));
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Error creating new orders");
            }
        }

        public void saveAllOrders(List<Order> orders)
        {
            try
            {
                using (var sw = new StreamWriter("C:\\revature\\andrewp-project0\\Storefront\\orders.txt", false))
                {
                    sw.WriteLine(JsonSerializer.Serialize(orders));
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Error creating new orders");
            }
        }

        public void saveCustomers(List<Customer> customers)
        {
            try
            {
                using (var sw = new StreamWriter("C:\\revature\\andrewp-project0\\Storefront\\customers.txt", false))
                {
                    sw.WriteLine(JsonSerializer.Serialize(customers));
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Error saving customer's to disk.");
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
