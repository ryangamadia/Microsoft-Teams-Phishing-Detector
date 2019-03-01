using Newtonsoft.Json.Linq;
using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft_Teams_Graph_RESTAPIs_Connect.Models;
using Newtonsoft.Json;
using Resources;
using System.Configuration;
using Microsoft.Graph;
using Microsoft_Teams_Graph_RESTAPIs_Connect.Models;
using System.IO;
using System.Text.RegularExpressions;

namespace Microsoft_Teams_Graph_RESTAPIs_Connect.ImportantFiles
{
    public static class Statics
    {
        public static T Deserialize<T>(this string result)
        {
            return JsonConvert.DeserializeObject<T>(result);
        }
    }

    public class GraphService : HttpHelpers
    {
        private static string GraphRootUri = ConfigurationManager.AppSettings["ida:GraphRootUri"];
        private GraphServiceClient graphClient = null;


        /// <summary>
        /// Create new channel.
        /// </summary>
        /// <param name="accessToken">Access token to validate user</param>
        /// <param name="teamId">Id of the team in which new channel needs to be created</param>
        /// <param name="channelName">New channel name</param>
        /// <param name="channelDescription">New channel description</param>
        /// <returns></returns>
        public async Task CreateChannel(string accessToken, string teamId, string channelName, string channelDescription)
        {
            await HttpPost($"/teams/{teamId}/channels",
                new Channel()
                {
                    description = channelDescription,
                    displayName = channelName
                });
        }

        public async Task<IEnumerable<Channel>> GetChannels(string accessToken, string teamId)
        {
            string endpoint = $"{GraphRootUri}/teams/{teamId}/channels";
            HttpResponseMessage response = await ServiceHelper.SendRequest(HttpMethod.Get, endpoint, accessToken);
            return await ParseList<Channel>(response);
        }

        public async Task<IEnumerable<TeamsApp>> GetApps(string accessToken, string teamId)
        {
            // to do: switch to the V1 installedApps API
            return await HttpGetList<TeamsApp>($"/teams/{teamId}/apps", endpoint: graphBetaEndpoint);
        }


        /// <summary>
        /// Get the current user's id from their profile.
        /// </summary>
        /// <param name="accessToken">Access token to validate user</param>
        /// <returns></returns>
        public async Task<string> GetMyId(String accessToken)
        {
            string endpoint = "https://graph.microsoft.com/v1.0/me";
            string queryParameter = "?$select=id";
            String userId = "";
            HttpResponseMessage response = await ServiceHelper.SendRequest(HttpMethod.Get, endpoint + queryParameter, accessToken);
            if (response != null && response.IsSuccessStatusCode)
            {
                var json = JObject.Parse(await response.Content.ReadAsStringAsync());
                userId = json.GetValue("id").ToString();
            }
            return userId?.Trim();
        }

        public async Task<IEnumerable<Team>> GetMyTeams(string accessToken)
        {
            return await HttpGetList<Team>($"/me/joinedTeams");
        }

        public async Task<IEnumerable<Models.Group>> GetMyGroups(string accessToken)
        {
            return await HttpGetList<Models.Group>($"/me/joinedGroups", endpoint: graphBetaEndpoint);
        }
        // Generate a random string with a given size  
        public string RandomString(int size, bool lowerCase)
        {
            StringBuilder builder = new StringBuilder();
            Random random = new Random();
            char ch;
            for (int i = 0; i < size; i++)
            {
                ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
                builder.Append(ch);
            }
            if (lowerCase)
                return builder.ToString().ToLower();
            return builder.ToString();
        }

        public AlertModel readAlertFromJSON() {
            using (StreamReader r = new StreamReader("C:/Users/Ryan/Desktop/Graph Test/microsoft-teams-phishing-detector/csharpteams/source/alerts.json"))
            {
                string json = r.ReadToEnd();
                AlertModel items = JsonConvert.DeserializeObject<AlertModel>(json);
                return items;
            }


        }

