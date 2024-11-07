using SignUpStream.Data.Entities;

namespace SignUpStream.Infra.Interfaces
{
    public interface IPricePlanRepository
	{
        Task<List<PricePlan>> GetPricePlansAsync();
        Task<PricePlan?> GetPricePlanByIdAsync(int id);
    }
}

