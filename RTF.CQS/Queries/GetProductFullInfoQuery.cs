using RTF.CQS.Abstractions;
using RTF.CQS.ModelsFromUI.ResponseModels;

namespace RTF.CQS.Queries;

public class GetProductFullInfoQuery : Query<ExtendedProductInfoFrame>
{
    public Guid ProductId { get; set; }
}