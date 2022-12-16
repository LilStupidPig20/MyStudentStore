using AutoMapper;
using RFT.Services.ServiceInterfaces;
using RTF.CQS.Abstractions;
using RTF.CQS.ApplicationServices;
using RTF.CQS.Commands;
using RTF.CQS.ModelsFromUI.ResponseModels;

namespace RTF.CQS.CommandHandlers;

public class GetVisitedEventsCommandHandler : CommandHandler<GetVisitedEventsCommand, IReadOnlyList<EventFrame>>
{
    private readonly IEventService _eventService;
    private readonly ICurrentUserProvider _currentUserProvider;
    private readonly IMapper _mapper;

    public GetVisitedEventsCommandHandler(IEventService eventService,
        ICurrentUserProvider currentUserProvider,
        IMapper mapper)
    {
        _eventService = eventService;
        _currentUserProvider = currentUserProvider;
        _mapper = mapper;
    }

    public override async Task<IReadOnlyList<EventFrame>> HandleWithResult(GetVisitedEventsCommand request, CancellationToken ct)
    {
        var currentUser = await _currentUserProvider.GetCurrentUserAsync();
        var visitedEvents = await _eventService.GetVisitedEventsByUserAsync(Guid.Parse(currentUser.Id));
        return visitedEvents.Select(x => _mapper.Map<EventFrame>(x)).ToList();
    }
}