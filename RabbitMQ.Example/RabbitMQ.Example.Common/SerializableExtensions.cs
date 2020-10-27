using System;
using System.Collections.ObjectModel;
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

        public static T Deserialize<T>(this ReadOnlyMemory<byte> bytes)
        {
            var json = Encoding.Default.GetString(bytes.ToArray());

            return JsonConvert.DeserializeObject<T>(json);
        }
    }
}
