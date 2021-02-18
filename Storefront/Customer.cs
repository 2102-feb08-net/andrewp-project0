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
        private int _customerId;

        public Customer()
        {
        }

        public Customer(int customerId, string first, string last, double balance = 0.0)
        {
            this.CustomerId = customerId;
            this.FirstName = first;
            this.LastName = last;
            this.Balance = balance;
        }

        public int CustomerId
        { get { return _customerId; } set {} }


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
            set 
            {
                if (value < 0)
                    throw new InvalidOperationException("Balance cannot be less than zero.");
                _balance = value; 
            }
        }

    }
}