using System;
using Mina.Ingestion.Tesla;
using Xunit;

namespace Mina.Ingestion.UnitTests.Tesla
{
    [Collection(Collection.TeslaChargeSessionIngestionService)]
    public class WhenGivenValidChargeSession
    {
        private readonly NormalizedChargeSession _actual;

        public WhenGivenValidChargeSession(TeslaChargeSessionIngestionServiceTestFixture fixture)
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
        public void ShouldHaveAnExternalId()
        {
            var expected = "abc63ce7-b9fe-44de-a945-5296dd07dc81";
            Assert.Equal(expected, _actual.ExternalId);
        }

        [Fact]
        public void ShouldHaveAnEvseId()
        {
            var expected = "34F555D2";
            Assert.Equal(expected, _actual.EvseId);
        }

        [Fact]
        public void ShouldHaveAPlugInTimestamp()
        {
            var expected = new DateTimeOffset(2021, 08, 17, 16, 32, 00, TimeSpan.Zero);
            Assert.Equal(expected, _actual.PlugInTimestamp);
        }

        [Fact]
        public void ShouldHaveAPlugOutTimestamp()
        {
            var expected = new DateTimeOffset(2021, 08, 17, 20, 56, 00, TimeSpan.Zero);
            Assert.Equal(expected, _actual.PlugOutTimestamp);
        }

        [Fact]
        public void ShouldHaveKWhImported()
        {
            var expected = 31.54321D;
            Assert.Equal(expected, _actual.KWhImported);
        }
    }
}
