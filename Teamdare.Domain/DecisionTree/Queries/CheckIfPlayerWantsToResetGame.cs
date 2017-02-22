using System.Collections.Generic;
using Microsoft.Bot.Connector;
using Teamdare.Domain.DecisionTree.Base;

namespace Teamdare.Domain.DecisionTree.Queries
{
    public class CheckIfPlayerWantsToResetGame : DecisionQuery<Activity, IEnumerable<Activity>>
    {
        public CheckIfPlayerWantsToResetGame()
        {
            Test = activity => activity.Text.Contains("reset");
            Positive = new ResetGameDecision();
            Negative = new CheckIfPlayerIsAlreadyRegistered();
        }
    }
}