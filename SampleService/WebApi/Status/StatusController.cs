using System.Web.Http;
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
    }
}