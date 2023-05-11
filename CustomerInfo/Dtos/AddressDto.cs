using CustomerInfo.Models;

namespace CustomerInfo.Dtos
{
    public class AddressDto
    {
        public Guid Id { get; set; }
        public string TypeOfaddress { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string AddressLine { get; set; }
    }
}
