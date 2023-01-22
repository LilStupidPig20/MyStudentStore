using AutoMapper;
using RFT.Services.ServiceInterfaces;
using RTF.AdminServices.DtoModels;
using RTF.AdminServices.Interfaces;
using RTF.Core.Models;
using RTF.Core.Repositories;

namespace RTF.AdminServices.Services;

public class EventAdminService : IEventAdminService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly IStudentBalanceService _studentBalanceService;

    public EventAdminService(IUnitOfWork unitOfWork, IMapper mapper, IStudentBalanceService studentBalanceService)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _studentBalanceService = studentBalanceService;
    }

    public async Task CreateEventAsync(EventAdminDto eventAdminDto, CancellationToken cancellationToken)
    {
        var adminInfoRepo = _unitOfWork.GetRepository<AdminInfo>();
        var selectedAdmins = await
            adminInfoRepo.FindBy(x => eventAdminDto.Organizers.Contains(x.Id));
        var @event = _mapper.Map<Event>(eventAdminDto);
        @event.Organizers = (ICollection<AdminInfo>)selectedAdmins;
        var repo = _unitOfWork.GetRepository<Event>();
        await repo.AddAsync(@event);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }

    public async Task<Event> GetEventWithVisitorsAsync(Guid eventId, CancellationToken ct)
    {
        var repo = (EventRepository)_unitOfWork.GetRepository<Event>();
        var @event = await repo.GetEventIncludedVisitors(eventId, ct);
        if (@event == null)
        {
            throw new ArgumentException("Не удалось найти запрошенное мероприятие");
        }

        return @event;
    }

    public async Task CheckInUser(Guid userQr, Guid eventId, CancellationToken ct)
    {
        var eventRepo = (EventRepository)_unitOfWork.GetRepository<Event>();
        var @event = await eventRepo.GetEventIncludedVisitors(eventId, ct);
        if (@event == null)
        {
            throw new ArgumentException("Не удалось найти запрошенное мероприятие");
        }

        if (Math.Abs((@event.StartDateTime - DateTime.Now).TotalHours) >= 2)
        {
            throw new Exception("Запись доступна только за час до и после начала мероприятия");
        }

        var user = await _studentBalanceService.FindUserByQrAndIncreaseBalance(userQr, @event.Coins);
        @event.Users.Add(user);
        await eventRepo.UpdateAsync(@event);
        await _unitOfWork.SaveChangesAsync(ct);
    }
}