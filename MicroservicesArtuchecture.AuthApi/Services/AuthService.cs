using MicroservicesArtuchecture.AuthApi.Contracts;
using MicroservicesArtuchecture.AuthApi.Contracts.Request;
using MicroservicesArtuchecture.AuthApi.Contracts.Response;
using MicroservicesArtuchecture.AuthApi.Storage.Context;
using MicroservicesArtuchecture.AuthApi.Storage.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.Data;
using Utility.Contracts;

namespace MicroservicesArtuchecture.AuthApi.Services
{
    public class AuthService
    {
        private readonly DatabaseContext _db;
        private readonly UserManager<UserEntity> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AuthService(DatabaseContext db, UserManager<UserEntity> userManager, RoleManager<IdentityRole> roleManager)
        {
            _db = db;
            _userManager = userManager;
            _roleManager = roleManager;
        }
        public Task<LoginResponseContract> Login(LoginRequestContract login)
        {
            throw new NotImplementedException();
        }
        public async Task<MessageContract<UserContract>> Register(RegisterRequestContract register)
        {
            UserEntity user = new UserEntity()
            {
                UserName = register.Email,
                Email = register.Email,
                NormalizedEmail = register.Email.ToLower(),
                FirstName = register.FirstName,
                LastName = register.LastName,
                PhoneNumber = register.PhoneNumber,
            };
            try
            {
                var result = await _userManager.CreateAsync(user, register.Password);
                if (result.Succeeded)
                {
                    var userToReturn = _db.Users.First(dr => dr.UserName == user.UserName);

                    return new UserContract()
                    {
                        Email = user.Email,
                        ID = user.Id,
                        FirstName = user.FirstName,
                        LastName = user.LastName,
                        PhoneNumber = user.PhoneNumber,
                    }.ToContract();
                }else
                {
                    return result.Errors.FirstOrDefault().Description.ToFailContract<UserContract>();
                }
            }
            catch (Exception)
            {

                throw;
            }

            return null;
        }
    }
}
