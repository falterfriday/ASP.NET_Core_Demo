using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreDemo.Controllers
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
