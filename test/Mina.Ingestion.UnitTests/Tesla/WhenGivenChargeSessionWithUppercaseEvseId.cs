using Mina.Ingestion.Tesla;
using Xunit;

namespace Mina.Ingestion.UnitTests.Tesla
{
    [Collection(Collection.TeslaChargeSessionIngestionService)]
    public class WhenGivenChargeSessionWithUppercaseEvseId
    {
        private readonly NormalizedChargeSession _actual;

        public WhenGivenChargeSessionWithUppercaseEvseId(TeslaChargeSessionIngestionServiceTestFixture fixture)
        {
            var input = new[]
            {
                new TeslaChargeSession
                {
                    SessionId = "abc63ce7-b9fe-44de-a945-5296dd07dc81",
                    Description = "Private charge for 34F555D2",
                    StartTime = "8/17/2021,16:32",
                    EndTime = "8/17/2021,20:56",
                    ConsumptionWh = "31543.21",
                },
            };
            _actual = fixture.Sut.Ingest(input)[0];
        }

        [Fact]
        public void ShouldHaveAnUppercaseEvseId()
        {
            var expected = "34F555D2";
            Assert.Equal(expected, _actual.EvseId);
        }
    }
}
