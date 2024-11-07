using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SignUpStream.Data.Entities;
using SignUpStream.Infra.Enums;

namespace SignUpStream.Data.Context
{
    public class SignUpStreamDBContext : IdentityDbContext<User>
    {
		public SignUpStreamDBContext(DbContextOptions options) : base(options)
		{
		}
        public SignUpStreamDBContext()
        {
        }
        public DbSet<Subscription> Subscription { get; set; }
        public DbSet<PricePlan> PricePlan { get; set; }
        public DbSet<PromoCode> PromoCode { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            base.OnModelCreating(builder);
            SeedCoupons(builder);
            SeedMembershipPlans(builder);
        }

        #region Private seeder methods

        /// <summary>
        /// Seeds the coupons.
        /// </summary>
        /// <param name="builder">The builder.</param>
        private void SeedCoupons(ModelBuilder builder)
        {
            var coupons = new List<PromoCode>
            {
                new PromoCode { Id = 1, Code = "BRANCH-10", Discount = 10 },
                new PromoCode { Id = 1, Code = "BRANCH-15", Discount = 15 },
                new PromoCode { Id = 1, Code = "BRANCH-20", Discount = 20 }
            };

            builder.Entity<PromoCode>().HasData(coupons);
        }

        /// <summary>
        /// Seeds the Mmebership plans.
        /// </summary>
        /// <param name="builder">The builder.</param>
        private void SeedMembershipPlans(ModelBuilder builder)
        {
            var coupons = new[]
            {
                new PricePlan { Id = 1, Price = 200, Discount = 0, MembershipPlanType = MembershipPlanTypes.Monthly },
                new PricePlan { Id = 2, Price = 200, Discount = 10, MembershipPlanType = MembershipPlanTypes.Annually }
            };

            builder.Entity<PricePlan>().HasData(coupons);
        }
        #endregion
    }
}

