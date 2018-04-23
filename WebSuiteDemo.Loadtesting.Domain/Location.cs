using System;
using WebSuiteDDD.SharedKernel;

namespace WebSuiteDemo.Loadtesting.Domain
{
    public class Location : ValueObjectBase<Location>
    {
    public string City { get; }
    public string Country { get; }

    public Location(string city, string country)
    {
        City = city ?? throw new ArgumentNullException(nameof(city));
        Country = country ?? throw new ArgumentNullException(nameof(country));
    }

    public Location WithCity(string city)
    {
        return new Location(city, Country);
    }

    public Location WithCountry(string country)
    {
        return new Location(City, country);
    }

        public override bool Equals(Location other)
        {
            if (other == null) return false;
            return City.Equals(other.City, StringComparison.InvariantCultureIgnoreCase)
                   && Country.Equals(other.Country, StringComparison.InvariantCultureIgnoreCase);
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (!(obj is Location)) return false;
            return Equals((Location) obj);
        }

        public override int GetHashCode()
        {
            return City.GetHashCode() + Country.GetHashCode();
        }
    }
}
