using System.Threading.Tasks;
using Authentication.Core.DTOs;

namespace Authentication.Core.Interfaces.Services
{
    public interface IAuthenticationService
    {
        Task<AuthenticateResponseDTO> AuthenticationAsync(AuthenticateRequestDTO dto);
    }
}