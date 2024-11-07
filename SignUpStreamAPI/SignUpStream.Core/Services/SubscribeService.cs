using SignUpStream.Data.Entities;
using SignUpStream.Infra.Enums;
using SignUpStream.Infra.Interfaces;
using SignUpStream.Infra.Models;

namespace SignUpStream.Logic.Services
{
	public class SubscribeService : ISubscribeService
    {
        private readonly IPricePlanRepository _pricePlanRepository;
		private readonly IPromoCodeRepository _promoCodeRepository;
		private readonly ISubscribeRepository _subscribeRepository;

        public SubscribeService(
			IPricePlanRepository pricePlanRepository,
            IPromoCodeRepository promoCodeRepository,
            ISubscribeRepository subscribeRepository)
		{
			_pricePlanRepository = pricePlanRepository;
			_promoCodeRepository = promoCodeRepository;
			_subscribeRepository = subscribeRepository;
		}

		public async Task<List<PricePlan>> GetPricePlansAsync()
		{
			return await _pricePlanRepository.GetPricePlansAsync();
		}

        public async Task<PromoCode?> GetPromoCodeAsync(string code)
        {
            return await _promoCodeRepository.GetPromoCode(code);
        }

        public async Task<bool> CreateSubscriptionAsync(SubscriptionVM subscription)
		{
			Subscription newSubscription = new Subscription();
			newSubscription.UserId = subscription.UserId;
			newSubscription.PricePlanId = subscription.PricePlanId;
			newSubscription.PromoCodeId = subscription.PromoCodeId;
			newSubscription.TotalAmount = subscription.TotalAmount;
			newSubscription.TotalBranch = subscription.TotalBranch;
			newSubscription.PaymentSuccessful = true;
            var newSub = await _subscribeRepository.AddSubscriptionAsync(newSubscription);
			if (newSub != null) return true;
			else return false;
		}

		public async Task<object?> GetUpdatedAmmount(int totalBranch, int planId, string promoCode)
		{
			var planDetails = await _pricePlanRepository.GetPricePlanByIdAsync(planId);
			var promoCodeDetails = !string.IsNullOrEmpty(promoCode) ? await _promoCodeRepository.GetPromoCode(promoCode) : null;
			var totalBranchMonths = totalBranch * GetTotalMonths(planDetails.MembershipPlanType);
			var planFinalPrice = planDetails.Discount > 0 ? (planDetails.Price - (planDetails.Price * planDetails.Discount / 100)) : planDetails.Price;
			var totalAmount = (totalBranchMonths * planFinalPrice * totalBranch) - (promoCodeDetails != null ? promoCodeDetails.Discount : 0);
			var savedAmount = (totalBranchMonths * planDetails.Price * totalBranch) - totalAmount;
			return new { Total = totalAmount, saved = savedAmount };
        }

		private int GetTotalMonths(MembershipPlanTypes membershipPlanType)
		{
			switch (membershipPlanType)
			{
				case MembershipPlanTypes.Monthly:
					return 1;
                case MembershipPlanTypes.Annually:
                    return 12;
                default:
					return 0;
			}
		}

    }
}

