using System;
using System.Linq;
using Microsoft.Extensions.Logging;
using NuGet.Protocol.Core.v3;
using Teamdare.Core.Commands;

namespace Teamdare.Domain.Commands
{
    public class ClearPlayerServiceAndConversation
    {
        public ClearPlayerServiceAndConversation(string userId)
        {
            UserId = userId;
        }

        public string UserId { get; set; }
    }

    public class ClearPlayerServiceAndConversationCommand : CommandPerformer<ClearPlayerServiceAndConversation>
    {
        private readonly ILogger<ClearPlayerServiceAndConversation> _logger;

        public ClearPlayerServiceAndConversationCommand(ILogger<ClearPlayerServiceAndConversation> logger)
        {
            _logger = logger;
        }

        public override void Execute(ClearPlayerServiceAndConversation command)
        {
            var player = DbContext.Players.SingleOrDefault(p => p.UserId == command.UserId);

            _logger.LogDebug(player.ToJson());

            if (player == null)
                return;

            player.ServiceUrl = null;
            player.ConversationId = null;
            DbContext.SaveChanges();
        }
    }
}