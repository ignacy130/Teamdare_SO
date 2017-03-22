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
            //var connector = this._responses.GetConnector(activity);

            foreach (var response in _decisionTreeHead.Evaluate(activity))
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

				var results = _decisionTreeHead.Evaluate(activity).ToList();

				foreach (var response in results)
                {
                    var typing = activity.CreateReply();
                    typing.Type = ActivityTypes.Typing;
                    typing.Text = null;
                    await client.PostAsJsonAsync<Activity>(url, typing);
                    await client.PostAsJsonAsync<Activity>(url, response);
                }
            }
        }


    }
}