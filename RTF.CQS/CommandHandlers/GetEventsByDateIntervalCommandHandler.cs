using AutoMapper;
using RFT.Services.ServiceInterfaces;
using RTF.CQS.Abstractions;
using RTF.CQS.Commands;
using RTF.CQS.ModelsFromUI.ResponseModels;

namespace RTF.CQS.CommandHandlers;

public class GetEventsByDateIntervalCommandHandler
    : CommandHandler<GetEventsByDateIntervalCommand, IReadOnlyList<EventFrame>>
{
    private readonly IEventService _eventService;
    private readonly IMapper _mapper;

    public GetEventsByDateIntervalCommandHandler(IEventService eventService, IMapper mapper)
    {
        _eventService = eventService;
        _mapper = mapper;
    }

    public override async Task<IReadOnlyList<EventFrame>> HandleWithResult(GetEventsByDateIntervalCommand request, CancellationToken ct)
    {
        var eventResult = await _eventService
            .GetEventsByDateInterval(request.StartDateTime, request.EndDateTime);
        return eventResult.Select(x => _mapper.Map<EventFrame>(x)).ToList();
    }
}