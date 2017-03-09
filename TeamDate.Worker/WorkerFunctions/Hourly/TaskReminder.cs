﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Bot.Connector;
using Teamdare.Core;
using Teamdare.Database.Entities;
using Teamdare.Worker.Interfaces;
using Teamdare.Domain.Queries;

namespace Teamdare.Worker.WorkerFunctions.Hourly
{
    public class TaskReminder : IWorkerExecution
    {
        private IAssistant assistant;

        public TaskReminder(IAssistant assistant)
        {
            this.assistant = assistant;
        }


        public void Execute()
        {
            var usersToRemind = assistant.Give(new GetUsersOfUnfinishedChallanges()).QueryResult;

            foreach (var user in usersToRemind)
            {
                SendReminder(user);
            }
        }

        private async void SendReminder(Player user)
        {
            var connector = new ConnectorClient(new Uri(user.ServiceUrl));
            IMessageActivity newMessage = Activity.CreateMessageActivity();
            newMessage.Type = ActivityTypes.Message;
            newMessage.From = new ChannelAccount("");
            newMessage.Conversation = new ConversationAccount(false, user.ConversationId, null);
            newMessage.Recipient = new ChannelAccount(user.UserId, user.Nick);
            newMessage.Text = "How is your challenge going?";
            await connector.Conversations.SendToConversationAsync((Activity)newMessage);
        }
    }
}
