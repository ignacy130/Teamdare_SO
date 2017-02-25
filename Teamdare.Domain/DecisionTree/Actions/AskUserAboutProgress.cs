using System.Collections.Generic;
using Microsoft.Bot.Connector;
using Teamdare.Domain.DecisionTree.Base;
using Teamdare.Domain.Queries;
using Teamdare.Resources;

namespace Teamdare.Domain.DecisionTree.Actions
{
    public class AskUserAboutProgress : DecisionResult<Activity, IEnumerable<Activity>>
    {
        public override IEnumerable<Activity> Evaluate(Activity activity)
        {
            var challengeInProgress = Please.Give(new ChallengeInProgress(activity.From.Id)).QueryResult;
            var content = string.Format(ResourcesStrings.AdventureHowIsChallengeGoing, challengeInProgress.Title);
            var reply = activity.CreateReply();
            var actionCard = new ThumbnailCard()
            {
                Buttons = GetActions(),
                Text = content
            };
            reply.Attachments.Add(actionCard.ToAttachment());

            yield return reply;
        }

        private IList<CardAction> GetActions()
        {
            var actions = new List<CardAction>
            {
                new CardAction
                {
                    Value = "I've done it!",
                    Title = "I've done it!",
                    Type = "imBack"
                },
                new CardAction
                {
                    Value = "Not yet...",
                    Title = "Not yet...",
                    Type = "imBack"
                }
            };
            return actions;
        }
    }
}