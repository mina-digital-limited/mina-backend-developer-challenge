using System;
using System.Collections.Generic;
using Mina.Ingestion.Tesla;
using Xunit;

namespace Mina.Ingestion.UnitTests.Tesla
{
    [Collection(Collection.TeslaChargeSessionIngestionService)]
    public class WhenGivenNoChargeSessions
    {
        private readonly IReadOnlyList<NormalizedChargeSession> _actual;

        public WhenGivenNoChargeSessions(TeslaChargeSessionIngestionServiceTestFixture fixture)
        {
            var input = Array.Empty<TeslaChargeSession>();
            _actual = fixture.Sut.Ingest(input);
        }

        [Fact]
        public void ShouldIngestCorrectNumberOfChargeSessions()
        {
            Assert.Equal(0, _actual.Count);
        }
    }
}
