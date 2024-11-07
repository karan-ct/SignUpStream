using Microsoft.AspNetCore.Mvc;
using SignUpStream.Data.Entities;
using SignUpStream.Infra.Interfaces;

namespace SignUpStream.API.Controllers
{
    [Route("api/[controller]")]
    public class SubscriptionController : Controller
    {
        private readonly ISubscribeService _subscribeService;

        public SubscriptionController(ISubscribeService subscribeService)
        {
            _subscribeService = subscribeService;
        }

        [HttpGet("applyPromo/{promoCode}")]
        public async Task<PromoCode?> GetAppliedPromoCode(string promoCode)
        {
            return await _subscribeService.GetPromoCodeAsync(promoCode);
        }

        [HttpGet("getUpdatedAmount/{totalBranch}/{plan}/{promoCode}")]
        public async Task<object?> GetUpdatedAmmount(int totalBranch, int plan, string? promoCode)
        {
            return await _subscribeService.GetUpdatedAmmount(totalBranch, plan, promoCode);
        }

        [HttpGet("plans")]
        public async Task<List<PricePlan>> GetPricePlans()
        {
            return await _subscribeService.GetPricePlansAsync();
        }

    }
}

