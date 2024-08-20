using SharedKernel;

namespace BranchDomain
{
    public class Address : ValueObject
    {
        protected override IEnumerable<object> GetAtomicValue()
        {
            yield return Country;
            yield return City;
            yield return Street;
            yield return BuildingNumber ;

        }
        // if we want to change country , we must user method like this
        public Address GetNewUpdatedAddress(string newCountry)
        {
            return new Address
            {
                Country = newCountry,
                City = City,
                Street = Street,
                BuildingNumber = BuildingNumber
            };
        }

        public string Country { get;private set; }
        public string City { get;private set; }
        public string Street { get;private set; }
        public int BuildingNumber { get;private set; }
    }
}