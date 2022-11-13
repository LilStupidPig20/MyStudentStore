using System.Security.Claims;
using RTF.CQS.Abstractions;

namespace RTF.CQS.Commands;

public class GetCurrentUserBalance : Command<double>
{
    public ClaimsPrincipal CurrentUserClaims { get; set; }
}