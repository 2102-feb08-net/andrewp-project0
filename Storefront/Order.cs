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
        private StoreInputter _inputter = new StoreInputter();
        private int _orderId;

        public int CustomerId
        { get { return _customerId; } }

        public string Location
        { get { return _location; } }

        public DateTime Time
        { get { return _time; } }

        public int OrderId
        { get { return _orderId; } }






        public Order(string location, int customerId, DateTime time)
        {
            _location = location;
            _customerId = customerId;
            _time = time;
            _orderId = _inputter.getNextOrderId();
            _products = new List<Product>();
        }

        public void addOrder(Product product)
        {
            _products.Add(product);
        }

        public List<Product> getProducts()
        {
            return _products;
        }
    }
}