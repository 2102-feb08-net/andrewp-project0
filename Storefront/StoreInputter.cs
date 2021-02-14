using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

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

        public void getCustomers()
        {

        }

        public bool checkCustomerExists(int customerId)
        {
            try
            {
                using (var sr = new StreamReader("C:\\revature\\andrewp-project0\\Storefront\\customers.txt"))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        string[] splitData = line.Split(" ");
                        if (customerId.Equals(int.Parse(splitData[0])))
                        {
                            return true;
                        }
                    }
                }
            }
            catch (Exception)
            {
                return false;
            }
            return false;
        }

        public List<Order> getCustomerOrders()
        {
            return new List<Order>();
        }

        public List<Order> getLocationOrders()
        {
            return new List<Order>();
        }

        public int getNextCustomerId()
        {
            int id = 0;
            try
            {
                var line = File.ReadLines("C:\\revature\\andrewp-project0\\Storefront\\customers.txt").Last();
                string[] splitData = line.Split(" ");
                return int.Parse(splitData[0]) + 1;
            }
            catch (Exception)
            {
                return id;
            }
            return id;
        }

        public bool checkLocationValid(string location)
        {
            try
            {
                using (var sr = new StreamReader("C:\\revature\\andrewp-project0\\Storefront\\inventory.txt"))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        string[] splitData = line.Split(" ");
                        if (location.Equals(splitData[0]))
                        {
                            return true;
                        }
                    }
                }
            }
            catch (Exception)
            {
                return false;
            }
            return false;
        }

        public Dictionary<int, Product> getLocationInventory(string location)
        {
            var dict = new Dictionary<int, Product>();
            try
            {
                using (var sr = new StreamReader("C:\\revature\\andrewp-project0\\Storefront\\inventory.txt"))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        string[] splitData = line.Split(" ");
                        if (splitData.Length == 5 && location.Equals(splitData[0]))
                        {
                            Product product = new Product(splitData[2], double.Parse(splitData[4]), int.Parse(splitData[3]));
                            dict.Add(int.Parse(splitData[1]), product);
                        }
                    }
                }
            }
            catch (Exception)
            {
                return dict;
            }
            return dict;
        }

        public (string, string, double) getCustomerInfo(int customerId)
        {
            (string, string, double) tuple = ("", "", 0.0);
            try
            {
                using (var sr = new StreamReader("C:\\revature\\andrewp-project0\\Storefront\\customers.txt"))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        string[] splitData = line.Split(" ");
                        if (customerId.Equals(int.Parse(splitData[0])))
                        {
                            tuple = (splitData[1], splitData[2], double.Parse(splitData[3]));
                            break;
                        }
                    }
                }
            }
            catch(Exception)
            {
                return tuple;
            }
            return tuple;
        }


    }
}
