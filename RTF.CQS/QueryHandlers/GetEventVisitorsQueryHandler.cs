using RTF.AdminServices.Interfaces;
using RTF.CQS.Abstractions;
using RTF.CQS.ModelsFromUI.ResponseModels;
using RTF.CQS.Queries;

namespace RTF.CQS.QueryHandlers;

public class GetEventVisitorsQueryHandler : QueryHandler<GetEventVisitorsQuery, IReadOnlyList<VisitorFrame>>
{
    private readonly IEventAdminService _eventAdminService;

    public GetEventVisitorsQueryHandler(IEventAdminService eventAdminService)
    {
        _eventAdminService = eventAdminService;
    }

    public override async Task<IReadOnlyList<VisitorFrame>> Handle(GetEventVisitorsQuery request, CancellationToken ct)
    {
        var dataEvent = await _eventAdminService.GetEventWithVisitorsAsync(request.EventId, ct);
        return dataEvent.Users.Select(x => new VisitorFrame
            {
                Group = x.Group,
                FirstName = x.FirstName,
                LastName = x.LastName
            })
            .ToList();
    }
}