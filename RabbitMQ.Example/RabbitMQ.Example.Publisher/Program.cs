using System;
using RabbitMQ.Client;
using RabbitMQ.Example.Common;

namespace RabbitMQ.Example.Publisher
{
    public class Program
    {
        private static ConnectionFactory _factory;
        private static IConnection _connection;
        private static IModel _model;

        private static string QueueName = "StandardQueue_ExampleQueue";

        public static void Main(string[] args)
        {
            CreateQueue();

            var payment1 = new Payment { Name = "Bob", Type = "Visa", Amount = 73m, CardNumber = "1234-5678"};
            var payment2 = new Payment { Name = "Will", Type = "Visa", Amount = 73m, CardNumber = "8888-9999" };
            var payment3 = new Payment { Name = "John", Type = "Mastercard", Amount = 73m, CardNumber = "2222-4444" };
            var payment4 = new Payment { Name = "Sam", Type = "Discover", Amount = 73m, CardNumber = "5678-9876" };

            SendMessage(payment1);
            SendMessage(payment2);
            SendMessage(payment3);
            SendMessage(payment4);

            Console.WriteLine("Hello World!");
        }

        private static void CreateQueue()
        {
            _factory = new ConnectionFactory { HostName = "localhost", UserName = "rabbitmq", Password = "rabbitmq"};
            _connection = _factory.CreateConnection();

            _model = _connection.CreateModel();

            _model.QueueDeclare(QueueName, true, false, false, null);
        }

        private static void SendMessage(Payment payment)
        {
            _model.BasicPublish("", QueueName, null, payment.Serialize());
            Console.WriteLine($"[x] Payment Message Sent: {payment.Name} - {payment.Amount}");
        }
    }
}
