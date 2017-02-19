using System.Linq;
using System.Threading.Tasks;
using Microsoft.Bot.Connector;

namespace Teamdare.Bot.Communications.Channels
{
    public class ConversationUpdatesChannel : Channel
    {
        public override async Task Handle(Activity activity)
        {
            var connector = GetConnector(activity);
            var reply = CreateReply(activity);

            if (activity.MembersAdded.Any())
            {
                reply.Text = "Welcome! ;-)";
                await connector.Conversations.ReplyToActivityAsync(reply);
            }
        }
    }
}