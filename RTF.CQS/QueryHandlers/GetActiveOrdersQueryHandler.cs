using AutoMapper;
using RTF.AdminServices.Interfaces;
using RTF.CQS.Abstractions;
using RTF.CQS.ModelsFromUI.AdminResponseModels;
using RTF.CQS.Queries;

namespace RTF.CQS.QueryHandlers;

public class GetActiveOrdersQueryHandler : QueryHandler<GetActiveOrdersQuery, IReadOnlyList<AdminOrderFrame>>
{
    private readonly IAdminOrdersService _adminOrdersService;
    private readonly IMapper _mapper;

    public GetActiveOrdersQueryHandler(IAdminOrdersService adminOrdersService, IMapper mapper)
    {
        _adminOrdersService = adminOrdersService;
        _mapper = mapper;
    }

    public override async Task<IReadOnlyList<AdminOrderFrame>> Handle(GetActiveOrdersQuery request, CancellationToken ct)
    {
        var closedOrders = await _adminOrdersService.GetActiveOrders(ct);
        var result = closedOrders.Select(x => _mapper.Map<AdminOrderFrame>(x)).ToList();
        return result;
    }
}