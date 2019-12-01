using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SenderMQ.RabbitMQ
{
    public interface IRabbitOperations
    {
        void Publish<T>(T message, string exchangeType, string routeKey)
        where T : class;
    }
}
