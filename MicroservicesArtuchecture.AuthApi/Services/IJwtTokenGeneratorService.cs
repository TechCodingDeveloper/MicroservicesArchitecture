using MicroservicesArtuchecture.AuthApi.Storage.Models;

namespace MicroservicesArtuchecture.AuthApi.Services
{
    public interface IJwtTokenGeneratorService
    {
        string GenerateToken(UserEntity user);
    }
}
