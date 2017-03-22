using System.Threading.Tasks;
using Microsoft.Bot.Connector;
using Teamdare.Core;
using Teamdare.Domain.Commands;

namespace Teamdare.Bot.Communications.Channels
{
    public class ConversationUpdateChannel : IChannel
    {
        private readonly IAssistant _please;

        public ConversationUpdateChannel(IAssistant please)
        {
            _please = please;
        }

        public async Task Handle(Activity activity)
        {
            _please.Do(new UpdatePlayerServiceAndConversation(activity.From.Id, activity.ServiceUrl, activity.Conversation.Id));
            return;
        }
    }
}