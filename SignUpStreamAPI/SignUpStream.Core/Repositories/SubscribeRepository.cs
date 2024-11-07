using SignUpStream.Data.Context;
using SignUpStream.Data.Entities;
using SignUpStream.Infra.Interfaces;

namespace SignUpStream.Data.Repositories
{
    public class SubscribeRepository : ISubscribeRepository
    {
        private readonly SignUpStreamDBContext _appDbContext;

        public SubscribeRepository(SignUpStreamDBContext appDbContext)
		{
			_appDbContext = appDbContext;
		}

        public async Task<Subscription?> AddSubscriptionAsync(Subscription subscription)
        {
            try
            {
                var result = await _appDbContext.Subscription.AddAsync(subscription);
                await _appDbContext.SaveChangesAsync();
                return result.Entity;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}

