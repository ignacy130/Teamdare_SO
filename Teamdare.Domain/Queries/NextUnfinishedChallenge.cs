using System.Linq;
using Teamdare.Core.Queries;
using Teamdare.Database.Entities;

namespace Teamdare.Domain.Queries
{
    public class NextUnfinishedChallenge : QueryData<Challenge>
    {
        public NextUnfinishedChallenge(string userId)
        {
            UserId = userId;
        }

        public string UserId { get; set; }
    }

    public class NextUnfinishedChallengeQuery : QueryPerformer<NextUnfinishedChallenge>
    {
        public override NextUnfinishedChallenge Perform(NextUnfinishedChallenge query)
        {
            query.QueryResult = DbContext.Challenges
                .Where(c => c.Player.UserId == query.UserId && c.Status != ChallengeStatus.Completed)
                .OrderBy(c => c.Adventure.Order)
                .ThenBy(c => c.Order)
                .FirstOrDefault();

            return query;
        }
    }
}