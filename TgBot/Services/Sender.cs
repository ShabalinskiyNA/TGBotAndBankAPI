using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace HackathonTask.Services
{
    public class Sender
    {
        HttpClient httpClient = new HttpClient();


        public async Task<T> SendRequest<T>(string serverAddres)
        {
            HttpRequestMessage requestMessage = new HttpRequestMessage(HttpMethod.Get, serverAddres);
            requestMessage.Headers.Add("User-Agent", "Mozilla Failfox 5.6");

            HttpResponseMessage responseMessage = await httpClient.SendAsync(requestMessage);

            string text = await responseMessage.Content.ReadAsStringAsync();
            var res = JsonConvert.DeserializeObject<T>(text);
            return res;
        }

    }
}
