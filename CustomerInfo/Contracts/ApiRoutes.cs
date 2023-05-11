namespace CustomerInfo.Contracts
{
    public class ApiRoutes
    {
        public static class Customer
        {
            public const string GetCustomers = "api/customers";
            public const string GetCustomer = "api/customer/{id}";
            public const string CreateCustomer = "api/customer";
            public const string GetCustomersByCity = "api/city/{cityName}";

        }
        public static class Address
        {
            public const string GetAddresses = "api/addresses";
            public const string CreateAddress = "api/customer/{customerId}/address";
            public const string DeleteAddress = "api/customer/{customerId}/address/{addressId}";
        }
    }
}
