using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.Bot.Connector;
using Microsoft.Rest;

namespace Teamdare.Bot.Communications
{
    public class Responses
    {
        public Activity CreateReply(Activity activity)
        {
            return activity.CreateReply();
        }

        public ConnectorClient GetConnector(Activity activity)
        {
            return new ConnectorClient(new Uri(activity.ServiceUrl), new MicrosoftAppCredentials("a3ae5c94-83e6-4dc2-9c1b-3ba5408e6694", "uWsEjRcaqsJVVi2ObXGsefS"));
        }

        public string GetReplyUrl(Activity activity)
        {
            var url = new Uri(new Uri(activity.ServiceUrl + (activity.ServiceUrl.EndsWith("/") ? "" : "/")), "v3/conversations/{conversationId}/activities/{activityId}").ToString();
            url = url.Replace("{conversationId}", Uri.EscapeDataString(activity.Conversation.Id));
            url = url.Replace("{activityId}", Uri.EscapeDataString(activity.Id));
            return url;
        }

        public async Task SendTypingIndicator(Activity activity)
        {
            var connector = this.GetConnector(activity);
            var typing = this.CreateReply(activity);

            typing.Type = ActivityTypes.Typing;
            typing.Text = null;

            await connector.Conversations.ReplyToActivityAsync(typing);
        }
    }
}