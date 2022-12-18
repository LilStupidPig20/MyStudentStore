using System.Data.Entity.Core;
using AutoMapper;
using RFT.Services.ServiceInterfaces;
using RTF.CQS.Abstractions;
using RTF.CQS.Commands;
using RTF.CQS.ModelsFromUI.ResponseModels;

namespace RTF.CQS.CommandHandlers;

public class GetExtendedEventInformationCommandHandler
    : CommandHandler<GetExtendedEventInformationCommand, ExtendedEventInfoFrame>
{
    private readonly IEventService _eventService;
    private readonly IMapper _mapper;

    public GetExtendedEventInformationCommandHandler(IEventService eventService, IMapper mapper)
    {
        _eventService = eventService;
        _mapper = mapper;
    }

    public override async Task<ExtendedEventInfoFrame> HandleWithResult(GetExtendedEventInformationCommand request,
        CancellationToken ct)
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