using System;
using Mina.Ingestion.Tesla;
using Xunit;

namespace Mina.Ingestion.UnitTests.Tesla
{
    [Collection(Collection.TeslaChargeSessionIngestionService)]
    public class WhenGivenChargeSessionWithInvalidDescription
    {
        private readonly TeslaChargeSessionIngestionService _sut;

        public WhenGivenChargeSessionWithInvalidDescription(TeslaChargeSessionIngestionServiceTestFixture fixture)
        {
            _sut = fixture.Sut;
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData("\n")]
        [InlineData("34F555D2")]
        public void ShouldThrow(string? description)
        {
            var input = new[]
            {
                new TeslaChargeSessionBuilder()
                    .WithTestValues()
                    .WithDescription(description)
                    .Build()
            };

            var exception = Record.Exception(() => _sut.Ingest(input));

            Assert.NotNull(exception);
            Assert.IsAssignableFrom<ArgumentException>(exception);
        }
    }
}
