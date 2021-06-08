using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using WebApplication.Models;

namespace WebApplication.Data
{
    public class TeamServiceRest :ITeamService
    {
        private HttpClient client;
        private string uri = "http://localhost:5000/Team";

        public TeamServiceRest()
        {
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) =>
            {
                return true;
            }; 
            client = new HttpClient(clientHandler);
        }
        public async Task<IList<Team>> GetAllTeams(int rank, string TeamName)
        {
            HttpResponseMessage responseMessage = await client.GetAsync(uri);
            if (!responseMessage.IsSuccessStatusCode)
            {
                throw new Exception($@"Error: {responseMessage.ReasonPhrase}");
            }

            string result = await responseMessage.Content.ReadAsStringAsync();
            IList<Team> gotFamilies = JsonSerializer.Deserialize<IList<Team>>(result, new JsonSerializerOptions{ PropertyNamingPolicy = JsonNamingPolicy.CamelCase});
            return gotFamilies;
        }

        public async Task<Team> AddTeam(Team team)
        {
            string teamJson = JsonSerializer.Serialize(team);
            HttpContent content = new StringContent(
                teamJson,
                Encoding.UTF8,
                "application/json");
            HttpResponseMessage responseMessage = 
                await client.PostAsync(uri,content);
            if (!responseMessage.IsSuccessStatusCode)
            {
                throw new Exception(responseMessage.ReasonPhrase);
            }

            string result = await responseMessage.Content.ReadAsStringAsync();
            Team newTeam = JsonSerializer.Deserialize<Team>(result, new JsonSerializerOptions{ PropertyNamingPolicy = JsonNamingPolicy.CamelCase});
            return newTeam;
        }
    }
}