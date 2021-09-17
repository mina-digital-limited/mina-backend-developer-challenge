using Mina.Ingestion.Tesla;
using Xunit;

namespace Mina.Ingestion.UnitTests.Tesla
{
    [Collection(Collection.TeslaChargeSessionIngestionService)]
    public class WhenGivenDifferentChargeSessionsWithOverlappingTimes
    {
        private readonly TeslaChargeSessionIngestionService _sut;

        public WhenGivenDifferentChargeSessionsWithOverlappingTimes(TeslaChargeSessionIngestionServiceTestFixture fixture)
        {
            _sut = fixture.Sut;
        }

        [Fact]
        public void ShouldThrowDuplicateChargeException()
        {
            var input = new[]
            {
                new TeslaChargeSession
                {
                    SessionId = "",
                    Description = "Private charge for 34F555D2",
                    StartTime = "2021-08-17T00:30:00Z",
                    EndTime = "2021-08-17T04:30:00Z",
                    ConsumptionWh = "28000",
                },
                new TeslaChargeSession
                {
                    SessionId = "",
                    Description = "Private charge for 34F555D2",
                    StartTime = "2021-08-17T04:00:00Z",
                    EndTime = "2021-08-17T08:30:00Z",
                    ConsumptionWh = "28000",
                }
            };

            Assert.Throws<OverlappingChargeSessionException>(() => _sut.Ingest(input));
        }
    }
}
