using System.Collections.Generic;
using Microsoft.Bot.Connector;
using Teamdare.Domain.DecisionTree.Actions;
using Teamdare.Domain.DecisionTree.Base;
using Teamdare.Domain.Queries;

namespace Teamdare.Domain.DecisionTree.Queries
{
    public class CheckIfPlayerIsAlreadyRegistered : DecisionQuery<Activity, IEnumerable<Activity>>
    {
        public CheckIfPlayerIsAlreadyRegistered()
        {
            Test = activity => Please.Check(
                new IsUserRegistered(activity.From.Id, activity.Conversation.Id, activity.ServiceUrl));
            Positive = new CheckIfAnyChallengeIsInProgress();
            Negative = new WelcomeUser();

        }
    }
}