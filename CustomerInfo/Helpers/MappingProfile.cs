using AutoMapper;
using CustomerInfo.Dtos;
using CustomerInfo.Models;

namespace CustomerInfo.Helper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CustomerDto,Customer>()
                .ForMember(dest => dest.Addresses, opt => opt.Ignore())
                .ReverseMap();
            CreateMap<Address, AddressDto>()
              .ReverseMap();
            CreateMap<Customer, CreateCustomerDto>()
             .ReverseMap();
            CreateMap<Address, CreateAddressDto>()
             .ReverseMap();
        }
    }
}
