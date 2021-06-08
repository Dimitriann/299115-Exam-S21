using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using WebApplication.Models;

namespace WebApplication.Data
{
    public class PlayerServiceRest : IPlayerService
    {
        private string uri = "http://localhost:5000/Player";
        private HttpClient client;


        public PlayerServiceRest()
        {
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) =>
            {
                return true;
            };
            client = new HttpClient(clientHandler);
        }

        public async Task<Player> AddPlayer(Player player)
        {
            string PlayerAsJSON = JsonSerializer.Serialize(player);
            HttpContent content = new StringContent(
                PlayerAsJSON,
                Encoding.UTF8,
                "application/json");
            HttpResponseMessage response = await client.PostAsync(uri, content);
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($@"Error: {response.ReasonPhrase}");
            }

            string result = await response.Content.ReadAsStringAsync();
            Player newPlayer = JsonSerializer.Deserialize<Player>(result,
                new JsonSerializerOptions {PropertyNamingPolicy = JsonNamingPolicy.CamelCase});
            return newPlayer;
        }

        public async Task<Player> DeletePlayer(int PLayerId)
        {
            HttpResponseMessage response =
                await client.DeleteAsync(uri + $"?PLayerId={@PLayerId}");
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($@"Error: {response.ReasonPhrase}");
            }

            string result = await response.Content.ReadAsStringAsync();

            Player removedPLayer = JsonSerializer.Deserialize<Player>(result,
                new JsonSerializerOptions {PropertyNamingPolicy = JsonNamingPolicy.CamelCase});
            return removedPLayer;
        }

    }
}
