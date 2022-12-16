using AutoMapper;
using RTF.Core.Models;
using RTF.CQS.ModelsFromUI.ResponseModels;

namespace RTF.CQS.Converters;

public class CqsMappingProfile : Profile
{
    public CqsMappingProfile()
    {			
        CreateMap<Event, EventFrame>();
        CreateMap<Event, ExtendedEventInfoFrame>();
    }
}