using System;

namespace Teamdare.Domain.DecisionTree.Base
{
    /// <summary>
    /// as seen on Real-World Functional Programming / http://stackoverflow.com/questions/3889301/how-to-implement-decision-tree-with-c-sharp-visual-studio-2008-help
    /// </summary>
    public class DecisionResult<T,TV> : Decision<T,TV>
    {
        public Func<T, TV> Perform { get; set; }
        public override TV Evaluate(T client)
        {
            // Print the final result
            return Perform(client);
        }
    }
}