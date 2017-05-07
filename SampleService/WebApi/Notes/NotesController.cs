using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using AutoMapper;
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

        private NotesController(INotesLogic notesLogic)
        {
            _notesLogic = notesLogic;
        }

        [Route("")]
        [HttpGet]
        public List<NoteModel> Get()
        {
            return _notesLogic.GetAll()
                .Select(Mapper.Map<NoteModel>)
                .ToList();
        }

        [Route("{id}")]
        [HttpGet]
        public NoteModel Get(int id)
        {
            return null;
        }
    }
}