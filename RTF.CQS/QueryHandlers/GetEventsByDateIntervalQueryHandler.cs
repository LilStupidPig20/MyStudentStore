using AutoMapper;
using RFT.Services.ServiceInterfaces;
using RTF.CQS.Abstractions;
using RTF.CQS.Commands;
using RTF.CQS.ModelsFromUI.ResponseModels;
using RTF.CQS.Queries;

namespace RTF.CQS.QueryHandlers;

public class GetEventsByDateIntervalQueryHandler : QueryHandler<GetEventsByDateIntervalQuery, IReadOnlyList<EventFrame>>
{
    private readonly IEventService _eventService;
    private readonly IMapper _mapper;

    public GetEventsByDateIntervalQueryHandler(IEventService eventService, IMapper mapper)
    {
        _eventService = eventService;
        _mapper = mapper;
    }

    public override async Task<IReadOnlyList<EventFrame>> Handle(GetEventsByDateIntervalQuery request, CancellationToken ct)
    {
        var eventResult = await _eventService
            .GetEventsByDateInterval(request.StartDateTime, request.EndDateTime);
        return eventResult.Select(x => _mapper.Map<EventFrame>(x)).ToList();
    }
}