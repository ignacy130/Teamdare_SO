using System.Linq;
using System.Threading.Tasks;
using Microsoft.Bot.Connector;
using Teamdare.Database;

namespace Teamdare.Bot.Communications.Channels
{
    public class MessagesChannel : IChannel
    {
        private readonly Responses _responses;
        private readonly TeamdareContext _dbContext;

        public MessagesChannel(Responses responses, TeamdareContext dbContext)
        {
            _responses = responses;
            _dbContext = dbContext;
        }

        public async Task Handle(Activity activity)
        {
            var gameMasters = _dbContext.GameMasters.ToList();
            await _responses.SendTypingIndicator(activity);

            var connector = this._responses.GetConnector(activity);
            var reply = this._responses.CreateReply(activity);

            reply.Text = activity.Text;
            await connector.Conversations.ReplyToActivityAsync(reply);
        }
    }
}