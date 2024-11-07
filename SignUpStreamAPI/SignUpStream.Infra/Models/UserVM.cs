namespace SignUpStream.Infra.Models
{
    public class UserVM
	{
		public Guid Id { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Password { get; set; }
		public string Email { get; set; }
		public string CountryCode { get; set; }
		public string Phone { get; set; }
        public string Gender { get; set; }
        public SubscriptionVM Subscription { get; set; }

        public UserVM() { }

	}
	
}

