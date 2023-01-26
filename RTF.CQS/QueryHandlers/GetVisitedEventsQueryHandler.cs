using AutoMapper;
using RFT.Services.ServiceInterfaces;
using RTF.CQS.Abstractions;
using RTF.CQS.ApplicationServices;
using RTF.CQS.Commands;
using RTF.CQS.ModelsFromUI.ResponseModels;
using RTF.CQS.Queries;

namespace RTF.CQS.QueryHandlers;

public class GetVisitedEventsQueryHandler : QueryHandler<GetVisitedEventsQuery, IReadOnlyList<EventFrame>>
{
    private readonly IEventService _eventService;
    private readonly ICurrentUserProvider _currentUserProvider;
    private readonly IMapper _mapper;

    public GetVisitedEventsQueryHandler(IEventService eventService,
        ICurrentUserProvider currentUserProvider,
        IMapper mapper)
    {
        _eventService = eventService;
        _currentUserProvider = currentUserProvider;
        _mapper = mapper;
    }

    public override async Task<IReadOnlyList<EventFrame>> Handle(GetVisitedEventsQuery request, CancellationToken ct)
    {
        var currentUser = await _currentUserProvider.GetCurrentUserAsync();
        var visitedEvents = await _eventService.GetVisitedEventsByUserAsync(Guid.Parse(currentUser.Id), ct);
        return visitedEvents.Select(x => _mapper.Map<EventFrame>(x)).ToList();
    }
}