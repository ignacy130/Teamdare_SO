using System.Linq;
using Teamdare.Core.Commands;
using Teamdare.Database.Entities;

namespace Teamdare.Domain.Commands
{
    public class GetOrCreateGameMaster : CommandResult<GameMaster>
    {

    }

    public class GetOrCreateGameMasterCommand : CommandPerformer<GetOrCreateGameMaster>
    {
        public override void Execute(GetOrCreateGameMaster command)
        {
            var gameMaster = DbContext.GameMasters.SingleOrDefault();

            if (gameMaster == null)
            {
                gameMaster = new GameMaster();
                DbContext.GameMasters.Add(gameMaster);
                DbContext.SaveChanges();
            }

            command.Result = gameMaster;
        }
    }
}