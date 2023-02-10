using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebSocket.Business;

namespace WebSocket.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly MyBusiness _myBusiness;

        public HomeController(MyBusiness myBusiness)
        {
            _myBusiness = myBusiness;
        }

        [HttpGet("{message}")]
        public async Task<IActionResult> SendMessage(string message)
        {
            await _myBusiness.SenMessageAsync(message);
            return Ok();
        }
    }
}
