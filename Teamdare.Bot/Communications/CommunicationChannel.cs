using System.Threading.Tasks;
using Microsoft.Bot.Connector;

namespace Teamdare.Bot.Communications
{
    public class CommunicationChannel
    {
        private readonly Responses _responses;
        private readonly CommunicationChannelMap _communicationChannelMap;

        public CommunicationChannel(Responses responses, CommunicationChannelMap communicationChannelMap)
        {
            _responses = responses;
            _communicationChannelMap = communicationChannelMap;
        }

        public async Task Handle(Activity activity)
        {
            var channel = this._communicationChannelMap.Find(activity.GetActivityType());
            await channel.Handle(activity);
        }
    }
}