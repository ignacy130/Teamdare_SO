using System;
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
            var player = DbContext.Players.SingleOrDefault(x => x.UserId == query.UserId);

            query.QueryResult = player != null;

            return query;
        }
    }
}