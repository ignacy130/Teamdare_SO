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

        public MessagesChannel(DecisionTreeHead decisionTreeHead, BotConnector botConnector)
        {
            _decisionTreeHead = decisionTreeHead;
            _botConnector = botConnector;
        }

        public async Task Handle(Activity activity)
        {
            //var connector = this._responses.GetConnector(activity);

            foreach (var response in _decisionTreeHead.Evaluate(activity))
            {
                await _botConnector.ReplyToActivityAsync(activity, response);
                //await connector.Conversations.ReplyToActivityAsync(response);
            }
        }


    }
}