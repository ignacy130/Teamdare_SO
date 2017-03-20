using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.Bot.Connector;
using Microsoft.Extensions.Caching.Memory;
using Teamdare.Bot.Authentication;
using Teamdare.Domain.DecisionTree;
using System.Linq;

namespace Teamdare.Bot.Communications.Channels
{
    public class MessagesChannel : IChannel
    {
        private readonly IMemoryCache _memoryCache;
        private readonly BotCredentials _botCredentials;
        private readonly Responses _responses;
        private readonly DecisionTreeHead _decisionTreeHead;

        public MessagesChannel(Responses responses, DecisionTreeHead decisionTreeHead, IMemoryCache memoryCache, BotCredentials botCredentials)
        {
            _responses = responses;
            _decisionTreeHead = decisionTreeHead;
            _memoryCache = memoryCache;
            _botCredentials = botCredentials;
        }

        public async Task Handle(Activity activity)
        {
            //var connector = this._responses.GetConnector(activity);
            var url = _responses.GetReplyUrl(activity);
            var token = await GetBotApiToken();

            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

				var results = _decisionTreeHead.Evaluate(activity).ToList();

				foreach (var response in results)
                {
					if (response == results.First() || response != results.Last())
					{
						var typing = activity.CreateReply();
						typing.Type = ActivityTypes.Typing;
						typing.Text = null;
						await client.PostAsJsonAsync<Activity>(url, typing);
					}
					await client.PostAsJsonAsync<Activity>(url, response);
				}
            }
        }

        private async Task<string> GetBotApiToken()
        {
            // Check to see if we already have a valid token
            string token = _memoryCache.Get("token")?.ToString();
            if (string.IsNullOrEmpty(token))
            {
                // we need to get a token.
                using (var client = new HttpClient())
                {
                    // Create the encoded content needed to get a token
                    var parameters = new Dictionary<string, string>
                    {
                        {"client_id", this._botCredentials.MicrosoftAppId },
                        {"client_secret", this._botCredentials.MicrosoftAppPassword },
                        {"scope", "https://graph.microsoft.com/.default" },
                        {"grant_type", "client_credentials" }
                    };
                    var content = new FormUrlEncodedContent(parameters);

                    // Post
                    var response = await client.PostAsync("https://login.microsoftonline.com/common/oauth2/v2.0/token", content);

                    // Get the token response
                    var tokenResponse = await response.Content.ReadAsAsync<TokenResponse>();

                    token = tokenResponse.access_token;

                    // Cache the token for 15 minutes.
                    _memoryCache.Set(
                        "token",
                        token,
                        new DateTimeOffset(DateTime.Now.AddSeconds(tokenResponse.expires_in)));
                }
            }

            return token;
        }
    }
}