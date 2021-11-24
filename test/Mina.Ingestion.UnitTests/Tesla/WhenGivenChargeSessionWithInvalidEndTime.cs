using System;
using Mina.Ingestion.Tesla;
using Xunit;

namespace Mina.Ingestion.UnitTests.Tesla
{
    [Collection(Collection.TeslaChargeSessionIngestionService)]
    public class WhenGivenChargeSessionWithInvalidEndTime
    {
        private readonly TeslaChargeSessionIngestionService _sut;

        public WhenGivenChargeSessionWithInvalidEndTime(TeslaChargeSessionIngestionServiceTestFixture fixture)
        {
            _sut = fixture.Sut;
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData("\n")]
        public void ShouldThrow(string? endTime)
        {
            var input = new[]
            {
                new TeslaChargeSessionBuilder()
                    .WithTestValues()
                    .WithEndTime(endTime)
                    .Build()
            };

            var exception = Record.Exception(() => _sut.Ingest(input));

            Assert.NotNull(exception);
            Assert.IsAssignableFrom<ArgumentException>(exception);
        }
    }
}
