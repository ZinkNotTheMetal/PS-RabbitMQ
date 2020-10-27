using System;
using System.Text;
using Newtonsoft.Json;

namespace RabbitMQ.Example.Common
{
    public static class SerializableExtensions
    {
        public static byte[] Serialize(this object objectToSerialize)
        {
            if (objectToSerialize == null)
                return null;

            var json = JsonConvert.SerializeObject(objectToSerialize);
            return Encoding.ASCII.GetBytes(json);
        }

        public static Object Deserialize(this byte[] bytes)
        {
            var json = Encoding.Default.GetString(bytes);

            return JsonConvert.DeserializeObject(json);
        }
    }
}
