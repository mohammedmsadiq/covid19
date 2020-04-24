using System;

namespace covid19.Models
{
    public class WorldModel
    {
        private string lastUpdated;

        public double updated { get; set; }
        public int cases { get; set; }
        public int todayCases { get; set; }
        public int deaths { get; set; }
        public int todayDeaths { get; set; }
        public int recovered { get; set; }
        public int active { get; set; }
        public int critical { get; set; }
        public double casesPerOneMillion { get; set; }
        public double deathsPerOneMillion { get; set; }
        public int tests { get; set; }
        public double testsPerOneMillion { get; set; }
        public int affectedCountries { get; set; }    
    }
}