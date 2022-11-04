using RFT.Services.ServiceInterfaces;
using RTF.Core.Infrastructure;
using RTF.Core.Models;
using RTF.CQS.Abstractions;
using RTF.CQS.Commands;

namespace RTF.CQS.CommandHandlers;

public class GetAllStudentsQueryHandler : QueryHandler<GetAllStudentsQuery, IList<Student>>
{
    private readonly IDbConnectionProvider _dbConnectionProvider;
    private readonly IStudentService _studentService;

    public GetAllStudentsQueryHandler(IDbConnectionProvider dbConnectionProvider, IStudentService studentService)
    {
        _dbConnectionProvider = dbConnectionProvider;
        _studentService = studentService;
    }

    public override async Task<IList<Student>> Handle(GetAllStudentsQuery request, CancellationToken ct)
    {
        await using var connection = _dbConnectionProvider.GetDbConnection();
        var result = await _studentService.GetAllStudents(connection);
        return result;
    }
}