        public void createAlert(string unsafewebsite) {
            DateTimeOffset dto = new DateTimeOffset(DateTime.Now);

            GraphDeviceModel device = new GraphDeviceModel();
            device.Id = RandomString(11, true);
            device.DisplayName = "Ryan's PC";
            device.IsCompliant = true;
            device.Os = "Windows";
            device.OsVersion = "10.0";
            device.IsIntuneManaged = true;
            device.ApproximateLastSignIn = dto;

            IEnumerable<GraphDeviceModel> devices = new GraphDeviceModel[] { device };

            GraphUserModel user = new GraphUserModel();
            user.DisplayName = "Ryan Gamadia";
            user.Email = "rgamadia@njdeveloper.onmicrosoft.com";
            user.ContactVia = "e-mail";
            user.Upn = "Generated UPN";
            user.JobTitle = "Developer";
            user.OfficeLocation = "New York,NY";
            user.Picture = "C:/Users/Ryan/Desktop/Graph Test/microsoft-teams-phishing-detector/csharpteams/source/ryangamadia.png";
            user.OwnedDevices = devices;
            user.RegisteredDevices = devices;
            user.SelectedDevice = device;
            user.Manager = new GraphUserModel();

            AlertDeviceModel adevice = new AlertDeviceModel();
            adevice.Fqdn = "Generated Fdqn";
            adevice.IsAzureDomainJoined = true;
            adevice.PrivateIpAddress = "192.168.1.1";
            adevice.PublicIpAddress = "192.168.1.2";

            AlertModel model = new AlertModel();
            model.Id = RandomString(10, true);
            model.Metadata = "WARNING: Potentially unsafe website post attempted, alerting admin for potential security vulnerability. Risky URL: " + unsafewebsite;
            List<string> comments = new List<string>(new string[] { "Potential threat", "Phishing", "Suspicious link" });
            model.Comments = comments;
            model.Status = "unresolved";
            model.Query = "Generated query";
            model.User = user;
            model.Device = adevice;
            string alertmodeljson = JsonConvert.SerializeObject(model);
            //write string to file
            System.IO.File.WriteAllText(@"C:/Users/Ryan/Desktop/Graph Test/microsoft-teams-phishing-detector/csharpteams/source/alerts.json", alertmodeljson);
        }

        public async Task PostMessage(string accessToken, string teamId, string channelId, string message)
        {
            String urlInMessage = UrlParse(message); //Parses message for URL via RegEX Command
            Boolean safeWebsite = Verify(urlInMessage); //verifies URL via Google Safe Browse API
            if (safeWebsite == false)
            {
                //TODO: generate a JSON object that haS the message, and 
                //send the  JSON object to a function that generates an alert row
                //on the alert table

                createAlert(urlInMessage);
                message = "Potentially unsafe website post attempted, alerting admin for potential security vulnerability. Please see Alerts tab for more information."; 
            }

            await HttpPost($"/teams/{teamId}/channels/{channelId}/chatThreads",
                new PostMessage()
                {
                    rootMessage = new RootMessage()
                    {
                        body = new Models.Message()
                        {
                            content = message
                        }
                    }
                },
                endpoint: graphBetaEndpoint);
        }

        private string UrlParse(string messageWithLink)
        {
            Match text = Regex.Match(messageWithLink, @"http\://[a-zA-Z0-9\-\.]+\.[a-zA-Z]{2,3}(/\S*)?$"); //regular expression (RegEx)
            return text.Value; 
        }

        private bool Verify(string websiteURL)
        {
            String path = @"C:\Users\Ryan\Desktop\Graph Test\microsoft-teams-phishing-detector\google-safe_browsing-api-v4-master\GoogleSearch.jar";
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            process.EnableRaisingEvents = false;
            process.StartInfo.UseShellExecute = false; 
            process.StartInfo.RedirectStandardInput = true;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.FileName = "java.exe";
            process.StartInfo.Arguments = "-jar " + '"' + path;
            process.Start();
            process.StandardInput.WriteLine(websiteURL);
            String googleOutput = process.StandardOutput.ReadToEnd();
            process.WaitForExit();
            Boolean isGoodSite = Convert.ToBoolean(googleOutput);
            return isGoodSite;
        }

