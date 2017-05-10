using System.Configuration;
using Shouldly;
using Xunit;

namespace DeployTests
{
    public class DeploymentTests
    {
        private StatusClient _client;

        public DeploymentTests()
        {
            _client = new StatusClient(ConfigurationManager.AppSettings["ServiceUrl"]);
        }

        [Fact]
        public void CheckStatus()
        {
            _client.CheckStatus();
        }

        [Fact]
        public void HasRightVersion()
        {
            var expected = ConfigurationManager.AppSettings["Version"];

            var actual = _client.GetVersion();
            
            actual.ShouldBe(expected);
        }
    }
}