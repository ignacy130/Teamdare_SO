using System;
using System.Collections.Generic;
using System.Linq;
using Teamdare.Core.Queries;
using Teamdare.Database.Entities;

namespace Teamdare.Domain.Queries
{
    public class GetUsersOfUnfinishedChallanges : QueryData<List<Player>>
    {
        public GetUsersOfUnfinishedChallanges()
        {
        }
    }

    public class GetUsersOfUnfinishedChallangesQuery : QueryPerformer<GetUsersOfUnfinishedChallanges>
    {
        public override GetUsersOfUnfinishedChallanges Perform(GetUsersOfUnfinishedChallanges query)
        {
            query.QueryResult = DbContext.Challenges
                .Where(x =>
                    x.Status == ChallengeStatus.InProgress &&
                    (DateTime.Now - x.StartDate) != null &&
                    (DateTime.Now - x.StartDate).GetValueOrDefault().Hours <= 24)
                .Select(x => x.Player)
                .ToList();

            return query;
        }
    }
}