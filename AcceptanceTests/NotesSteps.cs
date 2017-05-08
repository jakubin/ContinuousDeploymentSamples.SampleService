using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using Shouldly;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace AcceptanceTests
{
    [Binding]
    public class NotesSteps
    {
        private readonly SampleServiceClient _client;

        private List<NoteModel> _notes;

        public NotesSteps()
        {
            _client = new SampleServiceClient(ConfigurationManager.AppSettings["ServiceUrl"]);
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            _client.Reset();
        }

        [When("I request list of notes")]
        public void WhenRequest()
        {
            _notes = _client.GetAllNotes();
        }

        [When("I add note \"(.*)\"")]
        public void WhenAddNote(string content)
        {
            var note = new NoteModel {Content = content};
            _client.AddNote(note);
        }

        [Then("I receive no notes")]
        public void ThenReceiveNoNotes()
        {
            _notes.ShouldBeEmpty();
        }

        [Then("I receive the following notes:")]
        public void ThenReceiveNotes(Table notes)
        {
            var expected = notes.CreateSet<NoteModel>();

            _notes.Select(x => x.Content)
                .ShouldBe(expected.Select(x => x.Content), ignoreOrder: true);
        }
    }
}