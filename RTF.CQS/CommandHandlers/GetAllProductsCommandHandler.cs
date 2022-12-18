using AutoMapper;
using RFT.Services.ServiceInterfaces;
using RTF.CQS.Abstractions;
using RTF.CQS.Commands;
using RTF.CQS.ModelsFromUI.ResponseModels;

namespace RTF.CQS.CommandHandlers;

public class GetAllProductsCommandHandler : CommandHandler<GetAllProductsCommand, IReadOnlyList<ProductFrame>>
{
    private readonly IStoreService _storeService;
    private readonly IMapper _mapper;

    public GetAllProductsCommandHandler(IStoreService storeService, IMapper mapper)
    {
        _storeService = storeService;
        _mapper = mapper;
    }

    public override async Task<IReadOnlyList<ProductFrame>> HandleWithResult(GetAllProductsCommand request,
        CancellationToken ct)
    {
        var products = await _storeService.GetAllProductsAsync();
        var result = products.Select(x => _mapper.Map<ProductFrame>(x));
        return result.ToList();
    }
}