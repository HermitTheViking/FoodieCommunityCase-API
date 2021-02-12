using System.Threading.Tasks;

namespace FoodieCommunityCase.Domain.Messaging
{
    public interface IMessageBus
    {
        void Send<T>(T command);
        Task SendAsync<T>(T command);
    }
}
