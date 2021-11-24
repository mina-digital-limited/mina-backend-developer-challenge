using System;
using Mina.Ingestion.Tesla;
using Xunit;

namespace Mina.Ingestion.UnitTests.Tesla
{
    [Collection(Collection.TeslaChargeSessionIngestionService)]
    public class WhenGivenChargeSessionWithInvalidConsumptionWh
    {
        private readonly TeslaChargeSessionIngestionService _sut;

        public WhenGivenChargeSessionWithInvalidConsumptionWh(TeslaChargeSessionIngestionServiceTestFixture fixture)
        {
            _sut = fixture.Sut;
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData("\n")]
        [InlineData("abc63ce7-b9fe-44de-a945-5296dd07dc81")]
        public void ShouldThrow(string? consumptionWh)
        {
            var input = new[]
            {
                new TeslaChargeSessionBuilder()
                    .WithTestValues()
                    .WithConsumptionWh(consumptionWh)
                    .Build()
            };

            var exception = Record.Exception(() => _sut.Ingest(input));

            Assert.NotNull(exception);
            Assert.IsAssignableFrom<ArgumentException>(exception);
        }
    }
}
