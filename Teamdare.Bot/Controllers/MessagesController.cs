using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Bot.Connector;
using Teamdare.Database;
using Teamdare.Database.Entities;

namespace Teamdare.Bot.Controllers
{
    /// <summary>
    /// This controller will receive the skype messages and handle them to the EchoBot service.
    /// </summary>
    [Route("api/[controller]")]
    public class MessagesController : Controller
    {
        private readonly TeamdareContext _context;

        public MessagesController(TeamdareContext context)
        {
            _context = context;
        }

        /// <summary>
        /// This method will be called every time the bot receives an activity. This is the messaging endpoint
        /// </summary>
        /// <param name="activity">The activity sent to the bot. I'm using dynamic here to simplify the code for the post</param>
        /// <returns>201 Created</returns>
        [HttpPost]
        public virtual async Task<HttpResponseMessage> Post([FromBody] Activity activity)
        {
            if (activity != null)
            {
                var connector = new ConnectorClient(new Uri(activity.ServiceUrl));
                var reply = activity.CreateReply();
                switch (activity.GetActivityType())
                {
                    case ActivityTypes.Message:
                        reply.Text = activity.Text;
                        await connector.Conversations.ReplyToActivityAsync(reply);
                        break;

                    case ActivityTypes.ConversationUpdate:
                        if (activity.MembersAdded.Any())
                        {
                            reply.Text = "Welcome! ;-)";
                            await connector.Conversations.ReplyToActivityAsync(reply);
                        }
                        break;
                }
            }

            return new HttpResponseMessage(System.Net.HttpStatusCode.Accepted);
        }

    }
}