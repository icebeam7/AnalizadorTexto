using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Net.Http.Headers;

using AnalizadorTexto.Modelos;
using Newtonsoft.Json;

namespace AnalizadorTexto.Servicios
{
    public static class ServicioText
    {
        private static readonly HttpClient client = 
            CreateHttpClient();

        public async static Task<Document> AnalyzeText(string message)
        {
            var documents = PrepareRequest(message);

            var content = new StringContent(documents);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var response = await client.PostAsync("text/analytics/v2.0/sentiment",  content);

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<DocumentResponse>(json);
                return result.Documents.FirstOrDefault();
            }

            return default(Document);
        }

        private static HttpClient CreateHttpClient()
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("http://192.168.99.100:5000/");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            return client;
        }

        private static string PrepareRequest(string message)
        {
            var wrapper = new
            {
                documents = new List<DocumentRequest>()
                {
                    new DocumentRequest()
                    {
                        Id = "1",
                        Language = "en",
                        Text = message
                    }
                }
            };

            return JsonConvert.SerializeObject(wrapper);

        }
    }
}
