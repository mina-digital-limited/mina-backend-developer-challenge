using System.Collections.Generic;
using Mina.Ingestion.Tesla;
using Xunit;

namespace Mina.Ingestion.UnitTests.Tesla
{
    [Collection(Collection.TeslaChargeSessionIngestionService)]
    public class WhenGivenEmptyList
    {
        private readonly IReadOnlyList<NormalizedChargeSession> _actual;

        public WhenGivenEmptyList(TeslaChargeSessionIngestionServiceTestFixture fixture)
        {
            var input = new TeslaChargeSession[0];
            _actual = fixture.Sut.Ingest(input);
        }

        [Fact]
        public void ShouldReturnEmptyList()
        {
            Assert.Empty(_actual);
        }
    }
}
