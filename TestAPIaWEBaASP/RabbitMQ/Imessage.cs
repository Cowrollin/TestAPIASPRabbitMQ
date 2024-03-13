using Newtonsoft.Json;
using RabbitMQ.Client;
using System.Text;

namespace TestAPIaWEBaASP.RabbitMQ
{
    public interface Imessage
    {
        void SendMessage<T>(T message);
    }
}
