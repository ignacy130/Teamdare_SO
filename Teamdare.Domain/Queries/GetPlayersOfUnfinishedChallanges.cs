using System;
using System.Collections.Generic;
using System.Linq;
using Teamdare.Core.Queries;
using Teamdare.Database.Entities;

namespace Teamdare.Domain.Queries
{
    public class GetPlayersOfUnfinishedChallanges : QueryData<List<Player>>
    {
        public GetPlayersOfUnfinishedChallanges()
        {
        }
    }

    public class GetPlayersOfUnfinishedChallangesQuery : QueryPerformer<GetPlayersOfUnfinishedChallanges>
    {
        public override GetPlayersOfUnfinishedChallanges Perform(GetPlayersOfUnfinishedChallanges query)
        {
            var yesterday = DateTimeGetter.GetDateTime().AddDays(-1);

            query.QueryResult = DbContext.Challenges
                .Where(x => x.Status == ChallengeStatus.InProgress && yesterday <= x.StartDate)
                .Select(x => x.Player)
                .ToList();

            return query;
        }
    }
}