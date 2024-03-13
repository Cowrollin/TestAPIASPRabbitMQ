using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
// Consumer который получает сообщения
internal class Program
{
    private static void Main(string[] args)
    {
        var factory = new ConnectionFactory
        {
            HostName = "localhost"
        };

        using var connection = factory.CreateConnection();
        using var channel = connection.CreateModel();

        channel.ExchangeDeclare("Messages", type: ExchangeType.Fanout);

        var queuename = channel.QueueDeclare().QueueName;

        channel.QueueBind(queue: queuename,
                                exchange: "Messages",
                                routingKey: string.Empty);

        var consumer = new EventingBasicConsumer(channel);
        consumer.Received += (sender, e) =>
        {
            // получаем и выводим сообщение
            var body = e.Body.ToArray();
            string jsonMessage = Encoding.UTF8.GetString(body);
            MyMessage message = JsonConvert.DeserializeObject<MyMessage>(jsonMessage);

            Console.WriteLine($"Получено сообщение!:");
            Console.WriteLine($"Заголовок: {message.Title}");
            Console.WriteLine($"Текст: {message.Message}");
            Console.WriteLine($"-------------------------");
        };

        channel.BasicConsume(queue: queuename,
                             autoAck: true,
                             consumer: consumer);

        Console.ReadKey();
    }
}

public class MyMessage
{
    public string Title { get; set; }
    public string Message { get; set; }
}

