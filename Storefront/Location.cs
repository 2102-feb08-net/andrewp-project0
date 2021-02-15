using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storefront
{
    public class Location
    {
        private Dictionary<int, Product> _inventory;
        private string _location;
        private StoreInputter _inputter = new StoreInputter();
        private StoreOutputter _outputter = new StoreOutputter();
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

        public Location(string location)
        {
            this.CurrentLocation = location;
            if (doesLocationExist(this.CurrentLocation))
                _inventory = _inputter.getLocationInventory(this.CurrentLocation);
            else
                throw new InvalidOperationException($"No location for {this.CurrentLocation}");
            _cart = new Dictionary<int,int>();
            updateInventory();
        }

        public void printCart()
        {
            _outputter.printCart(_inventory, _cart);
        }

        public void addToCart(int productId, int amount)
        {
            if (!_inventory.ContainsKey(productId))
            {
                throw new ArgumentException("Product not in inventory.");
            }
            var inventoryProduct = _inventory[productId];
            if (!_cart.ContainsKey(productId))
                _cart.Add(productId, 0);
            _cart[productId] += amount;
        }

        public void clearCart()
        {
            _cart = new Dictionary<int, int>();
        }

        public void checkout(Customer customer)
        {
            if (_cart.Count == 0)
                throw new ArgumentException("Cart is empty");
            var checkoutOrder = new Order(_location, customer.CustomerId, DateTime.Now);

            double totalPrice = 0.0;
            foreach (var cartProduct in _cart)
            {
                if (cartProduct.Value > _inventory[cartProduct.Key].Amount)
                    throw new ArgumentException("Ordered more than stock.");
                totalPrice += _inventory[cartProduct.Key].Price * cartProduct.Value;
            }

            if (totalPrice > customer.Balance)
                throw new ArgumentException("Not enough balance on customer.");
            customer.Balance -= totalPrice;

            var finalOrder = new Order(_location, customer.CustomerId, DateTime.Now);
            foreach (var cartProduct in _cart)
            {
                _inventory[cartProduct.Key].Amount -= cartProduct.Value;
                var inventoryProduct = _inventory[cartProduct.Key];
                finalOrder.addOrder(new Product(cartProduct.Key, inventoryProduct.Name, inventoryProduct.Price, cartProduct.Value));
            }
            _outputter.newOrder(finalOrder);
            clearCart();

        }

        public Dictionary<int, Product> getInventory()
        {
            return _inventory;
        }

        private bool doesLocationExist(string location)
        {
            return _inputter.checkLocationValid(location);
        }

        private void updateInventory()
        {
            List<Order> orders = _inputter.getLocationOrders(_location);
            foreach (var order in orders)
            {
                foreach (var product in order.getProducts())
                {
                    _inventory[product.ProductId].Amount -= product.Amount;
                }
            }
        }
    }
}
