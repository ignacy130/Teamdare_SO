using System.Threading.Tasks;
using Microsoft.Bot.Connector;

namespace Teamdare.Bot.Communications
{
    public class Responses
    {
        private async Task SendTypingIndicator(Activity activity, ConnectorClient connector)
        {
            var typing = activity.CreateReply();
            typing.Type = ActivityTypes.Typing;
            typing.Text = null;
            await connector.Conversations.ReplyToActivityAsync(typing);
        }
    }
}