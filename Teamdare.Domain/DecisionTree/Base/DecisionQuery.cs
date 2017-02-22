using System;

namespace Teamdare.Domain.DecisionTree.Base
{
    /// <summary>
    /// as seen on Real-World Functional Programming / http://stackoverflow.com/questions/3889301/how-to-implement-decision-tree-with-c-sharp-visual-studio-2008-help
    /// </summary>
    // Listing 8.16 Simplified implementation of Template method
    public class DecisionQuery<T,TV> : Decision<T,TV>
    {
        public string Title { get; set; }
        public Decision<T, TV> Positive { get; set; } = new DecisionResult<T, TV>();
        public Decision<T, TV> Negative { get; set; } = new DecisionResult<T, TV>();
        public Func<T, bool> Test { get; set; }

        public override TV Evaluate(T client)
        {
            return Test(client) ? Positive.Evaluate(client) : Negative.Evaluate(client);
        }
    }
}