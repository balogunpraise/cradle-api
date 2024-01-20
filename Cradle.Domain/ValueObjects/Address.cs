using System.Diagnostics.CodeAnalysis;

namespace Cradle.Domain.ValueObjects
{
    public class Address : IEqualityComparer<Address>
    {
        public string Id { get; set; }
        public string Street { get; private set; }
        public string City { get; private set; }
        public string State { get; private set; }
        public string Country { get; private set; }
        public string ZipCode { get; private set; }
        public bool Equals(Address x, Address y)
        {
            if (x == null) throw new ArgumentNullException($"{x} is null");
            return (x.Street.Equals(y.Street) && x.City.Equals(y.City) &&
                x.State.Equals(y.State) && x.Country.Equals(y.Country)
                && x.ZipCode.Equals(y.ZipCode));
        }

        public int GetHashCode([DisallowNull] Address obj)
        {
            return obj.Id.GetHashCode();
        }
    }
}
