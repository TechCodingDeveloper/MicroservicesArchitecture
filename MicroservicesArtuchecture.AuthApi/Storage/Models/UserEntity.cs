﻿using Microsoft.AspNetCore.Identity;

namespace MicroservicesArtuchecture.AuthApi.Storage.Models
{
    public class UserEntity:IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
