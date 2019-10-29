using System;

namespace ResupplyCalculation
{
    class Program
    {
        static void Main(string[] pArgs)
        {
            Console.WriteLine(" --- Welcome to Resupply Calculation --- ");
            decimal lDistance = ReadDistance();

            Console.WriteLine(" --- Calculation started --- ");

            foreach (Starship lStarship in Utility.Request.GetStarships())
            {
                if (lStarship == null)
                {
                    Console.WriteLine(" --- There was a problem while accessing the API, please try again later --- ");
                    break;
                }
                
                lStarship.PrintStops(lDistance);
            }

            Console.WriteLine(" --- Calculation finished --- ");

            Console.ReadLine();
        }

        static private decimal ReadDistance()
        {
            decimal lDistance = 0;
            string lInput;
            do
            {
                Console.WriteLine("Please, enter the distance that the ships are going to cover (in MGLT)");
                lInput = Console.ReadLine();

                if (!decimal.TryParse(lInput, out lDistance) || lDistance <= 0)
                {
                    lDistance = 0;
                    Console.WriteLine("Sorry, the value you entered is invalid");
                }
            }
            while (lDistance <= 0);

            return lDistance;
        }

    }
}
