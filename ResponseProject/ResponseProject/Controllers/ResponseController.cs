using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ResponseProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResponseController : ControllerBase
    {

        [HttpGet]
        [Route("{id:int}")]
        public ActionResult GetResponse(int id)
        {
            Random random = new Random();
            int randomInteger = random.Next(1, 11);

            if (randomInteger >= id)
            {
                Console.WriteLine("Resposnse Service Generate Internal server error HTTP 500");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

            Console.WriteLine("Resposnse Service Generate Sucess HTTP 200");
            return Ok();
        }
    }
}
