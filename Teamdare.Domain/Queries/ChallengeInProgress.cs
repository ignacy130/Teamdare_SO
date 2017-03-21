using System.Linq;
using Microsoft.EntityFrameworkCore;
using Teamdare.Core.Queries;
using Teamdare.Database.Entities;

namespace Teamdare.Domain.Queries
{
    public class ChallengeInProgress : QueryData<Challenge>
    {
        public ChallengeInProgress(string userId)
        {
            UserId = userId;
        }

        public string UserId { get; set; }
    }

    public class ChallengeInProgressQuery : QueryPerformer<ChallengeInProgress>
    {
        public override ChallengeInProgress Perform(ChallengeInProgress query)
        {
            query.QueryResult = DbContext.Challenges.Include(c => c.Adventure).SingleOrDefault(
                c => c.Player.UserId == query.UserId && c.Status == ChallengeStatus.InProgress);
            return query;
        }
    }
}