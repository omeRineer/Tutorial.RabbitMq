using RabbitMQ.Client;

namespace Configuration
{
    public static class RabbitMqService
    {
        private static ConnectionFactory connectionFactory;
        static RabbitMqService()
        {
            connectionFactory = new ConnectionFactory
            {
                Uri = new Uri("amqps://dphzwrlp:P2A5RQtSuAQAh4awwxcpSB8pH92D51Fz@chimpanzee.rmq.cloudamqp.com/dphzwrlp")
            };
        }
        public static IModel CreateChannel()
        {
            var connection = connectionFactory.CreateConnection();

            return connection.CreateModel();
        }
    }
}
