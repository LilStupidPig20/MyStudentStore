using RTF.Core.Models;

namespace RFT.Services.ServiceInterfaces;

public interface IStoreService
{
    Task<IReadOnlyList<StoreProduct>> GetAllProductsAsync(CancellationToken ct);

    Task<StoreProduct> GetProduct(Guid id, CancellationToken ct);
}