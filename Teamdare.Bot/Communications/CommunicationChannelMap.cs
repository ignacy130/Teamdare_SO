using Microsoft.Bot.Connector;
using Teamdare.Bot.Communications.Channels;

namespace Teamdare.Bot.Communications
{
    public class CommunicationChannelMap
    {
        private readonly MessagesChannel _messagesChannel;
        private readonly ConversationUpdateChannel _conversationUpdateChannel;

        public CommunicationChannelMap(MessagesChannel messagesChannel, ConversationUpdateChannel conversationUpdateChannel)
        {
            _messagesChannel = messagesChannel;
            _conversationUpdateChannel = conversationUpdateChannel;
        }

        public IChannel Find(string activityType)
        {
            switch (activityType)
            {
                case ActivityTypes.Message:
                    return this._messagesChannel;
                case ActivityTypes.ConversationUpdate:
                    return this._conversationUpdateChannel;
                default:
                    return null;
            }
        }
    }
}