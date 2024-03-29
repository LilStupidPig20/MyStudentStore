using RTF.AdminServices.Interfaces;
using RTF.CQS.Abstractions;
using RTF.CQS.Commands;
using RTF.CQS.ModelsFromUI.ResponseModels;
using RTF.CQS.Queries;

namespace RTF.CQS.QueryHandlers;

public class GetAllOrganizersQueryHandler : QueryHandler<GetAllOrganizersQuery, IReadOnlyList<OrganizerFrame>>
{
    private readonly IAdminInfoService _adminInfoService;

    public GetAllOrganizersQueryHandler(IAdminInfoService adminInfoService)
    {
        _adminInfoService = adminInfoService;
    }

    public override async Task<IReadOnlyList<OrganizerFrame>> Handle(GetAllOrganizersQuery request, CancellationToken ct)
    {
        var adminsDto = await _adminInfoService.GetAllAdminsAsync(ct);
        var result = adminsDto.Select(x => new OrganizerFrame
        {
            Id = x.Id,
            FullName = $"{x.LastName} {x.FirstName}"
        });
        return result.ToList();
    }
}