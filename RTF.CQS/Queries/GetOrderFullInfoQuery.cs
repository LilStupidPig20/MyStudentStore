using RTF.CQS.Abstractions;
using RTF.CQS.ModelsFromUI.AdminResponseModels;

namespace RTF.CQS.Queries;

public class GetOrderFullInfoQuery : Query<AdminOrderExtendedInfo>
{
    public Guid OrderId { get; set; }
}