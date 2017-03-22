using System.Collections.Generic;
using Microsoft.Bot.Connector;
using Teamdare.Domain.DecisionTree.Actions;
using Teamdare.Domain.DecisionTree.Base;
using Teamdare.Domain.Queries;

namespace Teamdare.Domain.DecisionTree.Queries
{
    public class CheckIfAnyChallangeIsUnfinished :  DecisionQuery<Activity, IEnumerable<Activity>>
    {
        public CheckIfAnyChallangeIsUnfinished()
        {
            Test = activity => Please.Check(new HasAnyChallengeUnfinished(activity.From.Id));
            Positive = new GiveUserChallenge();
            Negative = new FinishUserGame();
        }
    }

}