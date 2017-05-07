using System.Web.Http;

namespace SampleService.Controllers
{
    [RoutePrefix("test")]
    public class TestController: ApiController
    {
        [Route("")]
        [HttpGet]
        public string Test()
        {
            return "Yay!";
        }
    }
}