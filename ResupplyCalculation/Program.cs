using System;

namespace ResupplyCalculation
{
    class Program
    {
        static void Main(string[] pArgs)
        {
            Console.WriteLine(" --- Welcome to Resupply Calculation --- ");
            Input lInput = new Input();
            decimal lDistance = lInput.ReadDistance();

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

    }
}
