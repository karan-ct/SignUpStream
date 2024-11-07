using Microsoft.EntityFrameworkCore;
using SignUpStream.Data.Context;
using SignUpStream.Data.Entities;
using SignUpStream.Infra.Interfaces;

namespace SignUpStream.Data.Repositories
{
    public class PricePlanRepository : IPricePlanRepository
    {
        private readonly SignUpStreamDBContext _appDbContext;

        public PricePlanRepository(SignUpStreamDBContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<List<PricePlan>> GetPricePlansAsync()
        {
            return await _appDbContext.PricePlan.ToListAsync();
        }

        public async Task<PricePlan?> GetPricePlanByIdAsync(int id)
        {
            return await _appDbContext.PricePlan.FirstOrDefaultAsync(k => k.Id == id);
        }
    }
}

