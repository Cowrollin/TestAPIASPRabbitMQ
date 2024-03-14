using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using MassTransit;
using Imessage;
// Consumer который получает сообщения

var busControl = Bus.Factory.CreateUsingRabbitMq(cfg =>
{
    cfg.ReceiveEndpoint("message-created-event", e =>
    {
        e.Consumer<MessageConsumer>();
    });
});

await busControl.StartAsync(new CancellationToken());

try
{
    Console.WriteLine("Press enter to exit");

    await Task.Run(() => Console.ReadLine());
}
finally
{
    await busControl.StopAsync();
}

class MessageConsumer : IConsumer<IMessages>
{
    public async Task Consume(ConsumeContext<IMessages> context)
    {
        var jsonMessage = JsonConvert.SerializeObject(context.Message);
        Console.WriteLine($"Have new message!: {jsonMessage}");
    }
}

