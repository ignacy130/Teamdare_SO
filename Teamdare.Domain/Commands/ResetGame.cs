using System.Linq;
using Teamdare.Core.Commands;

namespace Teamdare.Domain.Commands
{
    public class ResetGame
    {
        public ResetGame(string userId)
        {
            UserId = userId;
        }

        public string UserId { get; set; }
    }

    public class ResetGameCommand : CommandPerformer<ResetGame>
    {
        public override void Execute(ResetGame command)
        {
            var player = DbContext.Players.SingleOrDefault(p => p.UserId == command.UserId);

            if (player == null)
                return;

            DbContext.Players.Remove(player);
            DbContext.SaveChanges();
        }
    }
}