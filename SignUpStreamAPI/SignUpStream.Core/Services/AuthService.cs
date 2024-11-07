using Microsoft.AspNetCore.Identity;
using SignUpStream.Infra.Interfaces;
using SignUpStream.Infra.Models;

namespace SignUpStream.Logic.Services
{
    public class AuthService : IAuthService
    {
        private readonly IIdentityService _identityService;
        private readonly ISubscribeService _subscribeService;

        public AuthService(IIdentityService identityService,
            ISubscribeService subscribeService)
		{
            _identityService = identityService;
            _subscribeService = subscribeService;
		}

		public async Task<IdentityResult> SignUp(UserVM user)
		{
            //Create User
            var result = await _identityService.CreateUserAsync(user);

            //Create Subscription
            if(result.Result.Succeeded)
            {
                user.Subscription.UserId = result.UserId;
                await _subscribeService.CreateSubscriptionAsync(user.Subscription);
            }
            return result.Result;
        }
	}
}

