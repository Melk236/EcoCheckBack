 using EcoCheck.Domain.Entities;
 using Microsoft.AspNetCore.Mvc;
 using System.Net.Http;
 using System.Collections.Generic;
 
 using System.Text.Json;
 using Microsoft.Extensions.Configuration;


namespace EcoCheck.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TraduccionController : ControllerBase
    {
        private readonly HttpClient _http;
        private readonly string _apiKey;
        private readonly string _deeplEndpoint;

        public TraduccionController(IHttpClientFactory factory, IConfiguration config)
        {
            _http = factory.CreateClient();
            _apiKey = config["DEEPL_AUTH_KEY"] ?? config["DeepL:apiKey"];
            _deeplEndpoint = config["DEEPL_ENDPOINT"] ?? "https://api-free.deepl.com/v2/translate";
        }

        [HttpPost]
        public async Task<IActionResult> Traducir([FromBody] TraduccionRequest req)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, _deeplEndpoint);

            // Autenticación por header (DeepL v2): no enviar auth_key en el body
            request.Headers.Add("Authorization", $"DeepL-Auth-Key {_apiKey}");

            // Body en form-urlencoded solo con texto y target_lang
            var form = new List<KeyValuePair<string, string>>
            {
                new("text", req.Texto),
                new("target_lang", "ES")
            };
            request.Content = new FormUrlEncodedContent(form);
            request.Headers.Add("Accept", "application/json");

            var response = await _http.SendAsync(request);
            var raw = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                return StatusCode((int)response.StatusCode, new { message = "DeepL API error", detail = raw });
            }
            var json = JsonSerializer.Deserialize<JsonElement>(raw);
            var result = json.GetProperty("translations")[0].GetProperty("text").GetString();
            return Ok(new { texto = result });
        }
    }

    
 


}
