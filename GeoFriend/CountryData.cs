using System.Diagnostics.Metrics;
using System.Linq;

namespace GeoFriend
{
    public class CountryData
    {
        protected Country[] Countries { get; set; }

        public CountryData(string fn)
        {
            var data = System.IO.File.ReadAllLines(fn);
            Countries = (from z in data.Skip(1)
                         select new Country(z)).ToArray();
        }
        public string GetCapital(string country)
        {
            return Countries.FirstOrDefault(
                c => c.Name.ToLower() == country.ToLower())?.Capital;
        }
    }
    public class Country
    {
        public Country(string s)
        {
            var t = s.Split(',');
            Capital = t[0].Trim('"');
            Name = t[4].Trim('"');
            float res;
            Population = float.TryParse(t[9].Trim('"'), out res) ? (int)res : 0;
        }

        public string Name { get; set; }
        public string Capital { get; set; }
        public int Population { get; set; }
    }
}
