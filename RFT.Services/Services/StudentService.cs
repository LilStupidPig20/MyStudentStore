using RFT.Services.ServiceInterfaces;
using RTF.Core.Infrastructure;
using RTF.Core.Models;
using RTF.Core.Repositories;

namespace RFT.Services.Services;

public class StudentService : IStudentService
{
    private readonly IRepositoryProvider _repositoryProvider;

    public StudentService(IRepositoryProvider repositoryProvider)
    {
        _repositoryProvider = repositoryProvider;
    }

    public async Task<IList<Student>> GetAllStudents(ConnectionContext connection)
    {
        var usersRepo = _repositoryProvider.StudentRepository(connection);
        var users = await usersRepo.GetAllAsync();
        return users;
    }
}