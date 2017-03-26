using System.Collections.Generic;
using Microsoft.Bot.Connector;
using Teamdare.Domain.DecisionTree.Actions;
using Teamdare.Domain.DecisionTree.Base;
using Teamdare.Domain.NLP;

namespace Teamdare.Domain.DecisionTree.Queries
{
    public class CheckIfChallengeShouldBeFinished : DecisionQuery<Activity, IEnumerable<Activity>>
    {
        public CheckIfChallengeShouldBeFinished()
        {
            Test = activity => NLPProcessor.DoesMessageMeanThatUserFinishedPrevChallenge(activity.Text);
            Positive = new CompleteUserChallenge();
            Negative = new AskUserAboutProgress();
        }
    }
}