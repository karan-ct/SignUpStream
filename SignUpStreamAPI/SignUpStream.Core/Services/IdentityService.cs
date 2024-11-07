using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using SignUpStream.Data.Entities;
using SignUpStream.Infra.Interfaces;
using SignUpStream.Infra.Models;

namespace SignUpStream.Core.Services
{
    public class IdentityService : IIdentityService
    {
        private readonly UserManager<User> _userManager;
        private readonly IUserClaimsPrincipalFactory<User> _userClaimsPrincipalFactory;
        private readonly IAuthorizationService _authorizationService;

        public IdentityService(
            UserManager<User> userManager,
            IUserClaimsPrincipalFactory<User> userClaimsPrincipalFactory,
            IAuthorizationService authorizationService)
        {
            _userManager = userManager;
            _userClaimsPrincipalFactory = userClaimsPrincipalFactory;
            _authorizationService = authorizationService;
        }

        public async Task<string?> GetUserNameAsync(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);

            return user?.UserName;
        }

        public async Task<(IdentityResult Result, string UserId)> CreateUserAsync(UserVM user)
        {
            var newUser = new User { UserName = user.FirstName + user.LastName, FirstName = user.FirstName, LastName = user.LastName, Email = user.Email, Gender = user.Gender, PhoneNumber = $"{user.CountryCode} {user.Phone}" };

            var result = await _userManager.CreateAsync(newUser, user.Password);

            return (result, newUser.Id);
        }

        public async Task<bool> AuthorizeAsync(string userId, string policyName)
        {
            var user = await _userManager.FindByIdAsync(userId);

            if (user == null)
            {
                return false;
            }

            var principal = await _userClaimsPrincipalFactory.CreateAsync(user);

            var result = await _authorizationService.AuthorizeAsync(principal, policyName);

            return result.Succeeded;
        }
    }
}

