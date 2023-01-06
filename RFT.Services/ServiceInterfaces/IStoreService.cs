using RTF.Core.Models;

namespace RFT.Services.ServiceInterfaces;

public interface IStoreService
{
    Task<IReadOnlyList<StoreProduct>> GetAllProductsAsync();

    Task<StoreProduct> GetProduct(Guid id);
}