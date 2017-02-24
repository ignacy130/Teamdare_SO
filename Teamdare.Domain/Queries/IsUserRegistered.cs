using System.Linq;
using Teamdare.Core.Queries;

namespace Teamdare.Domain.Queries
{
    public class IsUserRegistered : QueryData<bool>
    {
        public string UserId { get; set; }
        public string ConversationId { get; set; }
        public string ServiceUrl { get; set; }

        public IsUserRegistered(string userId, string conversationId, string serviceUrl)
        {
            UserId = userId;
            ConversationId = conversationId;
            ServiceUrl = serviceUrl;
        }
    }

    public class IsUserRegisteredQuery: QueryPerformer<IsUserRegistered>
    {
        public override IsUserRegistered Perform(IsUserRegistered query)
        {
            var player = DbContext.Players.Single(x => x.UserId == query.UserId);

            if (player == null)
                return query;

            player.ConversationId = query.ConversationId;
            player.ServiceUrl = query.ServiceUrl;

            return query;
        }
    }
}