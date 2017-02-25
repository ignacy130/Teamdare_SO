using System.Collections.Generic;
using System.Linq;
using Microsoft.Bot.Connector;
using Teamdare.Domain.DecisionTree.Base;

namespace Teamdare.Domain.DecisionTree.Queries
{
    public class CheckIfMessageContainsAttachments : DecisionQuery<Activity, IEnumerable<Activity>>
    {
        public CheckIfMessageContainsAttachments()
        {
            Test = activity => activity.Attachments.Any();
            Positive = new DecisionResult<Activity, IEnumerable<Activity>>()
            {
                Perform = activity => new[]
                {
                    activity.CreateReply("Sorry, I can't understand such files yet :/")
                }
            };
            Negative = new DecisionResult<Activity, IEnumerable<Activity>>()
            {
                Perform = activity => new[]
                {
                    activity.CreateReply("Sorry, I'm not with you. Could you rephrase your message, please? :)")
                }
            };
        }
    }
}