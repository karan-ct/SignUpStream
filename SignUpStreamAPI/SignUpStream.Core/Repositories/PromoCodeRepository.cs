using Microsoft.EntityFrameworkCore;
using SignUpStream.Data.Context;
using SignUpStream.Data.Entities;
using SignUpStream.Infra.Interfaces;

namespace SignUpStream.Data.Repositories
{
    public class PromoCodeRepository : IPromoCodeRepository
    {
        private readonly SignUpStreamDBContext _appDbContext;

        public PromoCodeRepository(SignUpStreamDBContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<PromoCode?> GetPromoCode(string code)
        {
            var result = await _appDbContext.PromoCode.FirstOrDefaultAsync(k => k.Code == code);
            return result;
        }
    }
}

