using System;
using System.Collections.Generic;
using Mina.Ingestion.Tesla;
using Xunit;

namespace Mina.Ingestion.UnitTests.Tesla
{
    [Collection(Collection.TeslaChargeSessionIngestionService)]
    public class WhenGivenChargeSessionWithValidConsumptionWh
    {
        private TeslaChargeSessionIngestionService _sut;

        public WhenGivenChargeSessionWithValidConsumptionWh(TeslaChargeSessionIngestionServiceTestFixture fixture)
        {
            _sut = fixture.Sut;
        }

        [Theory]
        [InlineData("0", 0)]
        [InlineData("1", 0.001)]
        [InlineData("-1", -0.001)]
        [InlineData("31543.21", 31.54321)]
        public void ShouldHaveKWhImported(string? consumptionWh, double expected)
        {
            var input = new[]
            {
                new TeslaChargeSessionBuilder()
                    .WithTestValues()
                    .WithConsumptionWh(consumptionWh)
                    .Build()
            };
            var actual = _sut.Ingest(input)[0].KWhImported;

            Assert.Equal(expected, actual);
        }
    }
}
