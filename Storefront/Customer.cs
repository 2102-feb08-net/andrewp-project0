using System;
using System.Collections.Generic;
using System.Linq;

namespace Storefront
{
    public class Customer
    {
        private string _firstName;
        private string _lastName;
        private double _balance;
        private List<Order> _orders;
        private int _customerId;
        private StoreOutputter outputter = new StoreOutputter();
        private StoreInputter inputter = new StoreInputter();

        /// <summary>
        /// Create new customer with first name, last name, and initial balance.
        /// </summary>
        /// <param name="first">First name only alphabet characters.</param>
        /// <param name="last">Last name only alphabet characters.</param>
        /// <param name="balance">Initial balance on account.</param>
        public Customer(string first, string last, double balance = 0.0)
        {
            this._customerId = inputter.getNextCustomerId();

            this.FirstName = first;
            this.LastName = last;
            this._balance = balance;

            outputter.createNewCustomer(_customerId, this.FirstName, this.LastName, this._balance);
        }

        /// <summary>
        /// Check if customer with customerId exists then get first/last name, balance, and orders.
        /// </summary>
        /// <param name="customerId">Customer Id</param>
        public Customer(int customerId)
        {
            if (inputter.checkCustomerExists(customerId))
            {
                var customerInfo = inputter.getCustomerInfo(customerId);
                this.FirstName = customerInfo.Item1;
                this.LastName = customerInfo.Item2;
                this._balance = customerInfo.Item3;
                this._customerId = customerId;

                this._orders = inputter.getCustomerOrders(customerId);
                getCustomerBalance();
            }
            else
                throw new ArgumentException("Invalid customer id");

        }

        public int CustomerId
        { get { return _customerId; } }


        public string FirstName
        {
            get
            {
                return _firstName;
            }
            set
            {
                if (!value.All(char.IsLetter))
                {
                    throw new InvalidOperationException("Name can only contain alphabetic letters.");
                }
                _firstName = value.ToLower();
            } 
        }

        public string LastName
        {
            get 
            {
                return _lastName;
            }
            set 
            {
                if (!value.All(char.IsLetter))
                {
                    throw new InvalidOperationException("Name can only contain alphabetic letters.");
                }
                _lastName = value.ToLower();
            }
        }

        public double Balance
        {
            get { return _balance; }
            set { _balance = value; }
        }


        private void getCustomerBalance()
        {
            foreach (var order in this._orders)
            {
                foreach(var product in order.getProducts())
                {
                    this._balance -= product.Price * product.Amount;
                }
            }
        }

    }
}