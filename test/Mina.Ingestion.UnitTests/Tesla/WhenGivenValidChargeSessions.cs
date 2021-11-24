using System;
using System.Collections.Generic;
using Xunit;

namespace Mina.Ingestion.UnitTests.Tesla
{
    [Collection(Collection.TeslaChargeSessionIngestionService)]
    public class WhenGivenValidChargeSessions
    {
        private readonly IReadOnlyList<NormalizedChargeSession> _actual;

        public WhenGivenValidChargeSessions(TeslaChargeSessionIngestionServiceTestFixture fixture)
        {
            var input = new[]
            {

                new TeslaChargeSessionBuilder()
                    .WithSessionId("abc63ce7-b9fe-44de-a945-5296dd07dc81")
                    .WithDescription("Private charge for 34F555D2")
                    .WithStartTime("2000-01-01 12:00:00")
                    .WithEndTime("2000-01-01 18:00:00")
                    .WithConsumptionWh("31543.21")
                    .Build(),
                new TeslaChargeSessionBuilder()
                    .WithSessionId("3c182da4-3ad3-4a8f-8396-0cfc16a93764")
                    .WithDescription("Private charge for 34F555D2")
                    .WithStartTime("2000-01-02 12:00:00")
                    .WithEndTime("2000-01-02 18:00:00")
                    .WithConsumptionWh("31543.21")
                    .Build(),
                new TeslaChargeSessionBuilder()
                    .WithTestValues()
                    .WithSessionId("60caef37-3b99-4781-a483-2953267ef042")
                    .WithDescription("Private charge for C267B22E")
                    .WithStartTime("2000-01-03 12:00:00")
                    .WithEndTime("2000-01-03 18:00:00")
                    .WithConsumptionWh("31543.21")
                    .Build()
            };
            _actual = fixture.Sut.Ingest(input);
        }

        [Fact]
        public void ShouldHaveAllChargeSessions()
        {
            Assert.Equal(3, _actual.Count);
        }

        [Fact]
        public void ShouldHaveExternalId()
        {
            Assert.Equal("abc63ce7-b9fe-44de-a945-5296dd07dc81", _actual[0].ExternalId);
            Assert.Equal("3c182da4-3ad3-4a8f-8396-0cfc16a93764", _actual[1].ExternalId);
            Assert.Equal("60caef37-3b99-4781-a483-2953267ef042", _actual[2].ExternalId);
        }

        [Fact]
        public void ShouldHaveEvseId()
        {
            Assert.Equal("34F555D2", _actual[0].EvseId);
            Assert.Equal("34F555D2", _actual[1].EvseId);
            Assert.Equal("C267B22E", _actual[2].EvseId);
        }

        [Fact]
        public void ShouldHavePlugInTimestamp()
        {
            Assert.Equal(new DateTimeOffset(2000, 01, 01, 12, 00, 00, TimeSpan.Zero), _actual[0].PlugInTimestamp);
            Assert.Equal(new DateTimeOffset(2000, 01, 02, 12, 00, 00, TimeSpan.Zero), _actual[1].PlugInTimestamp);
            Assert.Equal(new DateTimeOffset(2000, 01, 03, 12, 00, 00, TimeSpan.Zero), _actual[2].PlugInTimestamp);
        }

        [Fact]
        public void ShouldHavePlugOutTimestamp()
        {
            Assert.Equal(new DateTimeOffset(2000, 01, 01, 18, 00, 00, TimeSpan.Zero), _actual[0].PlugOutTimestamp);
            Assert.Equal(new DateTimeOffset(2000, 01, 02, 18, 00, 00, TimeSpan.Zero), _actual[1].PlugOutTimestamp);
            Assert.Equal(new DateTimeOffset(2000, 01, 03, 18, 00, 00, TimeSpan.Zero), _actual[2].PlugOutTimestamp);
        }

        [Fact]
        public void ShouldHaveKWhImported()
        {
            Assert.Equal(31.54321D, _actual[0].KWhImported);
            Assert.Equal(31.54321D, _actual[1].KWhImported);
            Assert.Equal(31.54321D, _actual[2].KWhImported);
        }
    }
}
