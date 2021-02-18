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
    public class StoreInputter
    {
        public string getString()
        {
            return Console.ReadLine();
        }

        public int getNumber()
        {
            string input = Console.ReadLine();
            return int.Parse(input);
        }

        public double getDouble()
        {
            return double.Parse(Console.ReadLine());
        }

        public List<string> getLocations()
        {
            return getAllInventory().Keys.ToList();
        }

        public List<Customer> readAllCustomers()
        {
            List<Customer> customers = new List<Customer>();
            try
            {
                string line = File.ReadAllText("C:\\revature\\andrewp-project0\\Storefront\\customers.txt");
                customers = JsonSerializer.Deserialize<List<Customer>>(line);
            }
            catch (Exception)
            {
                return customers;
            }
            return customers;
        }

        public Dictionary<string, List<Product>> getAllInventory()
        {
            var orders = new Dictionary<string, List<Product>>();
            try
            {
                string line = File.ReadAllText("C:\\revature\\andrewp-project0\\Storefront\\inventory.txt");
                orders = JsonSerializer.Deserialize<Dictionary<string, List<Product>>>(line);
            }
            catch (Exception)
            {
                return orders;
            }
            return orders;
        }

        public List<Order> getAllOrders()
        {
            var orders = new List<Order>();
            try
            {
                string line = File.ReadAllText("C:\\revature\\andrewp-project0\\Storefront\\orders.txt");
                orders = JsonSerializer.Deserialize<List<Order>>(line);
            }
            catch (Exception)
            {
                return orders;
            }
            return orders;
        }

        public List<Order> getCustomerOrders(int customerId)
        {
            List<Order> allOrders = getAllOrders();
            return allOrders.Where((order) => order.CustomerId == customerId).ToList();
        }

        public List<Order> getLocationOrders(string location)
        {
            List<Order> allOrders = getAllOrders();
            return allOrders.Where((order) => order.Location == location).ToList();
        }
    }
}
