using RTF.AdminServices.DtoModels;

namespace RTF.AdminServices.Interfaces;

public interface IAdminInfoService
{
    Task<AdminInfoDto> GetAdminByIdAsync(Guid id);
    
    Task CreateAdminInfoAsync(AdminInfoDto adminInfoDto, CancellationToken cancellationToken);

    Task<IReadOnlyList<AdminInfoDto>> GetAllAdminsAsync(CancellationToken cancellationToken);
}