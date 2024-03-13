using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RabbitMQ.Client;
using System.Text;
using TestAPIaWEBaASP.Data;
using TestAPIaWEBaASP.RabbitMQ;

namespace TestAPIaWEBaASP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RabbitMQMessageController : ControllerBase
    {
        private readonly ImessageDB _context;
        private readonly Imessage _MessagePublisher;

        public RabbitMQMessageController(Imessage messagePublisher, ImessageDB context)
        {
            _context = context;
            _MessagePublisher = messagePublisher;
        }

        // Post запрос, который отправляет сообщение
        [HttpPost]
        public async Task<IActionResult> PostMessage(Messages message)
        {
            MessageDB messagedb = new()
            {
                Title = message.Title,
                Message = message.Message
            };

            _context.MessageDB.Add(messagedb);

            await _context.SaveChangesAsync();

            _MessagePublisher.SendMessage(message);
            return Ok(new { id = messagedb.ID});
        }
    }
}
