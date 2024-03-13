using Newtonsoft.Json;
using RabbitMQ.Client;
using System.Text;

namespace TestAPIaWEBaASP.RabbitMQ
{
    public class Producer : Imessage
    {
        public void SendMessage<T>(T message)
        {
            var factory = new ConnectionFactory
            {
                HostName = "localhost",
                Port = 5672
            };

            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                // объявляем обменник "Messages" 
                channel.ExchangeDeclare(exchange: "Messages", type: ExchangeType.Fanout);

                var jsonMessage = JsonConvert.SerializeObject(message);
                var body = Encoding.UTF8.GetBytes(jsonMessage);

                channel.BasicPublish(exchange: "Messages",
                                     routingKey: "",
                                     body: body);
            }
        }
    }
}
