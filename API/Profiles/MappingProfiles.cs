using API.Dtos;
using AutoMapper;
using Domain.Entities;

namespace API.Profiles;
public class MappingProfiles : Profile
{
    public MappingProfiles(){

        CreateMap<User, BasicUserDto>().ReverseMap();
        CreateMap<User, UserDto>().ReverseMap();

        CreateMap<Vehicle, VehicleDto>().ReverseMap();
        CreateMap<Vehicle, BasicVehicleDto>().ReverseMap();
        
    }

}