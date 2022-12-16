using RTF.CQS.Abstractions;
using RTF.CQS.ModelsFromUI.ResponseModels;

namespace RTF.CQS.Commands;

public class GetCalendarInfoCommand : Command<EventCalendarFrame>
{
    public int MonthNumber { get; set; }
}