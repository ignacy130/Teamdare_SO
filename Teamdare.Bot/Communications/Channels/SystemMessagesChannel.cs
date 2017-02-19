using System.Threading.Tasks;
using Microsoft.Bot.Connector;

namespace Teamdare.Bot.Communications.Channels
{
    public class SystemMessagesChannel : IChannel
    {
        public Task Handle(Activity activity)
        {
            //TODO: Handle system message
            return null;
        }
    }
}