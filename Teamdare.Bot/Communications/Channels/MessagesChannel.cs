using System.Threading.Tasks;
using Microsoft.Bot.Connector;
using Teamdare.Core;
using Teamdare.Database;

namespace Teamdare.Bot.Communications.Channels
{
    public class MessagesChannel : IChannel
    {
        private readonly Responses _responses;
        private readonly TeamdareContext _dbContext;
        private readonly IAssistant _assistant;

        public MessagesChannel(Responses responses, TeamdareContext dbContext, IAssistant assistant)
        {
            _responses = responses;
            _dbContext = dbContext;
            _assistant = assistant;
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