        public async Task<Models.Group> CreateNewTeamAndGroup(string accessToken, String displayName, String mailNickname, String description)
        {
            // create group
            Models.Group groupParams = new Models.Group()
            {
                displayName = displayName,
                mailNickname = mailNickname,
                description = description,

                groupTypes = new string[] { "Unified" },
                mailEnabled = true,
                securityEnabled = false,
                visibility = "Private",
            };

            Models.Group createdGroup = (await HttpPost($"/groups", groupParams))
                            .Deserialize<Models.Group>();
            string groupId = createdGroup.id;

            // add me as member
            string me = await GetMyId(accessToken);
            string payload = $"{{ '@odata.id': '{GraphRootUri}/users/{me}' }}";
            HttpResponseMessage responseRef = await ServiceHelper.SendRequest(HttpMethod.Post,
                $"{GraphRootUri}/groups/{groupId}/members/$ref",
                accessToken, payload);

            // create team
            await AddTeamToGroup(groupId, accessToken);
            return createdGroup;
        }

        public async Task AddTeamToGroup(string groupId, string accessToken)
        {
            await HttpPut($"/groups/{groupId}/team",
                new Team()
                {
                    guestSettings = new TeamGuestSettings()
                    {
                        allowCreateUpdateChannels = false,
                        allowDeleteChannels = false
                    }
                });
        }

        public async Task UpdateTeam(string teamId, string accessToken)
        {
            await HttpPatch($"/teams/{teamId}",
                new Team()
                {
                    guestSettings = new TeamGuestSettings() { allowCreateUpdateChannels = true, allowDeleteChannels = false }
                });
        }

        public async Task AddMember(string teamId, string upn, bool isOwner = false)
        {
            // If you have a user's UPN, you can add it directly to a group, but then there will be a 
            // significant delay before Microsoft Teams reflects the change. Instead, we find the user 
            // object's id, and add the ID to the group through the Graph beta endpoint, which is 
            // recognized by Microsoft Teams much more quickly. See 
            // https://developer.microsoft.com/en-us/graph/docs/api-reference/beta/resources/teams_api_overview 
            // for more about delays with adding members.

            // Step 1 -- Look up the user's id from their UPN
            String userId = (await HttpGet<Models.User>($"/users/{upn}")).id;

            // Step 2 -- add that id to the group
            string payload = $"{{ '@odata.id': '{graphBetaEndpoint}/users/{userId}' }}";
            await HttpPost($"/groups/{teamId}/members/$ref", payload);

            if (isOwner)
                await HttpPost($"/groups/{teamId}/owners/$ref", payload);
        }

public async Task<Tuple<IEnumerable<Alert>, string>> GetAlerts(AlertFilterModel filters, Dictionary<string, string> odredByParams = null)
        {
            if (filters == null)
            {
                var result = await this.graphClient.Security.Alerts.Request().Top(filters.Top).GetAsync();
                return new Tuple<IEnumerable<Alert>, string>(result, string.Empty);
            }
            else
            {
                // Create filter query
                var filterQuery = Microsoft_Teams_Graph_RESTAPIs_Connect.Providers.GraphQueryProvider.GetQueryByAlertFilter(filters);

                var customOrderByParams = new Dictionary<string, string>();
                //// If there are no filters and there are no custom odredByParams (if specified only top X)
                if ((odredByParams == null || odredByParams.Count() < 1) && filters.Count < 1)
                {
                    //// Order by 1. Provider 2. CreatedDateTime (desc)
                    customOrderByParams.Add("vendorInformation/provider", "asc");
                    customOrderByParams.Add("createdDateTime", "desc");
                }
                else if (filters.Count >= 1 && filters.ContainsKey("createdDateTime"))
                {
                    customOrderByParams.Add("createdDateTime", "desc");
                }

                // Create request with filter and top X
                var request = this.graphClient.Security.Alerts.Request().Filter(filterQuery).Top(filters.Top);

                // Add order py params
                if (customOrderByParams.Count > 0)
                {
                    request = request.OrderBy(string.Join(", ", customOrderByParams.Select(param => $"{param.Key} {param.Value}")));
                }
                else if (odredByParams != null && odredByParams.Count() > 0)
                {
                    request = request.OrderBy(string.Join(", ", odredByParams.Select(param => $"{param.Key} {param.Value}")));
                }

                // Get alerts
                var result = await request.GetAsync();

                return new Tuple<IEnumerable<Alert>, string>(result, filterQuery);
            }
        }
    }
}