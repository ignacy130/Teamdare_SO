using System.Collections.Generic;
using Microsoft.Bot.Connector;
using Teamdare.Domain.DecisionTree.Actions;
using Teamdare.Domain.DecisionTree.Base;
using Teamdare.Domain.Queries;

namespace Teamdare.Domain.DecisionTree.Queries
{
    public class CheckIfGameShouldBeFinished : DecisionQuery<Activity, IEnumerable<Activity>>
    {
        public CheckIfGameShouldBeFinished()
        {
            Test = activity => Please.Check(new IsAnyUnfinishedChallenge(activity.From.Id));
            Positive = new CompleteUserChallenge();
            Negative = new FinishUserGame();
        }
    }
}