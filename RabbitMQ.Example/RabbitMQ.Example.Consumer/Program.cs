using System;
using RabbitMQ.Client;
using RabbitMQ.Example.Common;

namespace RabbitMQ.Example.Consumer
{
    public class Program
    {
        private static string QueueName = "StandardQueue_ExampleQueue";

        public static void Main(string[] args)
        {
            ConnectionFactory connectionFactory = new ConnectionFactory
            {
                HostName = "localhost",
                UserName = "rabbitmq",
                Password = "rabbitmq",
            };

            var connection = connectionFactory.CreateConnection();
            var channel = connection.CreateModel();
            // accept only one unack-ed message at a time
            // uint prefetchSize, ushort prefetchCount, bool global
            channel.BasicQos(0, 1, false);
            MessageReceiver messageReceiver = new MessageReceiver(channel);
            channel.BasicConsume(QueueName, false, messageReceiver);

            Console.ReadLine();
        }

    }

    public class MessageReceiver : DefaultBasicConsumer
    {
        private readonly IModel _channel;

        public MessageReceiver(IModel channel)
        {
            _channel = channel;
        }

        public override void HandleBasicDeliver(string consumerTag, ulong deliveryTag, bool redelivered, string exchange, string routingKey, IBasicProperties properties, ReadOnlyMemory<byte> bytes)
        {
            Console.WriteLine($"Consuming Message");
            Console.WriteLine(string.Concat("Message received from the exchange ", exchange));
            Console.WriteLine(string.Concat("Consumer tag: ", consumerTag));
            Console.WriteLine(string.Concat("Delivery tag: ", deliveryTag));
            Console.WriteLine(string.Concat("Routing tag: ", routingKey));
            var payment = bytes.Deserialize<Payment>();
            Console.WriteLine(" Payment Information");
            Console.WriteLine($"             Amount: {payment.Amount}");
            Console.WriteLine($"   Card Information: {payment.CardNumber}");
            Console.WriteLine($"               Type: {payment.Type}");
            Console.WriteLine($"               Name: {payment.Name}");

            _channel.BasicAck(deliveryTag, false);
        }
    }
}
