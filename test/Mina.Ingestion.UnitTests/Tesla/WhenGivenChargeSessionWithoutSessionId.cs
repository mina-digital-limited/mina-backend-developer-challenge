using Mina.Ingestion.Tesla;
using Xunit;

namespace Mina.Ingestion.UnitTests.Tesla
{
    [Collection(Collection.TeslaChargeSessionIngestionService)]
    public class WhenGivenChargeSessionWithoutSessionId
    {
        private readonly NormalizedChargeSession _actual;

        public WhenGivenChargeSessionWithoutSessionId(TeslaChargeSessionIngestionServiceTestFixture fixture)
        {
            var input = new[]
            {
                new TeslaChargeSession
                {
                    SessionId = "",
                    Description = "Private charge for 34F555D2",
                    StartTime = "8/17/2021,16:32",
                    EndTime = "8/17/2021,20:56",
                    ConsumptionWh = "31543.21",
                },
            };
            _actual = fixture.Sut.Ingest(input)[0];
        }

        [Fact]
        public void ShouldHaveANullExternalId()
        {
            Assert.Null(_actual.ExternalId);
        }
    }
}
