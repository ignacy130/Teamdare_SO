using System.Threading.Tasks;
using Microsoft.Bot.Connector;
using Teamdare.Connector;
using Teamdare.Domain.DecisionTree;

namespace Teamdare.Bot.Communications.Channels
{
    public class MessagesChannel : IChannel
    {
        private readonly DecisionTreeHead _decisionTreeHead;
        private readonly BotConnector _botConnector;
        private readonly Responses _responses;

        public MessagesChannel(DecisionTreeHead decisionTreeHead, BotConnector botConnector, Responses responses)
        {
            _decisionTreeHead = decisionTreeHead;
            _botConnector = botConnector;
            _responses = responses;
        }

		public async Task Handle(Activity activity)
		{
		    await _responses.SendTypingIndicator(activity);
			foreach (var response in _decisionTreeHead.Evaluate(activity))
			{
			    await _responses.SendTypingIndicator(activity);
				await _botConnector.ReplyToActivityAsync(activity, response);
			}
		}
    }
}