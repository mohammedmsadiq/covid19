using System;
namespace covid19.Models
{
    public class CountryModel
    {
        private string lastUpdated;

        public double updated { get; set; }
        public string country { get; set; }
        public CountryInfo countryInfo { get; set; }
        public int cases { get; set; }
        public int todayCases { get; set; }
        public int deaths { get; set; }
        public int todayDeaths { get; set; }
        public int recovered { get; set; }
        public int active { get; set; }
        public int critical { get; set; }
        public int casesPerOneMillion { get; set; }
        public int deathsPerOneMillion { get; set; }
        public int tests { get; set; }
        public int testsPerOneMillion { get; set; }
        public string continent { get; set; }
        public string Flag { get; set; }

        //public string LastUpdated
        //{
        //    get
        //    {
        //        DateTime unixStart = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
        //        long unixTimeStampInTicks = (long)(updated * TimeSpan.TicksPerSecond);
        //        DateTime r = new DateTime(unixStart.Ticks + unixTimeStampInTicks, DateTimeKind.Utc);
        //        var localDateTime = r.ToLocalTime();
        //        lastUpdated = localDateTime.ToString("MM/dd/yyyy h:mm tt");
        //        return lastUpdated;
        //    }
        //    set { }
        //}


    }
}