using System.Collections.Generic;
using System.Linq;
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
        public void GetAll_ReturnsAll()
        {
            var notes = new List<Note>
            {
                new Note {Id = 1, Content = "Note1"},
                new Note {Id = 1, Content = "Note2"},
            };
            _notesLogic.GetAll().Returns(notes);

            var actual = _controller.GetAll();

            actual.Select(x => new {x.Id, x.Content})
                .ShouldBe(notes.Select(x => new {Id = (int?) x.Id, x.Content}));
        }

        [Fact]
        public void GetAll_ReturnsEmpty()
        {
            var notes = new List<Note>();
            _notesLogic.GetAll().Returns(notes);

            var actual = _controller.GetAll();

            actual.ShouldBeEmpty();
        }
    }
}