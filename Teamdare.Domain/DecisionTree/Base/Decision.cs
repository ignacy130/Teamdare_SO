using System;

namespace Teamdare.Domain.DecisionTree.Base
{
    /// <summary>
    /// as seen on Real-World Functional Programming / http://stackoverflow.com/questions/3889301/how-to-implement-decision-tree-with-c-sharp-visual-studio-2008-help
    /// </summary>
    public abstract class Decision<T,I>
    {
        // Tests the given client
        public abstract I Evaluate(T client);
    }
}