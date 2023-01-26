using RFT.Services.ServiceInterfaces;
using RTF.CQS.Abstractions;
using RTF.CQS.ApplicationServices;
using RTF.CQS.Queries;

namespace RTF.CQS.QueryHandlers;

public class GetStudentQrIdHandler : QueryHandler<GetStudentQrId, Guid>
{
    private readonly ICurrentUserProvider _currentUserProvider;
    private readonly IUserInfoService _userInfoService;

    public GetStudentQrIdHandler(ICurrentUserProvider currentUserProvider, IUserInfoService userInfoService)
    {
        _currentUserProvider = currentUserProvider;
        _userInfoService = userInfoService;
    }

    public override async Task<Guid> Handle(GetStudentQrId request, CancellationToken ct)
    {
        var currentUserId = (await _currentUserProvider.GetCurrentUserAsync()).Id;
        var result = await _userInfoService.GetStudentQrGuid(Guid.Parse(currentUserId));
        return result;
    }
}