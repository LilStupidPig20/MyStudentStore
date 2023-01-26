using RTF.AdminServices.Interfaces;
using RTF.CQS.Abstractions;
using RTF.CQS.ModelsFromUI.AdminResponseModels;
using RTF.CQS.Queries;

namespace RTF.CQS.QueryHandlers;

public class GetOrderTypesQueryHandler : QueryHandler<GetOrderTypesQuery, OrderTypesFrame>
{
    private readonly IAdminOrdersService _adminOrdersService;

    public GetOrderTypesQueryHandler(IAdminOrdersService adminOrdersService)
    {
        _adminOrdersService = adminOrdersService;
    }

    public override Task<OrderTypesFrame> Handle(GetOrderTypesQuery request, CancellationToken ct)
    {
        var typesDict = _adminOrdersService.GetOrderTypes();
        var result = new OrderTypesFrame
        {
            StatusAsIntToStringName = typesDict
        };
        return Task.FromResult(result);
    }
}