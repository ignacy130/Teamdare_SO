using System.Threading.Tasks;
using Microsoft.Bot.Connector;

namespace Teamdare.Bot.Communications
{
    public class CommunicationChannel
    {
        private readonly CommunicationChannelMap _communicationChannelMap;

        public CommunicationChannel(CommunicationChannelMap communicationChannelMap)
        {
            _communicationChannelMap = communicationChannelMap;
        }

        public async Task Handle(Activity activity)
        {
            var channel = this._communicationChannelMap.Find(activity.GetActivityType());

            if (channel != null)
                await channel.Handle(activity);
        }
    }
}