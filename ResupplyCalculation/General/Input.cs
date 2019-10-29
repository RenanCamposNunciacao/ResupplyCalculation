using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResupplyCalculation
{
    public class Input
    {
        public decimal ReadDistance(bool pRetry = true)
        {
            decimal lDistance = 0;
            string lInput;
            do
            {
                Console.WriteLine("Please, enter the distance that the ships are going to cover (in MGLT)");
                lInput = ReadLine();

                if (!decimal.TryParse(lInput, out lDistance) || lDistance <= 0)
                {
                    lDistance = 0;
                    Console.WriteLine("Sorry, the value you entered is invalid");
                }
            }
            while (lDistance <= 0 && pRetry);

            return lDistance;
        }

        public virtual string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}
