using System;
using Mina.Ingestion.Tesla;
using Xunit;

namespace Mina.Ingestion.UnitTests.Tesla
{
    [Collection(Collection.TeslaChargeSessionIngestionService)]
    public class WhenGivenChargeSessionsWithEndTimeBeforeStartTime
    {
        private readonly TeslaChargeSessionIngestionService _sut;

        public WhenGivenChargeSessionsWithEndTimeBeforeStartTime(TeslaChargeSessionIngestionServiceTestFixture fixture)
        {
            _sut = fixture.Sut;
        }

        [Fact]
        public void ShouldThrow()
        {
            var input = new[]
            {
                new TeslaChargeSessionBuilder()
                    .WithTestValues()
                    .WithStartTime("2000-01-01 12:00:00")
                    .WithEndTime("2000-01-01 11:59:59")
                    .Build()
            };

            var exception = Record.Exception(() => _sut.Ingest(input));

            Assert.NotNull(exception);
            Assert.IsAssignableFrom<ArgumentException>(exception);
        }
    }
}
