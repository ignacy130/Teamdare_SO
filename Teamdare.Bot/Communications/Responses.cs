﻿using System;
using System.Threading.Tasks;
using Microsoft.Bot.Connector;

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