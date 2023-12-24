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
    public class AuthService: IAuthService
    {
        private readonly DatabaseContext _db;
        private readonly UserManager<UserEntity> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IJwtTokenGeneratorService _jwtTokenGeneratorService;

        public AuthService(DatabaseContext db, UserManager<UserEntity> userManager, RoleManager<IdentityRole> roleManager, IJwtTokenGeneratorService jwtTokenGeneratorService)
        {
            _db = db;
            _userManager = userManager;
            _roleManager = roleManager;
            _jwtTokenGeneratorService = jwtTokenGeneratorService;   
        }
        public async Task<MessageContract<LoginResponseContract>> Login(LoginRequestContract login)
        {
            //check user exist
            var user = await _db.Users.FirstOrDefaultAsync(dr => dr.UserName.ToLower() == login.UserName.ToLower() || dr.Email.ToLower() == login.Email.ToLower() || dr.PhoneNumber.ToLower() == login.PhoneNumber.ToLower());

            if (user is null)
                return "User and Password is not correct".ToFailContract<LoginResponseContract>();

            //check password valid
            bool isValid = await _userManager.CheckPasswordAsync(user, login.Password);

            if (isValid == false)
                return "User and Password is not correct".ToFailContract<LoginResponseContract>();

            // if user was found, Generate JWT Token
           string token = _jwtTokenGeneratorService.GenerateToken(user);

            var userResponse = new LoginResponseContract()
            {
                User = new UserContract()
                {
                    Email = user.Email,
                    PhoneNumber = user.PhoneNumber,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    ID = user.Id
                },
                Token = token
            };

            return userResponse.ToContract();
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
                }
                else
                {
                    return result.Errors.FirstOrDefault().Description.ToFailContract<UserContract>();
                }
            }
            catch (Exception ex)
            {
                return ex.ToFailContract<UserContract>();
            }

        }
    }
}
