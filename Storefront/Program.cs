using System;

namespace Storefront
{
    class Program
    {
        static void Main(string[] args)
        {
            StoreInputter inputter = new StoreInputter();
            StoreOutputter outputter = new StoreOutputter();

            StoreIO storeio = new StoreIO(inputter, outputter);
            storeio.mainLoop();
        }
    }
}
