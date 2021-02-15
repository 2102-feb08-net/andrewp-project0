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

        public HashSet<string> getLocations()
        {
            var set = new HashSet<string>();
            try
            {
                using (var sr = new StreamReader("C:\\revature\\andrewp-project0\\Storefront\\inventory.txt"))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        string[] splitData = line.Split(" ");
                        set.Add(splitData[0]);
                    }
                }
            }
            catch (Exception)
            {
                return set;
            }
            return set;
        }

        public List<(int, string, string)> getCustomers()
        {
            var customers = new List<(int, string, string)>();
            try
            {
                using (var sr = new StreamReader("C:\\revature\\andrewp-project0\\Storefront\\customers.txt"))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        string[] splitData = line.Split(" ");
                        customers.Add((int.Parse(splitData[0]), splitData[1], splitData[2]));
                    }
                }
            }
            catch (Exception)
            {
                return customers;
            }
            return customers;
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

        public List<Order> getCustomerOrders(int customerId)
        {
            var dict = new Dictionary<int, Order>();
            try
            {
                using (var sr = new StreamReader("C:\\revature\\andrewp-project0\\Storefront\\orders.txt"))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        string[] splitData = line.Split(" ");
                        int orderId = int.Parse(splitData[0]);
                        int id = int.Parse(splitData[1]);
                        if (id == customerId)
                        {
                            if (!dict.ContainsKey(orderId))
                            {
                                dict.Add(orderId, new Order(splitData[2], id, DateTime.Parse(splitData[6])));
                            }
                            dict[orderId].addOrder(new Product(int.Parse(splitData[7]), splitData[3], double.Parse(splitData[4]), int.Parse(splitData[5])));
                        }
                        
                    }
                }
            }
            catch(Exception)
            {
                return dict.Values.ToList();
            }
            return dict.Values.ToList();
        }

        public List<Order> getLocationOrders(string location)
        {
            var dict = new Dictionary<string, Order>();
            try
            {
                using (var sr = new StreamReader("C:\\revature\\andrewp-project0\\Storefront\\orders.txt"))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        string[] splitData = line.Split(" ");
                        int orderId = int.Parse(splitData[0]);
                        int id = int.Parse(splitData[1]);
                        string orderLocation = splitData[2];
                        if (location == orderLocation)
                        {
                            if (!dict.ContainsKey(location))
                            {
                                dict.Add(location, new Order(location, id, DateTime.Parse(splitData[6])));
                            }
                            dict[location].addOrder(new Product(int.Parse(splitData[7]), splitData[3], double.Parse(splitData[4]), int.Parse(splitData[5])));
                        }

                    }
                }
            }
            catch (Exception)
            {
                return dict.Values.ToList();
            }
            return dict.Values.ToList();
        }

        public int getNextOrderId()
        {
            int id = 0;
            try
            {
                var line = File.ReadLines("C:\\revature\\andrewp-project0\\Storefront\\orders.txt").Last();
                string[] splitData = line.Split(" ");
                return int.Parse(splitData[0]) + 1;
            }
            catch (Exception)
            {
                return id;
            }
            return id;
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
                            Product product = new Product(int.Parse(splitData[1]), splitData[2], double.Parse(splitData[4]), int.Parse(splitData[3]));
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
