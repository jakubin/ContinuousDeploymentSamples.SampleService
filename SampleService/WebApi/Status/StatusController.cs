using System.Configuration;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using System.Web.Http.Results;
using SampleService.Logic.Notes;

namespace SampleService.WebApi.Status
{
    [RoutePrefix("api/status")]
    public class StatusController : ApiController
    {
        private readonly INotesLogic _notesLogic;

        public StatusController()
            : this(new NotesLogic())
        {
        }

        public StatusController(INotesLogic notesLogic)
        {
            _notesLogic = notesLogic;
        }

        [HttpGet]
        [Route("")]
        public IHttpActionResult Get()
        {
            bool success = _notesLogic.CheckStatus();
            if (!success)
            {
                return InternalServerError();
            }

            return Ok("All good");
        }

        [HttpGet]
        [Route("version")]
        public IHttpActionResult GetVersion()
        {
            var version = ConfigurationManager.AppSettings["Version"];
            return new ResponseMessageResult(new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(version, Encoding.UTF8)
            });
        }
    }
}