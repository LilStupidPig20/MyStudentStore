using RTF.CQS.Abstractions;
using RTF.CQS.ModelsFromUI.ResponseModels;

namespace RTF.CQS.Commands;

public class GetAllOrganizersCommand : Command<IReadOnlyList<OrganizerFrame>>
{
}