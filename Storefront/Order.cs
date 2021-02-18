using System;
using System.Collections.Generic;

namespace Storefront
{
    public class Order
    {
        private string _location;
        private int _customerId;
        private DateTime _time;
        private List<Product> _products;
        private int _orderId;

        public int CustomerId
        { get { return _customerId; } }

        public string Location
        { get { return _location; } }

        public DateTime Time
        { get { return _time; } }

        public int OrderId
        { get { return _orderId; }
          set { _orderId = value; }
        }

        public List<Product> Products
        {
            get { return _products; }
            set { _products = value; }
        }

        public Order()
        {

        }

        public Order(int orderId, string location, int customerId, DateTime time)
        {
            _location = location;
            _customerId = customerId;
            _time = time;
            _orderId = orderId;
            _products = new List<Product>();
        }

        public void addOrder(Product product)
        {
            _products.Add(product);
        }
    }
}