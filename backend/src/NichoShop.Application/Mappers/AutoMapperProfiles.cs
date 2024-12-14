using AutoMapper;
using NichoShop.Application.Models.Dtos.Request.User;
using NichoShop.Application.Models.Dtos.Request.UserAddress;
using NichoShop.Domain.AggergateModels.UserAggregate;

namespace NichoShop.Application.Mappers;

public class AutoMapperProfiles : Profile
{
    public AutoMapperProfiles()
    {
        CreateMap<UserAddress, UserAddressDto>()
            .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.PhoneNumber.Value));

        CreateMap<User, UserInfoDto>()
           .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.PhoneNumber.Value));
    }
}
