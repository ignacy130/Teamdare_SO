using System.Threading.Tasks;
using Microsoft.Bot.Connector;
using Teamdare.Connector;
using Teamdare.Domain.DecisionTree;
using System.Linq;

namespace Teamdare.Bot.Communications.Channels
{
    public class MessagesChannel : IChannel
    {
        private readonly DecisionTreeHead _decisionTreeHead;
        private readonly BotConnector _botConnector;

        public MessagesChannel(DecisionTreeHead decisionTreeHead, BotConnector botConnector)
        {
            _decisionTreeHead = decisionTreeHead;
            _botConnector = botConnector;
        }

		public async Task Handle(Activity activity)
		{
			foreach (var response in _decisionTreeHead.Evaluate(activity))
			{
				await _botConnector.ReplyToActivityAsync(activity, response);
				var typing = activity.CreateReply();
				typing.Type = ActivityTypes.Typing;
				typing.Text = null;
				await _botConnector.ReplyToActivityAsync(activity, typing);
			}
		}
    }
}