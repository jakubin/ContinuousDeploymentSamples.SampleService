using System.Configuration;
using Shouldly;
using Xunit;

namespace DeployTests
{
    public class DeploymentTests
    {
        private SampleServiceClient _client;

        public DeploymentTests()
        {
            _client = new SampleServiceClient(ConfigurationManager.AppSettings["ServiceUrl"]);
        }

        [Fact]
        public void NotesApiWorks()
        {
            _client.GetAllNotes();
        }
    }
}