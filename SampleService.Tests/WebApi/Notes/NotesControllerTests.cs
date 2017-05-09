using System.Web.Http.Results;
using AutoMapper;
using NSubstitute;
using SampleService.DataAccess;
using SampleService.Logic.Notes;
using SampleService.WebApi.Notes;
using Shouldly;
using Xunit;

namespace SampleService.Tests.WebApi.Notes
{
    public class NotesControllerTests
    {
        private INotesLogic _notesLogic;

        private NotesController _controller;

        public NotesControllerTests()
        {
            _notesLogic = Substitute.For<INotesLogic>();

            _controller = new NotesController(_notesLogic);
            Mapper.Initialize(NotesController.SetupMapper);
        }

        [Fact]
        public void GetById_Found()
        {
            var note = new Note {Id = 1, Content = "Note1"};
            _notesLogic.GetById(1).Returns(note);

            var actual = _controller.GetById(1);

            var actualNote = actual.ShouldBeOfType<OkNegotiatedContentResult<NoteModel>>().Content;
            actualNote.Id.ShouldBe(1);
            actualNote.Content.ShouldBe("Note1");
        }

        [Fact]
        public void GetById_NotFound()
        {
            _notesLogic.GetById(1).Returns((Note)null);

            var actual = _controller.GetById(1);

            actual.ShouldBeOfType<NotFoundResult>();
        }
    }
}