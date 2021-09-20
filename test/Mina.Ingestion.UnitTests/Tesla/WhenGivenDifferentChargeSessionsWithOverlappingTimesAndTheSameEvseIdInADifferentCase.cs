using Mina.Ingestion.Tesla;
using Xunit;

namespace Mina.Ingestion.UnitTests.Tesla
{
    [Collection(Collection.TeslaChargeSessionIngestionService)]
    public class WhenGivenDifferentChargeSessionsWithOverlappingTimesAndTheSameEvseIdInADifferentCase
    {
        private readonly TeslaChargeSessionIngestionService _sut;

        public WhenGivenDifferentChargeSessionsWithOverlappingTimesAndTheSameEvseIdInADifferentCase(TeslaChargeSessionIngestionServiceTestFixture fixture)
        {
            _sut = fixture.Sut;
        }

        [Fact]
        public void ShouldSucceed()
        {
            var input = new[]
            {
                new TeslaChargeSession
                {
                    SessionId = "",
                    Description = "Private charge for 34F555D2",
                    StartTime = "8/17/2021,00:30",
                    EndTime = "8/17/2021,04:30",
                    ConsumptionWh = "28000",
                },
                new TeslaChargeSession
                {
                    SessionId = "",
                    Description = "Private charge for 34f555d2",
                    StartTime = "8/17/2021,04:00",
                    EndTime = "8/17/2021,08:30",
                    ConsumptionWh = "28000",
                }
            };

            Assert.Throws<OverlappingChargeSessionException>(() => _sut.Ingest(input));
        }
    }
}
