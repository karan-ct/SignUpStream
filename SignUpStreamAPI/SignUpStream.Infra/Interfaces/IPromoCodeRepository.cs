using SignUpStream.Data.Entities;

namespace SignUpStream.Infra.Interfaces
{
    public interface IPromoCodeRepository
	{
        Task<PromoCode?> GetPromoCode(string code);
    }
}

