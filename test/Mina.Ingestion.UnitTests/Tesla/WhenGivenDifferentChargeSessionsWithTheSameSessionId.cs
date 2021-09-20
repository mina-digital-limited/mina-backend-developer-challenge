using Mina.Ingestion.Tesla;
using Xunit;

namespace Mina.Ingestion.UnitTests.Tesla
{
    [Collection(Collection.TeslaChargeSessionIngestionService)]
    public class WhenGivenDifferentChargeSessionsWithTheSameSessionId
    {
        private readonly TeslaChargeSessionIngestionService _sut;

        public WhenGivenDifferentChargeSessionsWithTheSameSessionId(TeslaChargeSessionIngestionServiceTestFixture fixture)
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
                    SessionId = "abc63ce7-b9fe-44de-a945-5296dd07dc81",
                    Description = "Private charge for 34F555D2",
                    StartTime = "8/17/2021,00:30",
                    EndTime = "8/17/2021,04:30",
                    ConsumptionWh = "28000",
                },
                new TeslaChargeSession
                {
                    SessionId = "abc63ce7-b9fe-44de-a945-5296dd07dc81",
                    Description = "Private charge for 34F555D2",
                    StartTime = "8/18/2021,00:30",
                    EndTime = "8/18/2021,04:30",
                    ConsumptionWh = "28000",
                },
            };

            Assert.Throws<DuplicateChargeSessionException>(() => _sut.Ingest(input));
        }
    }
}
