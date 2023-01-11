using AutoMapper;
using RTF.AdminServices.DtoModels;
using RTF.Core.Models;

namespace RTF.AdminServices.Converters;

public class AdminServicesMappingProfile : Profile
{
    public AdminServicesMappingProfile()
    {			
        CreateMap<AdminInfoDto, AdminInfo>().ReverseMap();
        CreateMap<EventAdminDto, Event>().ForMember(x => x.Organizers, x =>
            x.MapFrom(y => new List<AdminInfo>()));;
    }
}