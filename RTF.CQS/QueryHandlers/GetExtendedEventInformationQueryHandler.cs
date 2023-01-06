using System.Data.Entity.Core;
using AutoMapper;
using RFT.Services.ServiceInterfaces;
using RTF.CQS.Abstractions;
using RTF.CQS.Commands;
using RTF.CQS.ModelsFromUI.ResponseModels;
using RTF.CQS.Queries;

namespace RTF.CQS.QueryHandlers;

public class GetExtendedEventInformationQueryHandler : QueryHandler<GetExtendedEventInformationQuery, ExtendedEventInfoFrame>
{
    private readonly IEventService _eventService;
    private readonly IMapper _mapper;

    public GetExtendedEventInformationQueryHandler(IEventService eventService, IMapper mapper)
    {
        _eventService = eventService;
        _mapper = mapper;
    }

    public override async Task<ExtendedEventInfoFrame> Handle(GetExtendedEventInformationQuery request, CancellationToken ct)
    {
        if (request.EventId == null)
        {
            throw new ArgumentNullException("Передача недопустимый null параметра");
        }

        var resultEvent = await _eventService.GetEventById(request.EventId.Value);
        if (resultEvent == null)
        {
            throw new ObjectNotFoundException($"Объект с переданным идентификатором {request.EventId} не существует");
        }

        return _mapper.Map<ExtendedEventInfoFrame>(resultEvent);
    }
}