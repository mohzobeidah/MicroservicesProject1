using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace CommandsService.Controllers
{
    [ApiController]
    [Route("api/c/[controller]")]
    public class PlateformController : ControllerBase
    {
        public PlateformController()
        {

        }
        [HttpPost]
        public ActionResult TestInBoundConnection()
        {

            Console.WriteLine("nbound Post # Command Serivce");
            return Ok("Inbound Test From plateform Command Controllers");
        }

    }
}