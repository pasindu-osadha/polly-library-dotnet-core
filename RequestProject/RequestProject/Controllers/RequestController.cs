using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RequestProject.Policies;

namespace RequestProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequestController : ControllerBase
    {
        private readonly IHttpClientFactory _clientFactory;
        private readonly ClientPolicy _clientPolicy;

        public RequestController(ClientPolicy clientPolicy, IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
            _clientPolicy = clientPolicy;
        }
        [HttpGet]
        public async Task<ActionResult> MakeRequest()
        {
            //HttpClient client = new HttpClient();
            var client = _clientFactory.CreateClient("ImmediateRetry");
            
            var response = await client.GetAsync("https://localhost:7257/api/Response/5");

            //Immediate retry policy 
            //var response = await _clientPolicy.ImmediteHttpRetryPolicy.ExecuteAsync(()=> client.GetAsync("https://localhost:7257/api/Response/5"));
           
            // linear retry policy 
            //var response = await _clientPolicy.LinearHttpRetryPolicy.ExecuteAsync(() => client.GetAsync("https://localhost:7257/api/Response/5"));

            // Exponential retry policy 
            //var response = await _clientPolicy.ExponentialHttpRetryPolicy.ExecuteAsync(() => client.GetAsync("https://localhost:7257/api/Response/5"));

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
