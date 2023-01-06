using RTF.CQS.Abstractions;
using RTF.CQS.ModelsFromUI.ResponseModels;

namespace RTF.CQS.Queries;

public class GetCalendarInfoQuery : Query<EventCalendarFrame>
{
    public int MonthNumber { get; set; }
}