using System;
using System.Net.Http;
using System.Runtime.ExceptionServices;
using System.Threading.Tasks;
using Microsoft.Bot.Connector;
using Teamdare.Connector;
using Teamdare.Core;
using Teamdare.Database.Entities;
using Teamdare.Domain.Commands;
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
            var playersToRemind = Please.Give(new GetPlayersOfUnfinishedChallanges()).QueryResult;

            foreach (var player in playersToRemind)
            {
                if (!ShouldSendReminder(player))
                    continue;

                SendReminder(player);
            }
        }

        private bool ShouldSendReminder(Player user)
        {
            if (string.IsNullOrEmpty(user.ServiceUrl) || string.IsNullOrEmpty(user.ConversationId))
                return false;

            return true;
        }

        private void SendReminder(Player player)
        {
            var newMessage = Activity.CreateMessageActivity();
            newMessage.Type = ActivityTypes.Message;
            newMessage.From = new ChannelAccount("");
            newMessage.Conversation = new ConversationAccount(false, player.ConversationId, null);
            newMessage.Recipient = new ChannelAccount(player.UserId, player.Nick);
            newMessage.Text = "How is your challenge going?";

            try
            {
                var response = _botConnector.SendToConversationAsync(player.ServiceUrl, (Activity) newMessage).Result;
                response.EnsureSuccessStatusCode();
            }
            catch (Exception ex)
            {
                Please.Do(new ClearPlayerServiceAndConversation(player.UserId));
            }
        }
    }
}