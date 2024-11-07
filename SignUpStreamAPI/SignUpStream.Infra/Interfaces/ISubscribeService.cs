using SignUpStream.Data.Entities;
using SignUpStream.Infra.Models;

namespace SignUpStream.Infra.Interfaces
{
    public interface ISubscribeService
	{
		Task<bool> CreateSubscriptionAsync(SubscriptionVM subscription);
		Task<List<PricePlan>> GetPricePlansAsync();
		Task<PromoCode?> GetPromoCodeAsync(string code);
        Task<object?> GetUpdatedAmmount(int totalBranch, int planId, string? promoCode);

    }
}

