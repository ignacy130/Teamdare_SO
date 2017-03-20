using System;
using System.Collections.Generic;
using Microsoft.Bot.Connector;
using Teamdare.Domain.Commands;
using Teamdare.Domain.DecisionTree.Base;
using Teamdare.Domain.Queries;

namespace Teamdare.Domain.DecisionTree.Actions
{
    public class CompleteUserChallenge : DecisionResult<Activity, IEnumerable<Activity>>
    {
        public override IEnumerable<Activity> Evaluate(Activity activity)
        {
            var challenge = Please.Give(new ChallengeInProgress(activity.From.Id)).QueryResult;

            Please.Do(new CompleteChallenge(challenge.Id));

            var reply = activity.CreateReply($"{Resources.ResourcesStrings.Congratulations} You have finished {challenge.Order + 1}/3 steps of this adventure. ");

            var areAllChallengesFromAdventureFinished =
                Please.Check(new AreAllChallengesInAdventureFinished(challenge.Adventure.Id));

            if (areAllChallengesFromAdventureFinished)
            {
                var content = challenge.Adventure.FinishedText + " ";
                if (!string.IsNullOrEmpty(challenge.Adventure.FinishedImageUrl))
                {
                    var a = new Attachment("image/png", challenge.Adventure.FinishedImageUrl, null, null, null);
                    reply.Attachments.Add(a);
                }
                reply.Text = content;
            }

            yield return reply;

            var giveUserChallengerResponses = new GiveUserChallenge().Evaluate(activity);

            if (giveUserChallengerResponses == null)
                yield break;

            foreach (var response in giveUserChallengerResponses)
            {
                yield return response;
            }
        }
    }
}