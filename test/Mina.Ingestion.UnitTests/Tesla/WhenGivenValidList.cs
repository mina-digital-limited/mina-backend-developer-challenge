using System.Collections.Generic;
using Mina.Ingestion.Tesla;
using Xunit;

namespace Mina.Ingestion.UnitTests.Tesla
{
    [Collection(Collection.TeslaChargeSessionIngestionService)]
    public class WhenGivenValidList
    {
        private readonly IReadOnlyList<NormalizedChargeSession> _actual;

        public WhenGivenValidList(TeslaChargeSessionIngestionServiceTestFixture fixture)
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
                    SessionId = "75970505-3e99-48e9-92aa-d8738dfb1a8e",
                    Description = "Private charge for 34F555D2",
                    StartTime = "2021-08-18T00:30:00Z",
                    EndTime = "2021-08-18T04:30:00Z",
                    ConsumptionWh = "28000",
                },
                new TeslaChargeSession
                {
                    SessionId = "925ded6e-de71-4064-a6ea-e8d0977eb313",
                    Description = "Private charge for 34F555D2",
                    StartTime = "2021-08-19T00:30:00Z",
                    EndTime = "2021-08-19T04:30:00Z",
                    ConsumptionWh = "28000",
                },
            };
            _actual = fixture.Sut.Ingest(input);
        }

        [Fact]
        public void ShouldHaveCorrectNumberOfResults()
        {
            Assert.Equal(3, _actual.Count);
        }
    }
}
