using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
namespace TestClasses
{
    public class TestMethods
    {
        public string GetBearerToken()
        {
            var client = new RestClient("Blank");
            var request = new RestRequest("Authenticate", Method.POST);
            var credentials = new
            {
                Username = "Blank",
                Password = "Blank",
            };
            request.AddJsonBody(credentials);

            var response = client.Execute(request);
            var content = response.Content;

            Agent convertedJson = JsonConvert.DeserializeObject<Agent>(content);
            var token = convertedJson.Token;
            return token;
        }
        public HttpStatusCode ReturningStatusCode()
        {
            var client = new RestClient("Blank");
            var request = new RestRequest("Authenticate", Method.POST);
            var credentials = new
            {
                Username = "Blank",
                Password = "Blank",
            };
            request.AddJsonBody(credentials);

            var response = client.Execute(request);
            var token = response.StatusCode;
            return token;
        }
        public Agents GetAgent()
        {
            var client = new RestClient("Blank");
            var request = new RestRequest(Method.GET);
            request.AddHeader("Authorization", "Bearer " + GetBearerToken());

            var response = client.Execute(request);
            var content = response.Content;

            return JsonConvert.DeserializeObject<Agents>(content);
        }
    }
    public class Agent
    {
        [JsonProperty("agentId")]
        public string agentId { get; set; }

        [JsonProperty("firstName")]
        public string FirstName { get; set; }

        [JsonProperty("lastName")]
        public string LastName { get; set; }

        [JsonProperty("username")]
        public string Username { get; set; }

        [JsonProperty("password")]
        public string Password { get; set; }

        [JsonProperty("companyId")]
        public string CompanyId { get; set; }

        [JsonProperty("roleId")]
        public string RoleId { get; set; }

        [JsonProperty("siteIdListStr")]
        public string SiteIdListStr { get; set; }

        [JsonProperty("company")]
        public string Company { get; set; }

        [JsonProperty("role")]
        public string Role { get; set; }

        [JsonProperty("token")]
        public string Token { get; set; }
    }
    public class Agents
    {
        [JsonProperty("agents")]

        public Agent[] tempArray { get; set; }
    }
}
