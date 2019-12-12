using Microsoft.Extensions.ObjectPool;
using Newtonsoft.Json;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReceverMQ.RabbitMQ
{
    public class RabbitOperations : IRabbitOperations
    {
        private readonly DefaultObjectPool<IModel> _objectPool;

        public RabbitOperations(IPooledObjectPolicy<IModel> objectPolicy)
        {
            _objectPool = new DefaultObjectPool<IModel>(objectPolicy, Environment.ProcessorCount * 2);
        }

        public string Subscriber(string routeKey = "QueueExemple")
        {
            var channel = _objectPool.Get();


            channel.QueueDeclare(routeKey, false, false, false, null);

            var data = channel.BasicGet(routeKey, false);

            if (data == null)
                return "No messages in Queu";

            var message = Encoding.UTF8.GetString(data.Body);

            channel.BasicAck(data.DeliveryTag, false);

            return message;
        }


    }
}
