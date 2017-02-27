using System.Collections.Generic;
using Microsoft.Bot.Connector;
using Teamdare.Core.Extensions;
using Teamdare.Domain.DecisionTree.Actions;
using Teamdare.Domain.DecisionTree.Base;

namespace Teamdare.Domain.DecisionTree.Queries
{
    public class CheckIfPlayerWantsToResetGame : DecisionQuery<Activity, IEnumerable<Activity>>
    {
        public  CheckIfPlayerWantsToResetGame()
        {
            Test = activity => activity.Text.ContainsAny("reset");
            Positive = new ResetUserGame();
            Negative = new CheckIfPlayerIsAlreadyRegistered();
        }
    }
}