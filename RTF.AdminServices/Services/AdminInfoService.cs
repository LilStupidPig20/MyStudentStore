using AutoMapper;
using RTF.AdminServices.DtoModels;
using RTF.AdminServices.Interfaces;
using RTF.Core.Models;
using RTF.Core.Repositories;

namespace RTF.AdminServices.Services;

public class AdminInfoService : IAdminInfoService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public AdminInfoService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<AdminInfoDto> GetAdminByIdAsync(Guid id)
    {
        var repo = _unitOfWork.GetRepository<AdminInfo>();
        var admin = await repo.FindOneBy(x => x.Id == id);
        return _mapper.Map<AdminInfoDto>(admin);
    }

    public async Task CreateAdminInfoAsync(AdminInfoDto adminInfoDto, CancellationToken cancellationToken)
    {
        var repo = _unitOfWork.GetRepository<AdminInfo>();
        await repo.AddAsync(new AdminInfo
        {
            Id = adminInfoDto.Id,
            Email = adminInfoDto.Email,
            Group = adminInfoDto.Group,
            FirstName = adminInfoDto.FirstName,
            LastName = adminInfoDto.LastName,
        });
        await _unitOfWork.SaveChangesAsync(cancellationToken); 
    }

    public async Task<IReadOnlyList<AdminInfoDto>> GetAllAdminsAsync(CancellationToken cancellationToken)
    {
        var repo = _unitOfWork.GetRepository<AdminInfo>();
        var admins = await repo.GetAllAsync();
        var adminsDto = admins.Select(x => new AdminInfoDto
        {
            Id = x.Id,
            Email = x.Email,
            Group = x.Group,
            FirstName = x.FirstName,
            LastName = x.LastName
        })
        .ToList();
        return adminsDto;
    }
}