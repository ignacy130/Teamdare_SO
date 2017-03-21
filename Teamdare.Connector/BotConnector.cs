using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.Bot.Connector;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using Teamdare.Connector.Authentication;

namespace Teamdare.Connector
{
    public class BotConnector
    {
        private readonly IMemoryCache _memoryCache;
        private readonly BotCredentials _botCredentials;
        private readonly ILogger<BotConnector> _logger;

        //WHY STATIC? https://aspnetmonsters.com/2016/08/2016-08-27-httpclientwrong/
        private static readonly HttpClient HttpClient = new HttpClient();

        public BotConnector(BotCredentials botCredentials, IMemoryCache memoryCache, ILogger<BotConnector> logger)
        {
            _botCredentials = botCredentials;
            _memoryCache = memoryCache;
            _logger = logger;
        }

        public async Task SendToConversationAsync(string serviceUrl, Activity response)
        {
            var replyUrl = this.GetReplyUrl(serviceUrl, response.Conversation.Id);
            var token = await this.GetBotApiToken();

            _logger.LogDebug($"SendToConversationAsync => {replyUrl}");

            HttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            await HttpClient.PostAsJsonAsync<Activity>(replyUrl, response);
        }

        public async Task ReplyToActivityAsync(Activity activity, Activity response)
        {
            if (activity.ReplyToId == "0")
            {
                await this.SendToConversationAsync(activity.ServiceUrl, response);
            }
            else
            {
                var replyUrl = this.GetReplyUrl(activity);
                var token = await this.GetBotApiToken();

                _logger.LogDebug($"ReplyToActivityAsync => {replyUrl}");

                HttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                await HttpClient.PostAsJsonAsync<Activity>(replyUrl, response);
            }
        }

        private async Task<string> GetBotApiToken()
        {
            // Check to see if we already have a valid token
            var token = _memoryCache.Get("token")?.ToString();

            if (!string.IsNullOrEmpty(token))
                return token;

            // Create the encoded content needed to get a token
            var parameters = new Dictionary<string, string>
            {
                {"client_id", this._botCredentials.MicrosoftAppId},
                {"client_secret", this._botCredentials.MicrosoftAppPassword},
                {"scope", "https://graph.microsoft.com/.default"},
                {"grant_type", "client_credentials"}
            };
            var content = new FormUrlEncodedContent(parameters);

            // Post
            var response = await HttpClient.PostAsync("https://login.microsoftonline.com/common/oauth2/v2.0/token",
                content);

            // Get the token response
            var tokenResponse = await response.Content.ReadAsAsync<TokenResponse>();

            token = tokenResponse.access_token;

            // Cache the token for some time
            _memoryCache.Set(
                "token",
                token,
                new DateTimeOffset(DateTime.Now.AddSeconds(tokenResponse.expires_in)));

            return token;
        }

        private string GetReplyUrl(string serviceUrl, string conversationId)
        {
            var url = new Uri(new Uri(serviceUrl + (serviceUrl.EndsWith("/") ? "" : "/")),
                "v3/conversations/{conversationId}/activities").ToString();
            url = url.Replace("{conversationId}", Uri.EscapeDataString(conversationId));
            return url;
        }

        private string GetReplyUrl(Activity activity)
        {
            var url = new Uri(new Uri(activity.ServiceUrl + (activity.ServiceUrl.EndsWith("/") ? "" : "/")),
                "v3/conversations/{conversationId}/activities/{activityId}").ToString();
            url = url.Replace("{conversationId}", Uri.EscapeDataString(activity.Conversation.Id));
            url = url.Replace("{activityId}", Uri.EscapeDataString(activity.Id));
            return url;
        }
    }
}