using RFT.Services.ServiceInterfaces;
using RTF.Core.Models;
using RTF.Core.Repositories;

namespace RFT.Services.Services;

public class StoreService : IStoreService
{
    private readonly IUnitOfWork _unitOfWork;

    public StoreService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IReadOnlyList<StoreProduct>> GetAllProductsAsync(CancellationToken ct)
    {
        var repo = (ProductRepository)_unitOfWork.GetRepository<StoreProduct>();
        var products = await repo.LoadAllProductsIncludedClothes(ct);
        return products;
    }

    public async Task<StoreProduct> GetProduct(Guid id)
    {
        var repo = _unitOfWork.GetRepository<StoreProduct>();
        var products = await repo.GetAsync(id);
        return products;
    }
}