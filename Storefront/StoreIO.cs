using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storefront
{
    public class StoreIO
    {
        private StoreInputter _inputter;
        private StoreOutputter _outputter;
        private Customer _customer;
        private Location _location;
        private List<Customer> _customers;
        private List<Order> _orders;
        private Dictionary<string, List<Product>> _inventory;
        private Dictionary<int, Product> _locationInventory;

        public StoreIO(StoreInputter inputter, StoreOutputter outputter)
        {
            this._inputter = inputter;
            this._outputter = outputter;
            this._customers = inputter.readAllCustomers();
            this._orders = inputter.getAllOrders();
            _inventory = inputter.getAllInventory();
        }

        public void handleCustomer()
        {
            bool handled = false;

            while (!handled)
            {
                try
                {
                    _outputter.printString("1 - New Customer | 2 - Current Customer | 3 - View All Customers | 4 - View Customer Orders");
                    var input = _inputter.getNumber();
                    if (input == 1)
                    {
                        _outputter.printString("What is the customer's first name?");
                        var firstNameInput = _inputter.getString();
                        _outputter.printString("What is the customer's last name?");
                        var lastNameInput = _inputter.getString();
                        _outputter.printString("What is the customer's balance?");
                        var balanceInput = _inputter.getDouble();

                        _customer = new Customer(_customers.Max((customer) => customer.CustomerId) + 1, firstNameInput, lastNameInput, balanceInput);
                        handled = true;
                    }
                    else if (input == 2)
                    {
                        _outputter.printString("What is the customer's id?");
                        var idInput = _inputter.getNumber();

                        _customer = _customers.Find((customer) => customer.CustomerId == idInput);
                        if (_customer != null)
                            handled = true;
                        else
                            _outputter.printString("Customer Id not found.\n");
                    }
                    else if (input == 3)
                    {
                        _outputter.printAllCustomers(_customers);
                    }
                    else if (input == 4)
                    {
                        if (_customer == null)
                        {
                            _outputter.printString("No Customer Selected.\n");
                            continue;
                        }
                        _outputter.printOrders(_inputter.getCustomerOrders(_customer.CustomerId));
                    }
                    else
                    {
                        throw new InvalidOperationException("Invalid user input.");
                    }
                }
                catch (Exception)
                {
                    _outputter.printString("Invalid Input.\n");
                    continue;
                }
            }
        }

        public void handleLocation()
        {
            bool handled = false;

            while (!handled)
            {
                try
                {
                    _outputter.printString("1 - Choose Store Location | 2 - View All Store Locations | 3 - View Location Orders");
                    int inputLocation = _inputter.getNumber();
                    if (inputLocation == 1)
                    {
                        _outputter.printString("What is the location?");
                        _location = new Location(_inputter.getString());
                        _locationInventory = _inventory[_location.CurrentLocation].ToDictionary((product) => product.ProductId, (product) => product);
                        handled = true;
                    }
                    else if (inputLocation == 2)
                    {
                        _outputter.printAllLocations(_inputter.getLocations());
                    }
                    else if (inputLocation == 3)
                    {
                        _outputter.printOrders(_inputter.getLocationOrders(_location.CurrentLocation));
                    }
                    else
                    {
                        throw new InvalidOperationException("Invalid Input \n");
                    }
                }
                catch (Exception)
                {
                    _outputter.printString("Invalid Input.\n");
                    continue;
                }
            }
        }

        public void handleStoreOptions()
        {
            bool exit = false;

            while (!exit)
            {
                try
                {
                    _outputter.printString("1 - Customer/Location | 2 - View Inventory | 3 - Add To Cart | 4 - View Cart | 5 - Checkout | 6 - Exit");
                    int userInput = _inputter.getNumber();

                    switch (userInput)
                    {
                        case 1:
                            handleCustomerInfo();
                            break;
                        case 2:
                            _outputter.printInventory(_locationInventory);
                            break;
                        case 3:
                            _outputter.printString("Enter the ProductId.");
                            var productInput = _inputter.getNumber();
                            _outputter.printString("How many to purchase?");
                            var numInput = _inputter.getNumber();

                            _location.addToCart(productInput, numInput, _locationInventory);
                            break;
                        case 4:
                            _outputter.printCart(_locationInventory, _location.Cart);
                            break;
                        case 5:
                            Order finalOrder = _location.checkout(_orders, _customer, _locationInventory);
                            _orders.Add(finalOrder);
                            _inventory[_location.CurrentLocation] = _locationInventory.Values.ToList();

                            _outputter.saveAllInventory(_inventory);
                            _outputter.saveAllOrders(_orders);
                            break;
                        case 6:
                            exit = true;
                            break;
                        default:
                            _outputter.printString("Invalid Input.\n");
                            break;
                    }
                }
                catch (Exception)
                {
                    _outputter.printString("Invalid Input.\n");
                }
            }

        }

        public void handleCustomerInfo()
        {
            bool exit = false;
            while (!exit)
            {
                try
                {
                    _outputter.printString("1 - Customer | 2 - Location | 3 - View Current Customer/Location | 4 - Back");
                    int userInput = _inputter.getNumber();
                    switch (userInput)
                    {
                        case 1:
                            handleCustomer();
                            _location.clearCart();
                            break;
                        case 2:
                            handleLocation();
                            _location.clearCart();
                            break;
                        case 3:
                            _outputter.printString($"Current customer is {_customer.FirstName} {_customer.LastName} with a balance of {_customer.Balance} and current location is {_location.CurrentLocation}\n");
                            break;
                        case 4:
                            exit = true;
                            break;
                        default:
                            _outputter.printString("Invalid Input.\n");
                            break;
                    }

                }
                catch (Exception)
                {
                }
            }
        }


        public void mainLoop()
        {
            handleCustomer();
            handleLocation();
            handleStoreOptions();
        }


    }
}
