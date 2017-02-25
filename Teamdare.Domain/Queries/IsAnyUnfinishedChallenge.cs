using System.Linq;
using Teamdare.Core.Queries;
using Teamdare.Database.Entities;

namespace Teamdare.Domain.Queries
{
    public class IsAnyUnfinishedChallenge : QueryData<bool>
    {
        public string UserId { get; set; }

        public IsAnyUnfinishedChallenge(string userId)
        {
            UserId = userId;
        }
    }

    public class IsAnyUnfinishedChallengeQuery : QueryPerformer<IsAnyUnfinishedChallenge>
    {
        public override IsAnyUnfinishedChallenge Perform(IsAnyUnfinishedChallenge query)
        {
            query.QueryResult = DbContext.Challenges.Any(
                c => c.Player.UserId == query.UserId && c.Status != ChallengeStatus.Completed);

            return query;
        }
    }
}