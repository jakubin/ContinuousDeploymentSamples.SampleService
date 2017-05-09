using System.Configuration;
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
    }
}