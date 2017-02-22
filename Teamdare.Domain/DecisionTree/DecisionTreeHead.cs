using System.Collections.Generic;
using Microsoft.Bot.Connector;
using Teamdare.Domain.DecisionTree.Base;

namespace Teamdare.Domain.DecisionTree
{
    public class DecisionTreeHead
    {
        private readonly DecisionQuery<Activity, IEnumerable<Activity>> _entryPoint;

        public DecisionTreeHead(DecisionQuery<Activity, IEnumerable<Activity>> entryPoint)
        {
            _entryPoint = entryPoint;
        }

        public IEnumerable<Activity> Evaluate(Activity activity)
        {
            return _entryPoint.Evaluate(activity);
        }
    }
}