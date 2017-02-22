using System.Threading.Tasks;
using Microsoft.Bot.Connector;
using Teamdare.Domain.DecisionTree;

namespace Teamdare.Bot.Communications.Channels
{
    public class MessagesChannel : IChannel
    {
        private readonly Responses _responses;
        private readonly DecisionTreeHead _decisionTreeHead;

        public MessagesChannel(Responses responses, DecisionTreeHead decisionTreeHead)
        {
            _responses = responses;
            _decisionTreeHead = decisionTreeHead;
        }

        public async Task Handle(Activity activity)
        {
            var connector = this._responses.GetConnector(activity);
            foreach (var response in _decisionTreeHead.Evaluate(activity))
            {
                await connector.Conversations.ReplyToActivityAsync(response);
            }
        }
    }
}