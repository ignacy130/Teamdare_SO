using System;
using Microsoft.Bot.Connector;
using Teamdare.Connector;
using Teamdare.Core;
using Teamdare.Database.Entities;
using Teamdare.Worker.Interfaces;
using Teamdare.Domain.Queries;

namespace Teamdare.Worker.WorkerFunctions.Hourly
{
    public class TaskReminder : IWorkerExecution
    {
        private readonly IAssistant Please;
        private readonly BotConnector _botConnector;

        public TaskReminder(BotConnector botConnector, IAssistant please)
        {
            _botConnector = botConnector;
            Please = please;
        }


        public void Execute()
        {
            var usersToRemind = Please.Give(new GetUsersOfUnfinishedChallanges()).QueryResult;

            foreach (var user in usersToRemind)
            {
                if (!ShouldSendReminder(user))
                    continue;

                SendReminder(user);
            }
        }

        private bool ShouldSendReminder(Player user)
        {
            if (string.IsNullOrEmpty(user.ServiceUrl) || string.IsNullOrEmpty(user.ConversationId))
                return false;

            return true;
        }

        private async void SendReminder(Player user)
        {
            var newMessage = Activity.CreateMessageActivity();
            newMessage.Type = ActivityTypes.Message;
            newMessage.From = new ChannelAccount("");
            newMessage.Conversation = new ConversationAccount(false, user.ConversationId, null);
            newMessage.Recipient = new ChannelAccount(user.UserId, user.Nick);
            newMessage.Text = "How is your challenge going?";

            await _botConnector.SendToConversationAsync(user.ServiceUrl, (Activity)newMessage);
        }
    }
}
