using System;
using Microsoft.AspNetCore.Identity;

namespace SignUpStream.Data.Entities
{
	public class User : IdentityUser
	{
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Gender { get; set; }

		public User()
		{
		}
	}
}

