using RFT.Services.ServiceInterfaces;
using RTF.Core.Models;
using RTF.Core.Repositories;

namespace RFT.Services.Services;

public class EventService : IEventService
{
    private readonly IUnitOfWork _unitOfWork;

    public EventService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    
    public async Task<IReadOnlyList<Event>> GetVisitedEventsByUserAsync(Guid userId, CancellationToken ct)
    {
        var repo = (UserInfoRepository)_unitOfWork.GetRepository<UserInfo>();
        var user = await repo.GetUserIncludedVisitedEvents(userId, ct);
        if (user == null)
        {
            throw new ArgumentException("Пользователь не найден");
        }

        return user.VisitedEvents.ToList();
    }

    public async Task<Event?> GetEventById(Guid eventId, CancellationToken ct)
    {
        var repo = (EventRepository)_unitOfWork.GetRepository<Event>();
        var eventResult = await repo.GetEventIncludedOrganizers(eventId, ct);
        return eventResult;
    }

    public async Task<IReadOnlyList<Event>> GetEventsByMonth(int month)
    {
        var repo = _unitOfWork.GetRepository<Event>();
        var visitedEvents = await repo
            .FindBy(x => x.StartDateTime.Date.Month == month);
        return visitedEvents;
    }

    public async Task<IReadOnlyList<Event>> GetEventsByDateInterval(DateTime startDate, DateTime endTime)
    {
        var repo = _unitOfWork.GetRepository<Event>();
        var visitedEvents = await repo
            .FindBy(x => x.StartDateTime.Date >= startDate.Date && x.StartDateTime.Date <= endTime.Date);
        return visitedEvents;
    }
}