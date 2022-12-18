using RTF.CQS.Abstractions;
using RTF.CQS.ModelsFromUI.ResponseModels;

namespace RTF.CQS.Commands;

public class GetAllProductsCommand : Command<IReadOnlyList<ProductFrame>>
{
}