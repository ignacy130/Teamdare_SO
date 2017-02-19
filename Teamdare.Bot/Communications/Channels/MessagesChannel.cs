using System.Threading.Tasks;
using Microsoft.Bot.Connector;

namespace Teamdare.Bot.Communications.Channels
{
    public class MessagesChannel : IChannel
    {
        private readonly Responses _responses;

        public MessagesChannel(Responses responses)
        {
            _responses = responses;
        }

        public async Task Handle(Activity activity)
        {
            await _responses.SendTypingIndicator(activity);

            var connector = this._responses.GetConnector(activity);
            var reply = this._responses.CreateReply(activity);

            reply.Text = activity.Text;
            await connector.Conversations.ReplyToActivityAsync(reply);
        }
    }
}