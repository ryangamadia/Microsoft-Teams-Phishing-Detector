using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AntiPhishNET
{
    public class PhishingChecker
    {
        private readonly HttpClient _client = new HttpClient();
        private string _postEndpoint = @"https://app.phish.ai/api/url/scan";

        private string GetEndPoint(string scanId)
        {
            var url = @"https://app.phish.ai/api/url/report?scan_id=" + scanId;

            return url;
        }

        public async Task<string> CheckUrlAsync(string url)
        {
            var urlToCheck = new Dictionary<string, string>
            {
                { "url", url }
            };

            var content = new FormUrlEncodedContent(urlToCheck);
            var response = _client.PostAsync(_postEndpoint, content);

            return await response.Result.Content.ReadAsStringAsync();
        }

        public async Task<string> GetResultAsync(string scanId)
        {
            if (string.IsNullOrEmpty(scanId))
                throw new ArgumentNullException(nameof(scanId));

            return await _client.GetStringAsync(GetEndPoint(scanId));
        }

        public bool GetResult(string scanId)
        {
            var result = GetResultAsync(scanId).Result;

            var deserializedResults = JsonConvert.DeserializeObject<Dictionary<string, string>>(result);
            string status;
            string verdict;

            deserializedResults.TryGetValue("status", out status);
            deserializedResults.TryGetValue("verdict", out verdict);

            if (!string.IsNullOrEmpty(status) && status != "in progress")
                if (verdict == "clean")
                    return true;
                else
                    return false;
            else
            {
                return GetResult(scanId);
            }
        }
    }
}
