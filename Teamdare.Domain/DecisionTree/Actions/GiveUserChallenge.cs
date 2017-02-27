using System.Collections.Generic;
using Microsoft.Bot.Connector;
using Teamdare.Domain.Commands;
using Teamdare.Domain.DecisionTree.Base;
using Teamdare.Domain.Queries;
using Teamdare.Resources;

namespace Teamdare.Domain.DecisionTree.Actions
{
    public class GiveUserChallenge : DecisionResult<Activity, IEnumerable<Activity>>
    {
        public override IEnumerable<Activity> Evaluate(Activity activity)
        {
            var challenge = Please.Give(new NextUnfinishedChallenge(activity.From.Id)).QueryResult;
            if (challenge == null)
                yield break;

            Please.Do(new BeginChallange(challenge.Id));

            var content = ResourcesStrings.AdventureNewChallengeForYou + "\"" + challenge.Title + "\"!";

            yield return activity.CreateReply(content);
        }
    }
}