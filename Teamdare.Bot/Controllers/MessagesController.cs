using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Bot.Connector;
using Teamdare.Bot.Communications;

namespace Teamdare.Bot.Controllers
{
    /// <summary>
    /// This controller will receive the skype messages and handle them to the EchoBot service.
    /// </summary>
    [Route("api/[controller]")]
    public class MessagesController : Controller
    {
        private readonly CommunicationChannel _communicationChannel;

        public MessagesController(CommunicationChannel communicationChannel)
        {
            _communicationChannel = communicationChannel;
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
                await _communicationChannel.Handle(activity);
            }

            return new HttpResponseMessage(System.Net.HttpStatusCode.Accepted);
        }

    }
}