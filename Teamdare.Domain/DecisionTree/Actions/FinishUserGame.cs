using System.Collections.Generic;
using Microsoft.Bot.Connector;
using Teamdare.Domain.DecisionTree.Base;

namespace Teamdare.Domain.DecisionTree.Actions
{
    public class FinishUserGame : DecisionResult<Activity, IEnumerable<Activity>>
    {
        public override IEnumerable<Activity> Evaluate(Activity activity)
        {
            return new List<Activity> { activity.CreateReply("Congratulations! You have finished demo version!") };
        }
    }
}