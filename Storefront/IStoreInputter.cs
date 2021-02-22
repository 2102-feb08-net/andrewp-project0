using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storefront
{
    public interface IStoreInputter
    {
        /// <summary>
        /// Reads the connection string from the disk
        /// </summary>
        /// <returns>SQL connection string</returns>
        public string readConnectionString();

        /// <summary>
        /// Takes in a string user input from the console 
        /// </summary>
        /// <returns>User inputted string</returns>
        public string getString();

        /// <summary>
        /// Takes in a int user input from the console
        /// </summary>
        /// <returns>The user inputted int</returns>
        public int getNumber();

        /// <summary>
        /// Takes in a double user input from the console
        /// </summary>
        /// <returns>The user inputted double</returns>
        public double getDouble();
    }
}
