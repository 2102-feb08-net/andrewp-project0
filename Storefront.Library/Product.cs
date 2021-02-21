using System;
using System.Linq;

namespace Storefront.Library
{
    /// <summary>
    /// The class to represent a product
    /// </summary>
    public class Product
    {
        private string _name;
        private double _price;
        private int _amount;
        private int _productId;

        /// <summary>
        /// Class to represent a product sold on the store
        /// </summary>
        /// <param name="productId">The product id</param>
        /// <param name="name">The product name</param>
        /// <param name="price">The price of the product</param>
        /// <param name="amount">The amount of product if in an inventory</param>
        public Product(int productId, string name, double price, int amount)
        {
            this.Name = name;
            this.Price = price;
            this._amount = amount;
            this._productId = productId;
        }

        public int ProductId
        { get { return _productId; } }
        

        public int Amount
        {
            get
            {
                return _amount;
            }
            set
            {
                _amount = value;
            }
        }


        public double Price
        {
            get
            {
                return _price;
            }
            set
            {
                _price = value;
            }
        }

        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                if (!value.All(char.IsLetterOrDigit))
                {
                    throw new ArgumentException("Invalid name to product.");
                }
                _name = value;
            }
        }


    }
}