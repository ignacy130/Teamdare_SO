using System.Collections.Generic;
using Microsoft.Bot.Connector;
using Teamdare.Domain.Commands;
using Teamdare.Domain.DecisionTree.Base;
using Teamdare.Resources;

namespace Teamdare.Domain.DecisionTree.Actions
{
    public class WelcomeUser : DecisionResult<Activity, IEnumerable<Activity>>
    {
        public override IEnumerable<Activity> Evaluate(Activity activity)
        {
            Please.Do(new InitializeGame(activity.From.Name, activity.From.Id, activity.Conversation.Id, activity.ServiceUrl));
			var reply = activity.CreateReply();
			var actionCard = new ThumbnailCard()
			{
				Buttons = new List<CardAction>()
				{
					new CardAction
					{
						Value = "I'm ready!",
						Title = "I'm ready!",
						Type = "imBack"
					}
				},
				Text = ResourcesStrings.WelcomeText
			};
			reply.Attachments.Add(actionCard.ToAttachment());
			yield return reply;
        }
    }
}