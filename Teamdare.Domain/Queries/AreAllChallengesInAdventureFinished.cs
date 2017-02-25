using System;
using System.Linq;
using Teamdare.Core.Queries;
using Teamdare.Database.Entities;

namespace Teamdare.Domain.Queries
{
    public class AreAllChallengesInAdventureFinished : QueryData<bool>
    {
        public AreAllChallengesInAdventureFinished(Guid adventureId)
        {
            AdventureId = adventureId;
        }

        public Guid AdventureId { get; set; }
    }

    public class AreAllChallengesInAdventureFinishedQuery : QueryPerformer<AreAllChallengesInAdventureFinished>
    {
        public override AreAllChallengesInAdventureFinished Perform(AreAllChallengesInAdventureFinished query)
        {
            query.QueryResult = DbContext.Challenges.Where(c => c.Adventure.Id == query.AdventureId)
                .All(c => c.Status == ChallengeStatus.Completed);
            return query;
        }
    }
}