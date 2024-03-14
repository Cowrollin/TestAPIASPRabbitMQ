using MassTransit;
using MassTransit.Transports;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Imessage;

namespace TestAPIaWEBaASP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessagesController : ControllerBase
    {
        private readonly IPublishEndpoint _publishEndpoint;

        public MessagesController(IPublishEndpoint publishEndpoint)
        {
            _publishEndpoint = publishEndpoint;
        }

        [HttpPost]
        public async Task<IActionResult> PostMessage(MessagesDTO messagetDTO)
        {
            await _publishEndpoint.Publish<IMessages>(new
            {
                Id = 1,
                messagetDTO.Title,
                messagetDTO.Message,
            });

            if(messagetDTO.Message != null) { Console.WriteLine("ERROR!!!!!!!!!!!!!!!!!!JBJASFBJASF"); }

            return Ok();
        }
    }
}
