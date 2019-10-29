using System.Collections.Generic;

namespace ResupplyCalculation
{
    public class StarshipResponse
    {
        public int count { get; set; }
        public string next { get; set; }
        public string previous { get; set; }
        public List<Starship> results { get; set; }
    }
}
