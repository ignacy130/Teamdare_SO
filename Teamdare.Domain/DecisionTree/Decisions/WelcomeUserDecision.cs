using System.Collections.Generic;
using Microsoft.Bot.Connector;
using Teamdare.Domain.Commands;
using Teamdare.Domain.DecisionTree.Base;
using Teamdare.Resources;

namespace Teamdare.Domain.DecisionTree.Decisions
{
    public class WelcomeUserDecision : DecisionResult<Activity, IEnumerable<Activity>>
    {
        public override IEnumerable<Activity> Evaluate(Activity activity)
        {
            Please.Do(new InitializeGame(activity.From.Name, activity.From.Id, activity.Conversation.Id, activity.ServiceUrl));
            yield return activity.CreateReply(ResourcesStrings.WelcomeText);
        }
    }
}