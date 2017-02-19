using System.Threading.Tasks;
using Microsoft.Bot.Connector;

namespace Teamdare.Bot.Communications.Channels
{
    public class MessagesChannel : Channel
    {
        public override async Task Handle(Activity activity)
        {
            var connector = GetConnector(activity);
            var reply = CreateReply(activity);

            reply.Text = activity.Text;
            await connector.Conversations.ReplyToActivityAsync(reply);
        }
    }
}