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

            var reply = activity.CreateReply(String.Format("You have finished {0}/3 steps of this adventure. ", challenge.Order + 1));

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

            foreach (var response in new GiveUserChallenge().Evaluate(activity))
            {
                yield return response;
            }
        }
    }
}