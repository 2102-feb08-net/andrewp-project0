using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;
using Storefront.DataAccess;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;

namespace Storefront
{
    public class StoreInputter
    {

        /// <summary>
        /// Reads the connection string from the disk
        /// </summary>
        /// <returns>SQL connection string</returns>
        public string readConnectionString()
        {
            string connectionString = File.ReadAllText("C:\\revature\\andrewp-project0\\StoreDB-ConnectionString.txt");
            return connectionString;
        }

        /// <summary>
        /// Takes in a string user input from the console 
        /// </summary>
        /// <returns>User inputted string</returns>
        public string getString()
        {
            return Console.ReadLine();
        }

        /// <summary>
        /// Takes in a int user input from the console
        /// </summary>
        /// <returns>The user inputted int</returns>
        public int getNumber()
        {
            string input = Console.ReadLine();
            return int.Parse(input);
        }

        /// <summary>
        /// Takes in a double user input from the console
        /// </summary>
        /// <returns>The user inputted double</returns>
        public double getDouble()
        {
            return double.Parse(Console.ReadLine());
        }
    }
}
