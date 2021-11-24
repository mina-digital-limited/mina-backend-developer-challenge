using System;
using Mina.Ingestion.Tesla;
using Xunit;

namespace Mina.Ingestion.UnitTests.Tesla
{
    [Collection(Collection.TeslaChargeSessionIngestionService)]
    public class WhenGivenChargeSessionWithInvalidStartTime
    {
        private readonly TeslaChargeSessionIngestionService _sut;

        public WhenGivenChargeSessionWithInvalidStartTime(TeslaChargeSessionIngestionServiceTestFixture fixture)
        {
            _sut = fixture.Sut;
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData("\n")]
        public void ShouldThrow(string? startTime)
        {
            var input = new[]
            {
                new TeslaChargeSessionBuilder()
                    .WithTestValues()
                    .WithStartTime(startTime)
                    .Build()
            };

            var exception = Record.Exception(() => _sut.Ingest(input));

            Assert.NotNull(exception);
            Assert.IsAssignableFrom<ArgumentException>(exception);
        }
    }
}
