using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReceverMQ.RabbitMQ
{
    public interface IRabbitOperations
    {

        string Subscriber(string routeKey = "QueueExemple");
    }
}
