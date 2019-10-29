using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net;
using System.IO;

namespace ResupplyCalculation
{
    public class Utility
    {
        public static int GetDays(string pConsumables)
        {
            string[] lAux = pConsumables.Split(' ');
            int lNumber;
            try
            {
                if (lAux.Length < 2)
                    return 0;

                lNumber = int.Parse(lAux[0]);
                switch (lAux[1].ToLower())
                {
                    case "year":
                    case "years":
                        return lNumber * 365;
                    case "month":
                    case "months":
                        return lNumber * 30;
                    case "week":
                    case "weeks":
                        return lNumber * 7;
                    case "day":
                    case "days":
                        return lNumber;
                }
            }
            catch
            {
                return 0;
            }

            return 0;
        }

        public static int GetHours(string pConsumables)
        {
            return GetDays(pConsumables) * 24;
        }

        public class Request
        {
            public static IEnumerable<Starship> GetStarships()
            {
                StarshipResponse lStarshipResponse = MakeRequest("https://swapi.co/api/starships/");

                if (lStarshipResponse == null)
                    yield return null;

                do
                {
                    foreach (Starship lStarship in lStarshipResponse.results)
                        yield return lStarship;

                    if (string.IsNullOrEmpty(lStarshipResponse.next))
                        lStarshipResponse = null;
                    else
                        lStarshipResponse = MakeRequest(lStarshipResponse.next);
                }
                while (lStarshipResponse != null);
            }

            public static StarshipResponse MakeRequest(string pUrl)
            {
                try
                {
                    WebRequest lWebRequest = WebRequest.Create(pUrl);
                    WebResponse lWebResponse = lWebRequest.GetResponse();
                    return JsonConvert.DeserializeObject<StarshipResponse>(new StreamReader(lWebResponse.GetResponseStream()).ReadToEnd());
                }
                catch
                {
                    return null;
                }
            }
        }
    }
}
