using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RequestProject.Policies;

namespace RequestProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequestController : ControllerBase
    {
        private readonly ClientPolicy _clientPolicy;

        public RequestController(ClientPolicy clientPolicy)
        {
            _clientPolicy = clientPolicy;
        }
        [HttpGet]
        public async Task<ActionResult> MakeRequest()
        {
            HttpClient client = new HttpClient();
            //var response = await client.GetAsync("https://localhost:7257/api/Response/5");

            var response = await _clientPolicy.ImmediteHttpRetryPolicy.ExecuteAsync(()=> client.GetAsync("https://localhost:7257/api/Response/5"));
            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("Response service returned sucsess result ");
                return Ok();
            }
            Console.WriteLine("Response service returned Fail result ");
            return StatusCode(StatusCodes.Status500InternalServerError);

        }
    }
}
