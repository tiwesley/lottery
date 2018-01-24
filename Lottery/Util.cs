using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lottery
{
    class Util
    {

        /// <summary>
        /// Load a number.
        /// </summary>
        /// <returns></returns>
        public static int ConsoleReadNumber()
        {
            // Local variables
            var optVar = Console.ReadLine();
            int option = Convert.ToInt32(optVar);

            return option;
        }
    }
}
