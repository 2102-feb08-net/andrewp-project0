using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storefront
{
    class Program
    {
        static void Main(string[] args)
        {
            IStoreInputter inputter = new StoreInputter();
            IStoreOutputter outputter = new StoreOutputter();

            StoreIO storeio = new StoreIO(inputter, outputter);
            storeio.mainLoop();
        }
    }
}
