using SignUpStream.Data.Entities;

namespace SignUpStream.Infra.Interfaces
{
    public interface ISubscribeRepository
    {
        Task<Subscription?> AddSubscriptionAsync(Subscription subscription);

    }
}

