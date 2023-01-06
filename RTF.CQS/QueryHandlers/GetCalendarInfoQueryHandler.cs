using System.Globalization;
using RFT.Services.ServiceInterfaces;
using RTF.Core.Models.Enums;
using RTF.CQS.Abstractions;
using RTF.CQS.Commands;
using RTF.CQS.ModelsFromUI.ResponseModels;
using RTF.CQS.Queries;

namespace RTF.CQS.QueryHandlers;

public class GetCalendarInfoQueryHandler : QueryHandler<GetCalendarInfoQuery, EventCalendarFrame>
{
    private readonly IEventService _eventService;

    public GetCalendarInfoQueryHandler(IEventService eventService)
    {
        _eventService = eventService;
    }

    public override async Task<EventCalendarFrame> Handle(GetCalendarInfoQuery request, CancellationToken ct)
    {
        var eventsResult = await _eventService.GetEventsByMonth(request.MonthNumber);
        
        var info = CultureInfo.GetCultureInfo("ru-RU").DateTimeFormat;
        var monthName = info.MonthNames[request.MonthNumber - 1];

        var dictionaryEvent = new Dictionary<int, List<EventType>>();
        foreach (var @event in eventsResult)
        {
            var day = @event.StartDateTime.Day;
            if (dictionaryEvent.ContainsKey(day))
            {
                dictionaryEvent[day].Add(@event.EventType);
            }
            
            dictionaryEvent.Add(day, new List<EventType>() {@event.EventType});
        }

        return new EventCalendarFrame
        {
            Month = monthName,
            DayToEventsList = dictionaryEvent
        };
    }
}