using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.NET_Core_Demo.Controllers
{
    //This is Attribute Based Routing

    //[Route("about")] this was hard codes the route see below to make more flexible
    [Route("[controller]/[action]")]
    public class AboutController
    {

        public string Phone()
        {
            return "(555)555-5555";
        }

        public string Address()
        {
            return "USA";
        }
    }
}
