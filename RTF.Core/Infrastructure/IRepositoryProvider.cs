using Microsoft.EntityFrameworkCore;
using RTF.Core.Models;
using RTF.Core.Repositories;

namespace RTF.Core.Infrastructure;

public interface IRepositoryProvider
{
    StudentRepository StudentRepository(ConnectionContext context);
}