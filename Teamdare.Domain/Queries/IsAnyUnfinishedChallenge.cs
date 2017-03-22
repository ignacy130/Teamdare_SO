using System;
using System.Linq;
using Teamdare.Core.Queries;
using Teamdare.Database.Entities;

namespace Teamdare.Domain.Queries
{
    public class HasAnyChallengeUnfinished : QueryData<bool>
    {
        public string UserId { get; set; }

        public HasAnyChallengeUnfinished(string userId)
        {
            UserId = userId;
        }
    }

    public class HasAnyChallengeUnfinishedQuery : QueryPerformer<HasAnyChallengeUnfinished>
    {
        public override HasAnyChallengeUnfinished Perform(HasAnyChallengeUnfinished query)
        {
            query.QueryResult = DbContext.Challenges.Any(
                c => c.Player.UserId == query.UserId && c.Status != ChallengeStatus.Completed);

            return query;
        }
    }
}