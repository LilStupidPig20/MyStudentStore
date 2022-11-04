using RTF.Core.Models;
using RTF.Core.Repositories;

namespace RFT.Services.ServiceInterfaces;

public interface IStudentService
{
    Task<IList<Student>> GetAllStudents(ConnectionContext connection);
}