using System.Linq;
using System.Threading.Tasks;
using Microsoft.Bot.Connector;

namespace Teamdare.Bot.Communications.Channels
{
    public class ConversationUpdatesChannel : IChannel
    {
        private readonly Responses _responses;

        public ConversationUpdatesChannel(Responses responses)
        {
            _responses = responses;
        }

        public async Task Handle(Activity activity)
        {
            var connector = this._responses.GetConnector(activity);
            var reply = this._responses.CreateReply(activity);

            if (activity.MembersAdded.Any())
            {
                reply.Text = "Welcome! ;-)";
                await connector.Conversations.ReplyToActivityAsync(reply);
            }
        }
    }
}