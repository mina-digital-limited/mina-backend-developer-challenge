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
                    StartTime = "2021-08-17T00:30:00Z",
                    EndTime = "2021-08-17T04:30:00Z",
                    ConsumptionWh = "28000",
                },
                new TeslaChargeSession
                {
                    SessionId = "abc63ce7-b9fe-44de-a945-5296dd07dc81",
                    Description = "Private charge for 34F555D2",
                    StartTime = "2021-08-18T00:30:00Z",
                    EndTime = "2021-08-18T04:30:00Z",
                    ConsumptionWh = "28000",
                },
            };

            Assert.Throws<DuplicateChargeSessionException>(() => _sut.Ingest(input));
        }
    }
}
