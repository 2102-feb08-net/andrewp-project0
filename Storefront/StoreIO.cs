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

        public StoreIO(StoreInputter inputter, StoreOutputter outputter)
        {
            this._inputter = inputter;
            this._outputter = outputter;
        }

        public void handleCustomer()
        {
            bool handled = false;

            while (!handled)
            {
                try
                {
                    _outputter.printString("1 - New Customer | 2 - Current Customer | 3 - View All Customers");
                    var input = _inputter.getNumber();
                    if (input == 1)
                    {
                        _outputter.printString("What is the customer's first name?");
                        var firstNameInput = _inputter.getString();
                        _outputter.printString("What is the customer's last name?");
                        var lastNameInput = _inputter.getString();
                        _outputter.printString("What is the customer's balance?");
                        var balanceInput = _inputter.getDouble();

                        _customer = new Customer(firstNameInput, lastNameInput, balanceInput);
                        handled = true;
                    }
                    else if (input == 2)
                    {
                        _outputter.printString("What is the customer's id?");
                        var idInput = _inputter.getNumber();

                        _customer = new Customer(idInput);
                        handled = true;
                    }
                    else if (input == 3)
                    {
                        _outputter.printAllCustomers(_inputter.getCustomers());
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
                    _outputter.printString("1 - Choose Store Location | 2 - View All Store Locations");
                    int inputLocation = _inputter.getNumber();
                    if (inputLocation == 1)
                    {
                        _outputter.printString("What is the location?");
                        _location = new Location(_inputter.getString());
                        handled = true;
                    }
                    else if (inputLocation == 2)
                    {
                        _outputter.printAllLocations(_inputter.getLocations());
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
                    _outputter.printString("1 - Modify Customer/Location | 2 - View Inventory | 3 - Add To Cart | 4 - View Cart | 5 - Checkout | 6 - Exit");
                    int userInput = _inputter.getNumber();

                    switch (userInput)
                    {
                        case 1:
                            handleCustomerInfo();
                            break;
                        case 2:
                            _outputter.printInventory(_location.getInventory());
                            break;
                        case 3:
                            _outputter.printString("Enter the ProductId.");
                            var productInput = _inputter.getNumber();
                            _outputter.printString("How many to purchase?");
                            var numInput = _inputter.getNumber();

                            _location.addToCart(productInput, numInput);
                            break;
                        case 4:
                            _location.printCart();
                            break;
                        case 5:
                            _location.checkout(_customer);
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
                    _outputter.printString("1 - Change Customer | 2 - Change Location | 3 - View Current Customer/Location | 4 - Back");
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
