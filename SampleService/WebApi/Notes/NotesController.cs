using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using AutoMapper;
using SampleService.DataAccess;
using SampleService.Logic.Notes;

namespace SampleService.WebApi.Notes
{
    [RoutePrefix("api/notes")]
    public class NotesController : ApiController
    {
        private readonly INotesLogic _notesLogic;

        public NotesController()
            : this(new NotesLogic())
        {
        }

        public NotesController(INotesLogic notesLogic)
        {
            _notesLogic = notesLogic;
        }

        [Route("{id:int}")]
        [HttpGet]
        public IHttpActionResult GetById(int id)
        {
            var note = _notesLogic.GetById(id);
            if (note == null)
            {
                return NotFound();
            }

            return Ok(Mapper.Map<NoteModel>(note));
        }

        [Route("{id:int}")]
        [HttpDelete]
        public IHttpActionResult DeleteById(int id)
        {
            var deleted = _notesLogic.Delete(id);
            if (!deleted)
            {
                return NotFound();
            }

            return Ok();
        }

        [Route("")]
        [HttpPost]
        public IHttpActionResult Add(NoteModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var note = Mapper.Map<Note>(model);
            var id = _notesLogic.Add(note);
            return Ok(id);
        }

        public static void SetupMapper(IMapperConfigurationExpression cfg)
        {
            cfg.CreateMap<Note, NoteModel>();
            cfg.CreateMap<NoteModel, Note>();
        }
    }
}