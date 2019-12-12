using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ReceverMQ.RabbitMQ;

namespace ReceverMQ.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {

        private IRabbitOperations _rabbit;
        public ValuesController(IRabbitOperations irabbit)
        {
            _rabbit = irabbit;
        }
        // GET api/values
        [HttpGet]
        public ActionResult<string> Get()
        {
            return _rabbit.Subscriber();
        }


    }
}
