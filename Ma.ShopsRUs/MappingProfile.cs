using AutoMapper;
using Ma.ShopsRUs.Entities;
using Ma.ShopsRUs.Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ma.ShopsRUs
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Resource Maps
            CreateMap<Users, CustomerUsersDto>()
                .ForMember(cdto => cdto.FullName,
                copt => copt.MapFrom(c => string.Join(" ", c.LastName, c.MiddleName, c.FirstName)))
                .ForMember(cdto => cdto.JoinedIn,
                opt => opt.MapFrom(c => c.DateCreated.Date.ToLongDateString()));

            CreateMap<Invoice, InvoiceDto>();
            CreateMap<DiscountType, DiscountDto>();

            // Create maps
            CreateMap<CreateCustomerUserDto, Users>();
            CreateMap<CreateDiscountDto, DiscountType>();
        }
    }
}
