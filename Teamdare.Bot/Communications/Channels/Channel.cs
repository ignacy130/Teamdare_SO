using System;
using System.Threading.Tasks;
using Microsoft.Bot.Connector;

namespace Teamdare.Bot.Communications.Channels
{
    public abstract class Channel
    {
        protected Activity CreateReply(Activity activity)
        {
            return activity.CreateReply();
        }

        protected ConnectorClient GetConnector(Activity activity)
        {
            return new ConnectorClient(new Uri(activity.ServiceUrl));
        }

        public abstract Task Handle(Activity activity);
    }
}