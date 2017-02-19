using System.Threading.Tasks;
using Microsoft.Bot.Connector;

namespace Teamdare.Bot.Communications.Channels
{
    public interface IChannel
    {
        Task Handle(Activity activity);
    }
}