
using Configuration;
using RabbitMQ.Client.Events;
using System.Text;

using (var channel = RabbitMqService.CreateChannel())
{
    channel.QueueDeclare(queue: "Queue_1",
                         durable: false,
                         exclusive: false,
                         autoDelete: false,
                         arguments: null);

Input:
    var message = Console.ReadLine();
    var body = Encoding.UTF8.GetBytes(message);

    channel.BasicPublish(exchange: "",
                         routingKey: "Queue_1",
                         body: body,
                         basicProperties: null,
                         mandatory: false);

    goto Input;
}