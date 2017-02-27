using Microsoft.Bot.Connector;
using Teamdare.Bot.Communications.Channels;

namespace Teamdare.Bot.Communications
{
    public class CommunicationChannelMap
    {
        private readonly MessagesChannel _messagesChannel;

        public CommunicationChannelMap(MessagesChannel messagesChannel)
        {
            _messagesChannel = messagesChannel;
        }

        public IChannel Find(string activityType)
        {
            switch (activityType)
            {
                case ActivityTypes.Message:
                    return this._messagesChannel;
                default:
                    return null;
            }
        }
    }
}