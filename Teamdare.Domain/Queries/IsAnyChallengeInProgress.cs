using System.Linq;
using Teamdare.Core.Queries;
using Teamdare.Database.Entities;

namespace Teamdare.Domain.Queries
{
    public class IsAnyChallengeInProgress : QueryData<bool>
    {
        public string UserId { get; set; }

        public IsAnyChallengeInProgress(string userId)
        {
            UserId = userId;
        }
    }

    public class IsAnyChallengeInProgressQuery : QueryPerformer<IsAnyChallengeInProgress>
    {
        public override IsAnyChallengeInProgress Perform(IsAnyChallengeInProgress query)
        {
            query.QueryResult = Please.Give(new ChallengeInProgress(query.UserId)).QueryResult != null;

            return query;
        }
    }
}