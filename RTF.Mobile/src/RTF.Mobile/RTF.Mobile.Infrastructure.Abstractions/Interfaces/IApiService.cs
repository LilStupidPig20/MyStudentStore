using RTF.Mobile.Infrastructure.Abstractions.Models;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace RTF.Mobile.Infrastructure.Abstractions.Interfaces
{
    public interface IApiService
    {
        Task<IEnumerable<EventDto>> GetEventsAsync(CancellationToken cancellationToken = default);

        Task<LoginResponseDto> LoginAsync(LoginDto loginDto, CancellationToken cancellationToken = default);

        Task RegisterAsync(RegisterDto registerDto, CancellationToken cancellationToken = default);
    }
}
