using EcoCheck.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace EcoCheck.Controllers
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
            var content = new FormUrlEncodedContent(new[]
            {
            new KeyValuePair<string,string>("auth_key", _apiKey),
            new KeyValuePair<string,string>("text", req.Texto),
            new KeyValuePair<string,string>("target_lang", "ES")
        });

            var response = await _http.PostAsync("https://api-free.deepl.com/v2/translate", content);
            var raw = await response.Content.ReadAsStringAsync();

            var json = JsonSerializer.Deserialize<JsonElement>(raw);
            var result = json.GetProperty("translations")[0].GetProperty("text").GetString();

            return Ok(new {texto=result});
        }
    }

    
 


}