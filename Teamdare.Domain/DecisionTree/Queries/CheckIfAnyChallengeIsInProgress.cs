using System.Collections.Generic;
using Microsoft.Bot.Connector;
using Teamdare.Domain.DecisionTree.Base;
using Teamdare.Domain.Queries;

namespace Teamdare.Domain.DecisionTree.Queries
{
    public class CheckIfAnyChallengeIsInProgress : DecisionQuery<Activity, IEnumerable<Activity>>
    {
        public CheckIfAnyChallengeIsInProgress()
        {
            Test = activity => Please.Check(new IsAnyChallengeInProgress(activity.From.Id));
            Positive = new CheckIfChallengeShouldBeFinished();
            Negative = new CheckIfAnyChallangeIsUnfinished();
        }
    }
}