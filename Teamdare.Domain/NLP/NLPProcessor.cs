using Teamdare.Core.Extensions;

namespace Teamdare.Domain.NLP
{
    public class NLPProcessor
    {
        public bool DoesMessageMeanThatUserFinishedPrevChallenge(string message)
        {
            return message.ToLower().ContainsAny("ok", "done", "finished") && !message.ContainsAny("not ok", "not done", "not finished");
        }

        public bool DoesMessageMeanThatUserPostponesChallenge(string message)
        {
            return message.ToLower().ContainsAny("later", "not now", "finished", "postpone");
        }
    }
}