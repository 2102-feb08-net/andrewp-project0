using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Storefront.Library;

namespace Storefront
{
    public interface IStoreOutputter
    {
        /// <summary>
        /// Print the string value to the console
        /// </summary>
        /// <param name="output">The string output</param>
        public void printString(string output);

        /// <summary>
        /// Print the cart to the console
        /// </summary>
        /// <param name="inventory">Inventory dictionary</param>
        /// <param name="cart">Cart dictionary</param>
        public void printCart(Dictionary<int, Product> inventory, Dictionary<int, int> cart);

        /// <summary>
        /// Print all customers to the console
        /// </summary>
        /// <param name="customers">List of Customers</param>
        public void printAllCustomers(List<Customer> customers);

        /// <summary>
        /// Print all orders to the console
        /// </summary>
        /// <param name="orders">List of Orders</param>
        public void printOrders(List<Order> orders);

        /// <summary>
        /// Print all stored locations to the console
        /// </summary>
        /// <param name="locations">List of location strings</param>
        public void printAllLocations(List<string> locations);

        /// <summary>
        /// Print the inventory to the console
        /// </summary>
        /// <param name="inventory">The inventory dictionary</param>
        public void printInventory(Dictionary<int, Product> inventory);
    }
}
