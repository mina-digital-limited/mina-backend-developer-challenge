using Mina.Ingestion.Tesla;
using Xunit;

namespace Mina.Ingestion.UnitTests.Tesla
{
    [Collection(Collection.TeslaChargeSessionIngestionService)]
    public class WhenGivenOverlappingChargeSessionsWithSameCaseEvseIds
    {
        private readonly TeslaChargeSessionIngestionService _sut;

        public WhenGivenOverlappingChargeSessionsWithSameCaseEvseIds(TeslaChargeSessionIngestionServiceTestFixture fixture)
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
                    .WithDescription("Private charge for 34F555D2")
                    .WithStartTime("2000-01-01 12:00:00")
                    .WithStartTime("2000-01-01 18:00:00")
                    .Build(),
                new TeslaChargeSessionBuilder()
                    .WithTestValues()
                    .WithDescription("Private charge for 34F555D2")
                    .WithStartTime("2000-01-01 15:00:00")
                    .WithStartTime("2000-01-01 21:00:00")
                    .Build()
            };

            var exception = Record.Exception(() => _sut.Ingest(input));

            Assert.NotNull(exception);
            Assert.IsAssignableFrom<OverlappingChargeSessionException>(exception);
        }
    }
}
