using System.Collections.Generic;
using Microsoft.Bot.Connector;
using Teamdare.Domain.Commands;
using Teamdare.Domain.DecisionTree.Base;

namespace Teamdare.Domain.DecisionTree.Decisions
{
    public class ResetGameDecision : DecisionResult<Activity, IEnumerable<Activity>>
    {
        public override IEnumerable<Activity> Evaluate(Activity activity)
        {
            Please.Do(new ResetGame(activity.From.Id));
            yield return activity.CreateReply("Game has been resetted");
        }
    }
}