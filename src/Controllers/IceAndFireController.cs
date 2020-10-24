using CoreMe.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace CoreMe.Controllers
{
    [Route("api/{controller}")]
    public class IceAndFireController : Controller
    {
        private const string ApiOfIceAndFireCharactersUrl = "https://anapioficeandfire.com/api/characters";

        private readonly HttpClient _httpClient;

        public IceAndFireController(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient();
        }

        /// <summary>
        /// SPA entry point
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("GetCharacter")]
        public async Task<IActionResult> GetCharacterAsync([FromQuery] int id)
        {
            if (id <= 0)
            {
                return BadRequest();
            }

            var apiResponse = await _httpClient.GetAsync($"{ApiOfIceAndFireCharactersUrl}/{id}").ConfigureAwait(false);
            var response = JsonConvert.DeserializeObject<CharacterResponse>(await apiResponse.Content.ReadAsStringAsync().ConfigureAwait(false));

            return Ok(response);
        }
    }
}