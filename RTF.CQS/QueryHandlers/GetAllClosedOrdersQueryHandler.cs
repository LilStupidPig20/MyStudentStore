using AutoMapper;
using RTF.AdminServices.Interfaces;
using RTF.CQS.Abstractions;
using RTF.CQS.ModelsFromUI.AdminResponseModels;
using RTF.CQS.Queries;

namespace RTF.CQS.QueryHandlers;

public class GetAllClosedOrdersQueryHandler : QueryHandler<GetAllClosedOrdersQuery, IReadOnlyList<AdminOrderFrame>>
{
    private readonly IAdminOrdersService _adminOrdersService;
    private readonly IMapper _mapper;

    public GetAllClosedOrdersQueryHandler(IAdminOrdersService adminOrdersService, IMapper mapper)
    {
        _adminOrdersService = adminOrdersService;
        _mapper = mapper;
    }

    public override async Task<IReadOnlyList<AdminOrderFrame>> Handle(GetAllClosedOrdersQuery request, CancellationToken ct)
    {
        var closedOrders = await _adminOrdersService.GetClosedOrders(ct);
        var result = closedOrders.Select(x => _mapper.Map<AdminOrderFrame>(x)).ToList();
        return result;
    }
}