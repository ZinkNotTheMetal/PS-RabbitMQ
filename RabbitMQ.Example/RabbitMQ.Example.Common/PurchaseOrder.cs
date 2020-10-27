using System;

namespace RabbitMQ.Example.Common
{
    [Serializable]
    public class PurchaseOrder
    {
        public int Id { get; set; }

        public decimal Amount { get; set; }

        public string CompanyName { get; set; }

        public int PaymentTermInDays { get; set; }
    }
}
