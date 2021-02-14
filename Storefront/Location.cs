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
        }

        public void orderProduct(int productId, int amount)
        {

        }

        public Dictionary<int, Product> getInventory()
        {
            return _inventory;
        }

        private bool doesLocationExist(string location)
        {
            return _inputter.checkLocationValid(location);
        }
    }
}
