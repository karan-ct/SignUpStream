using System;
using Microsoft.AspNetCore.Identity;
using SignUpStream.Infra.Models;

namespace SignUpStream.Infra.Interfaces
{
	public interface IIdentityService
	{
        Task<string?> GetUserNameAsync(string userId);
        Task<bool> AuthorizeAsync(string userId, string policyName);
        Task<(IdentityResult Result, string UserId)> CreateUserAsync(UserVM user);
    }
}

