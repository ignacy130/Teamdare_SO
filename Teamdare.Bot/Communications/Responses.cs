using System;
using System.Threading.Tasks;
using Microsoft.Bot.Connector;
using Teamdare.Connector;

namespace Teamdare.Bot.Communications
{
    public class Responses
    {
        private readonly BotConnector _botConnector;

        public Responses(BotConnector botConnector)
        {
            _botConnector = botConnector;
        }

        [Obsolete("Use BotConnector")]
        public ConnectorClient GetConnector(Activity activity)
        {
            return new ConnectorClient(new Uri(activity.ServiceUrl), new MicrosoftAppCredentials("a3ae5c94-83e6-4dc2-9c1b-3ba5408e6694", "uWsEjRcaqsJVVi2ObXGsefS"));
        }

        public async Task SendTypingIndicator(Activity activity)
        {
            var typing = activity.CreateReply();
            typing.Type = ActivityTypes.Typing;
            typing.Text = null;

            await _botConnector.ReplyToActivityAsync(activity, typing);
        }
    }
}