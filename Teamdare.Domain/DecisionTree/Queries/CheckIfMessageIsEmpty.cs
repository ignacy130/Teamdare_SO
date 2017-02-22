using System.Collections.Generic;
using Microsoft.Bot.Connector;
using Teamdare.Domain.DecisionTree.Base;

namespace Teamdare.Domain.DecisionTree.Queries
{
    public class CheckIfMessageIsEmpty : DecisionQuery<Activity, IEnumerable<Activity>>
    {
        public CheckIfMessageIsEmpty()
        {
            Test = activity => string.IsNullOrWhiteSpace(activity.Text);
            Positive = new CheckIfMessageContainsAttachments();
            Negative = new CheckIfPlayerWantsToResetGame();
        }
    }
}