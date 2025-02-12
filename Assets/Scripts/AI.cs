using System;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ProblemInterpreter
{
    public class AI
    {
        private const string url = @"https://hacku2025.weathered-limit-8e5c.workers.dev";
        private HttpRequestMessage request;
        private HttpClient client;

        public AI()
        {
            request = new HttpRequestMessage(HttpMethod.Post, url);
            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("Accept-Charset", "utf-8");
            client = new HttpClient();
        }

        // AIにデータを送りつけ、返答を得る
        public async Task<string> Ask(string imagePath)
        {
            byte[] imageBytes = await File.ReadAllBytesAsync(imagePath);
            var base64string = Convert.ToBase64String(imageBytes);
            string mimeType = $"image/{Path.GetExtension(imagePath).TrimStart('.')}";
            string json = $"\"mime_type\": \"{mimeType}\", \"data\": \"{base64string}\"";
            var content = new StringContent("{" + json + "}", Encoding.UTF8, "application/json");

            var response = await client.PostAsync(url, content);
            var body = await response.Content.ReadAsStringAsync();

            return body;
        }
    }
}