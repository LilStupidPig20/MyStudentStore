using RTF.Core.Models;
using RTF.CQS.Abstractions;

namespace RTF.CQS.Commands;

public class GetAllStudentsQuery : Query<IList<Student>>
{
}