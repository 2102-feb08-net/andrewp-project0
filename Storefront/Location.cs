using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storefront
{
    public class Location
    {
        private string _location;
        private Dictionary<int, int> _cart;

        public string CurrentLocation
        {
            get
            {
                return _location;
            }
            set
            {
                if (!value.All(char.IsLetterOrDigit))
                    throw new InvalidOperationException("Only alphanumeric characters for locations");
                _location = value.ToLower();
            }
        }

        public Location()
        {
            _cart = new Dictionary<int, int>();
        }

        public Location(string location)
        {
            this.CurrentLocation = location;
            _cart = new Dictionary<int,int>();
        }

        public Dictionary<int, int> Cart
        { get { return _cart; }
          set { _cart = value; }
        }


        public void addToCart(int productId, int amount, Dictionary<int, Product> inventory)
        {
            if (!inventory.ContainsKey(productId))
            {
                throw new ArgumentException("Product not in inventory.");
            }
            if (!_cart.ContainsKey(productId))
                _cart.Add(productId, 0);
            _cart[productId] += amount;
        }

        public void clearCart()
        {
            _cart = new Dictionary<int, int>();
        }

        public Order checkout(List<Order> orders, Customer customer, Dictionary<int, Product> inventory)
        {
            if (_cart.Count == 0)
                throw new ArgumentException("Cart is empty");

            double totalPrice = 0.0;
            foreach (var cartProduct in _cart)
            {
                if (cartProduct.Value > inventory[cartProduct.Key].Amount)
                    throw new ArgumentException("Ordered more than stock.");
                totalPrice += inventory[cartProduct.Key].Price * cartProduct.Value;
            }

            if (totalPrice > customer.Balance)
                throw new ArgumentException("Not enough balance on customer.");
            customer.Balance -= totalPrice;

            var finalOrder = new Order(orders.Select((order) => order.OrderId).Max() + 1, _location, customer.CustomerId, DateTime.Now);
            foreach (var cartProduct in _cart)
            {
                inventory[cartProduct.Key].Amount -= cartProduct.Value;
                var inventoryProduct = inventory[cartProduct.Key];
                finalOrder.addOrder(new Product(cartProduct.Key, inventoryProduct.Name, inventoryProduct.Price, cartProduct.Value));
            }
            orders.Add(finalOrder);
            clearCart();
            return finalOrder;

        }
    }
}
