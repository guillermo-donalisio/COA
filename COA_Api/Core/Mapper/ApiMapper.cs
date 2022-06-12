using AutoMapper;
using COA_Api.Core.Models.DTOs;
using COA_Api.Entities;

namespace COA_Api.Core.Mapper;

public class ApiMapper : Profile
{
    public ApiMapper()
    {
        #region Mapper Users      
        CreateMap<User, UserGetDTO>().ReverseMap();
        CreateMap<User, UserGetStateDTO>().ReverseMap();
        CreateMap<User, UserCreateDTO>().ReverseMap();
        CreateMap<User, UserUpdateDTO>().ReverseMap();
        #endregion        
    }
}
