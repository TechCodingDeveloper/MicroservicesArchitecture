using MicroservicesArtuchecture.AuthApi.Contracts;
using MicroservicesArtuchecture.AuthApi.Contracts.Request;
using MicroservicesArtuchecture.AuthApi.Contracts.Response;
using MicroservicesArtuchecture.AuthApi.Storage.Context;
using MicroservicesArtuchecture.AuthApi.Storage.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.EntityFrameworkCore;
using Utility.Contracts;

namespace MicroservicesArtuchecture.AuthApi.Services
{
    public interface IAuthService
    {
        Task<MessageContract<LoginResponseContract>> Login(LoginRequestContract login);
        Task<MessageContract<UserContract>> Register(RegisterRequestContract register);
        Task<MessageContract<bool>> AssignRole(UserContract user,string roleName);
    }
}
