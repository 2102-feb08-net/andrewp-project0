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
        private Order _cart;

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
            _cart = new Order(_location, -1, DateTime.Now);
            updateInventory();
        }

        public void printCart()
        {
            _outputter.printCart(_cart);
        }

        public void addToCart(int productId, int amount)
        {
            if (!_inventory.ContainsKey(productId))
            {
                throw new ArgumentException("Product not in inventory.");
            }
            var inventoryProduct = _inventory[productId];
            _cart.addOrder(new Product(inventoryProduct.ProductId, inventoryProduct.Name, inventoryProduct.Price, amount));
        }

        public void clearCart()
        {
            _cart = new Order(_location, -1, DateTime.Now);
        }

        public void checkout(Customer customer)
        {
            if (_cart.getProducts().Count == 0)
                throw new ArgumentException("Cart is empty");
            var checkoutOrder = new Order(_location, customer.CustomerId, DateTime.Now);

            double totalPrice = 0.0;
            foreach (var cartProduct in _cart.getProducts())
            {
                if (cartProduct.Amount > _inventory[cartProduct.ProductId].Amount)
                    throw new ArgumentException("Ordered more than stock.");
                totalPrice += cartProduct.Amount * cartProduct.Price;
            }

            if (totalPrice > customer.Balance)
                throw new ArgumentException("Not enough balance on customer.");
            customer.Balance -= totalPrice;

            var finalOrder = new Order(_location, customer.CustomerId, DateTime.Now);
            foreach (var cartProduct in _cart.getProducts())
            {
                _inventory[cartProduct.ProductId].Amount -= cartProduct.Amount;
                finalOrder.addOrder(cartProduct);
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
