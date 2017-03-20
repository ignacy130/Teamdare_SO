using System;
using System.Linq;
using Teamdare.Core.Commands;
using Teamdare.Database.Entities;

namespace Teamdare.Domain.Commands
{
    public class GetOrCreatePlayer : CommandResult<Player>
    {
        public GetOrCreatePlayer(string username, string userId, string conversationId, string serviceUrl, Guid gameMasterId)
        {
            Username = username;
            UserId = userId;
            ConversationId = conversationId;
            ServiceUrl = serviceUrl;
            GameMasterId = gameMasterId;
            ServiceUrl = serviceUrl;
        }

        public string Username { get; set; }
        public string UserId { get; set; }
        public string ConversationId { get; set; }
        public string ServiceUrl { get; set; }
        public Guid GameMasterId { get; set; }
    }

    public class GetOrCreatePlayerCommand : CommandPerformer<GetOrCreatePlayer>
    {
        public override void Execute(GetOrCreatePlayer command)
        {
            var player = DbContext.Players.SingleOrDefault(p => p.UserId == command.UserId);
            if (player!=null)
            {
                if (string.IsNullOrEmpty(player.ServiceUrl) || string.IsNullOrEmpty(player.ConversationId)) {
                    player.ServiceUrl = command.ServiceUrl;
                    player.ConversationId = command.ConversationId;
                    DbContext.SaveChanges();
                }
            }


            if (player == null)
            {
                player = new Player()
                {
                    Nick = command.Username,
                    UserId = command.UserId,
                    GameMaster = DbContext.GameMasters.SingleOrDefault(gm => gm.Id == command.GameMasterId),
                    ServiceUrl = command.ServiceUrl,
                    ConversationId = command.ConversationId
                };

                DbContext.Players.Add(player);
                DbContext.SaveChanges();
            }

            command.Result = player;
        }
    }
}