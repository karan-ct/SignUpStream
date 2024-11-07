using System;
using Microsoft.AspNetCore.Identity;
using SignUpStream.Infra.Models;

namespace SignUpStream.Infra.Interfaces
{
	public interface IAuthService
	{
		Task<IdentityResult> SignUp(UserVM user);
	}
}

