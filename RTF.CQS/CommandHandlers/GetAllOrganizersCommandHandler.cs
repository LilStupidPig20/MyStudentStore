using RTF.AdminServices.Interfaces;
using RTF.CQS.Abstractions;
using RTF.CQS.Commands;
using RTF.CQS.ModelsFromUI.ResponseModels;

namespace RTF.CQS.CommandHandlers;

public class GetAllOrganizersCommandHandler : CommandHandler<GetAllOrganizersCommand, IReadOnlyList<OrganizerFrame>>
{
    private readonly IAdminInfoService _adminInfoService;

    public GetAllOrganizersCommandHandler(IAdminInfoService adminInfoService)
    {
        _adminInfoService = adminInfoService;
    }

    public override async Task<IReadOnlyList<OrganizerFrame>> HandleWithResult(GetAllOrganizersCommand request,
        CancellationToken ct)
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