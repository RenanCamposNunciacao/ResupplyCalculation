using System;

namespace ResupplyCalculation
{
    public class Starship
    {
        public string name { get; set; }
        public string model { get; set; }
        public string manufacturer { get; set; }
        public string cost_in_credits { get; set; }
        public string length { get; set; }
        public string max_atmosphering_speed { get; set; }
        public string crew { get; set; }
        public string passengers { get; set; }
        public string cargo_capacity { get; set; }
        public string consumables { get; set; }
        public string hyperdrive_rating { get; set; }
        public string MGLT { get; set; }
        public string starship_class { get; set; }
        public string[] pilots { get; set; }
        public string[] films { get; set; }
        public string created { get; set; }
        public string edited { get; set; }
        public string url { get; set; }    
        
        public void PrintStops(decimal pDistance)
        {
            if (this.MGLT == "unknown")
                Console.WriteLine("{0}: unknown", this.name);
            else
                Console.WriteLine("{0}: {1}", this.name, CalculateStops(pDistance));
        }

        public int CalculateStops(decimal pDistance)
        {
            if (this.MGLT == "unknown")
                return -1;

            int lMaxSpeed = int.Parse(this.MGLT);
            decimal lHours = pDistance / lMaxSpeed;
            int lConsumables = Utility.GetHours(this.consumables);

            if (lConsumables == 0)
                return -1;

            if (lConsumables >= lHours)
                return 0;

            return (int)Math.Floor(lHours / lConsumables);
            
        }
    }
}
