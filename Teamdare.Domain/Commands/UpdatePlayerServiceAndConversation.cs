using System.Linq;
using Teamdare.Core.Commands;

namespace Teamdare.Domain.Commands
{
    public class UpdatePlayerServiceAndConversation
    {
        public UpdatePlayerServiceAndConversation(string userId, string serviceUrl, string conversationId)
        {
            UserId = userId;
            ServiceUrl = serviceUrl;
            ConversationId = conversationId;
        }

        public string UserId { get; set; }
        public string ServiceUrl { get; set; }
        public string ConversationId { get; set; }
    }

    public class UpdatePlayerServiceAndConversationCommand : CommandPerformer<UpdatePlayerServiceAndConversation>
    {
        public override void Execute(UpdatePlayerServiceAndConversation command)
        {
            var player = DbContext.Players.SingleOrDefault(p => p.UserId == command.UserId);

            if (string.IsNullOrWhiteSpace(player?.ServiceUrl) || string.IsNullOrWhiteSpace(player?.ConversationId))
                return;

            player.ServiceUrl = command.ServiceUrl;
            player.ConversationId = command.ConversationId;
            DbContext.SaveChanges();
        }
    }
}