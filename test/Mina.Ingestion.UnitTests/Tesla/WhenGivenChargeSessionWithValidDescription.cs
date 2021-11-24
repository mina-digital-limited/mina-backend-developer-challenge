using System;
using System.Collections.Generic;
using Mina.Ingestion.Tesla;
using Xunit;

namespace Mina.Ingestion.UnitTests.Tesla
{
    [Collection(Collection.TeslaChargeSessionIngestionService)]
    public class WhenGivenChargeSessionWithValidDescription
    {
        private TeslaChargeSessionIngestionService _sut;

        public WhenGivenChargeSessionWithValidDescription(TeslaChargeSessionIngestionServiceTestFixture fixture)
        {
            _sut = fixture.Sut;
        }

        [Theory]
        [InlineData("Private charge for 34F555D2")]
        [InlineData("Private charge for 34f555d2")]
        public void ShouldHaveEvseId(string? description)
        {
            var input = new[]
            {
                new TeslaChargeSessionBuilder()
                    .WithTestValues()
                    .WithDescription(description)
                    .Build()
            };
            var actual = _sut.Ingest(input)[0].EvseId;

            var expected = "34F555D2";
            Assert.Equal(expected, actual, ignoreCase: true);
        }
    }
}
