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
            //storeio.mainLoop();

            List<Customer> customers = new List<Customer>();
            Customer cust1 = new Customer("TestFirstOne", "TestLastOne", 1000);
            Customer cust2 = new Customer("TestFirstTwo", "TestLastTwo", 2000);
            Customer cust3 = new Customer("TestFirstThree", "TestLastThree", 3000);
            customers.Add(cust1);
            customers.Add(cust2);
            customers.Add(cust3);
            outputter.saveCustomers(customers);
            List<Customer> newCustomers = inputter.readAllCustomers();
        }
    }
}
