using System.Configuration;
using System.Web.Http;
using SampleService.DataAccess;

namespace SampleService.WebApi.Testing
{
    [RoutePrefix("api/testing")]
    public class TestingController : ApiController
    {
        private bool EnableTestingApi => ConfigurationManager.AppSettings[nameof(EnableTestingApi)] == "true";

        [Route("")]
        [HttpDelete]
        public IHttpActionResult Delete()
        {
            if (!EnableTestingApi)
            {
                return NotFound();
            }

            using (var db = new SampleServiceEntities())
            {
                db.Database.ExecuteSqlCommand("DELETE FROM dbo.Notes;");
            }

            return Ok();
        }
    }
}