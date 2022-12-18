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
    
    public async Task<IReadOnlyList<Event>> GetVisitedEventsByUserAsync(Guid userId)
    {
        var repo = _unitOfWork.GetRepository<Event>();
        var a = await repo.GetAllAsync();
        var visitedEvents = await repo
            .FindBy(e => e.Users.Any(x => x.Id == userId) && e.IsFinished);
        return visitedEvents;
    }

    public async Task<Event?> GetEventById(long eventId)
    {
        var repo = _unitOfWork.GetRepository<Event>();
        var eventResult = await repo.FindOneBy(x => x.Id == eventId);
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
            .FindBy(x => x.StartDateTime.Date > startDate.Date && x.StartDateTime.Date < endTime.Date);
        return visitedEvents;
    }
}