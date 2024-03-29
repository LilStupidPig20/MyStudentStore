﻿using RTF.Core.Models;

namespace RFT.Services.ServiceInterfaces;

public interface IEventService
{
    Task<IReadOnlyList<Event>> GetVisitedEventsByUserAsync(Guid userId, CancellationToken ct);

    Task<Event?> GetEventById(Guid eventId, CancellationToken ct);
    
    Task<IReadOnlyList<Event>> GetEventsByMonth(int month);
    
    Task<IReadOnlyList<Event>> GetEventsByDateInterval(DateTime startDate, DateTime endTime);
}