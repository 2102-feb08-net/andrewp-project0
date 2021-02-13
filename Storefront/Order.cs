using System;
using System.Collections.Generic;

namespace Storefront
{
    public class Order
    {
        private static int orderSeed = 0;

        private string _location;
        private Customer _customer;
        private DateTime _time;
        private List<Product> _products;
        private int _orderId;

        public Order(string location, Customer customer, DateTime time)
        {
            _location = location;
            _customer = customer;
            _time = time;
            _orderId = orderSeed;
            orderSeed += 1;
        }

        public void AddOrder(Product product)
        {
            _products.Add(product);
        }

        public override string ToString()
        {
            return $"{_orderId} for {_customer} at {_time} in location {_location}";
        }
    }
}