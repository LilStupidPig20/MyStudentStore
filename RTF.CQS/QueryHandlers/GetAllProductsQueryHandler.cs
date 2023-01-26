using AutoMapper;
using RFT.Services.ServiceInterfaces;
using RTF.CQS.Abstractions;
using RTF.CQS.ModelsFromUI.ResponseModels;
using RTF.CQS.Queries;

namespace RTF.CQS.QueryHandlers;

public class GetAllProductsQueryHandler : QueryHandler<GetAllProductsQuery, IReadOnlyList<ProductFrame>>
{
    private readonly IStoreService _storeService;
    private readonly IMapper _mapper;

    public GetAllProductsQueryHandler(IStoreService storeService, IMapper mapper)
    {
        _storeService = storeService;
        _mapper = mapper;
    }

    public override async Task<IReadOnlyList<ProductFrame>> Handle(GetAllProductsQuery request, CancellationToken ct)
    {
        var products = await _storeService.GetAllProductsAsync(ct);
        var result = products.Select(x => _mapper.Map<ProductFrame>(x));
        return result.ToList();
    }
}