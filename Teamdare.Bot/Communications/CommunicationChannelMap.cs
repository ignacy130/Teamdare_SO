using Microsoft.Bot.Connector;
using Teamdare.Bot.Communications.Channels;

namespace Teamdare.Bot.Communications
{
    public class CommunicationChannelMap
    {
        private readonly MessagesChannel _messagesChannel;
        private readonly SystemMessagesChannel _systemMessagesChannel;
        private readonly ConversationUpdatesChannel _conversationUpdatesChannel;

        public CommunicationChannelMap(MessagesChannel messagesChannel, SystemMessagesChannel systemMessagesChannel,
            ConversationUpdatesChannel conversationUpdatesChannel)
        {
            _messagesChannel = messagesChannel;
            _systemMessagesChannel = systemMessagesChannel;
            _conversationUpdatesChannel = conversationUpdatesChannel;
        }

        public Channel Find(string activityType)
        {
            switch (activityType)
            {
                case ActivityTypes.Message:
                    return this._messagesChannel;
                case ActivityTypes.ConversationUpdate:
                    return this._conversationUpdatesChannel;
                default:
                    return this._systemMessagesChannel;
            }
        }
    }
}