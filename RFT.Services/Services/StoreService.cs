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

    public async Task<IReadOnlyList<StoreProduct>> GetAllProductsAsync()
    {
        var repo = _unitOfWork.GetRepository<StoreProduct>();
        var products = await repo.GetAllAsync();
        return products;
    }

    public async Task<StoreProduct> GetProduct(long id)
    {
        var repo = _unitOfWork.GetRepository<StoreProduct>();
        var products = await repo.GetAsync(id);
        return products;
    }
}