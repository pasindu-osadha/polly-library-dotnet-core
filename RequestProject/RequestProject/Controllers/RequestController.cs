using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace RequestProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequestController : ControllerBase
    {

        [HttpGet]
        public async Task<ActionResult> MakeRequest()
        {
            HttpClient client = new HttpClient();
            var response = await client.GetAsync("https://localhost:7257/api/Response/5");

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
