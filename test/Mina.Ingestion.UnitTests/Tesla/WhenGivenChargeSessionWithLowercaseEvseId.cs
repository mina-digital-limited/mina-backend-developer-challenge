using System.Linq;
using Mina.Ingestion.Tesla;
using Xunit;

namespace Mina.Ingestion.UnitTests.Tesla
{
    [Collection(Collection.TeslaChargeSessionIngestionService)]
    public class WhenGivenChargeSessionWithLowercaseEvseId
    {
        private readonly NormalizedChargeSession _actual;

        public WhenGivenChargeSessionWithLowercaseEvseId(TeslaChargeSessionIngestionServiceTestFixture fixture)
        {
            var input = new[]
            {
                new TeslaChargeSession
                {
                    SessionId = "abc63ce7-b9fe-44de-a945-5296dd07dc81",
                    Description = "Private charge for 34f555d2",
                    StartTime = "2021-08-17T16:32:41Z",
                    EndTime = "2021-08-17T20:56:04Z",
                    ConsumptionWh = "31543.21",
                },
            };
            _actual = fixture.Sut.Ingest(input).First();
        }

        [Fact]
        public void ShouldHaveALowercaseEvseId()
        {
            var expected = "34f555d2";
            Assert.Equal(expected, _actual.EvseId);
        }
    }
}
