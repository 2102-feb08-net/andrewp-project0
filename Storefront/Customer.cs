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

        public Customer()
        {
            _orders = GetOrderHistory();
            _balance = GetCustomerBalance(_orders);
        }

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
            }
        }

        private List<Order> GetOrderHistory()
        {
            return new List<Order>();
        }

        private double GetCustomerBalance(List<Order> orders)
        {
            return 0.0;
        }

    }
}