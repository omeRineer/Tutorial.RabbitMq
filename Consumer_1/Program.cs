using Configuration;
using RabbitMQ.Client.Events;
using System.Text;

using (var channel = RabbitMqService.CreateChannel())
{
    var consumer = new EventingBasicConsumer(channel);

    consumer.Received += (model, ea) =>
    {
        var body = ea.Body.ToArray();
        var message = Encoding.UTF8.GetString(body);

        Console.WriteLine(message);

    };

    channel.BasicConsume(queue: "Queue_1",
                         autoAck: false,
                         consumer: consumer,
                         consumerTag: "Consumer_1",
                         exclusive: false,
                         noLocal: false,
                         arguments: null);


    Console.ReadKey();
}
