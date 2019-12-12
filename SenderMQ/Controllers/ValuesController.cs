using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SenderMQ.Model;
using SenderMQ.RabbitMQ;

namespace SenderMQ.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {

        private string _nameOfQueue = "QueueExemple";
        private IRabbitOperations _manager;

        public ValuesController(IRabbitOperations manager)
        {
            _manager = manager;
        }
      
        // POST api/values
        [HttpPost]
        public void Post(Message message)
        {
            _manager.Publish(message, _nameOfQueue);
        }

       
    }
}
