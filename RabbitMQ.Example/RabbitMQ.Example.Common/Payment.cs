using System;

namespace RabbitMQ.Example.Common
{
    [Serializable]
    public class Payment
    {
        public string Name { get; set; }

        public string Type { get; set; }

        public string CardNumber { get; set; }

        public decimal Amount { get; set; }
    }
}
