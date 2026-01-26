using EcoCheck.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using System.Text.Json;

namespace EcoCheck.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TraduccionController : ControllerBase
    {
        private readonly HttpClient _http;
        private readonly string _apiKey;

        public TraduccionController(IHttpClientFactory factory, IConfiguration config)
        {
            _http = factory.CreateClient();
            _apiKey = config["DeepL:apiKey"];
        }

        [HttpPost]
        public async Task<IActionResult> Traducir([FromBody] TraduccionRequest req)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, "https://api-free.deepl.com/v1/translate");
            Console.WriteLine(_apiKey);
            // Agregar header de autenticación
            request.Headers.Add("Authorization", $"DeepL-Auth-Key {_apiKey}");

            // Body en formato JSON
            var body = new
            {
                text = new[] { req.Texto },
                target_lang = "ES"
            };

            request.Content = new StringContent(
                JsonSerializer.Serialize(body),
                Encoding.UTF8,
                "application/json"
            );

            var response = await _http.SendAsync(request);
            var raw = await response.Content.ReadAsStringAsync();
            var json = JsonSerializer.Deserialize<JsonElement>(raw);
            Console.WriteLine(json);
            var result = json.GetProperty("translations")[0].GetProperty("text").GetString();
            return Ok(new { texto = result });
        }
    }

    
 


}