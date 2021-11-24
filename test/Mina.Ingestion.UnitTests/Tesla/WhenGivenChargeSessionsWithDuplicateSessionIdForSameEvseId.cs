using Mina.Ingestion.Tesla;
using Xunit;

namespace Mina.Ingestion.UnitTests.Tesla
{
    [Collection(Collection.TeslaChargeSessionIngestionService)]
    public class WhenGivenChargeSessionsWithDuplicateSessionIdForSameEvseId
    {
        private readonly TeslaChargeSessionIngestionService _sut;

        public WhenGivenChargeSessionsWithDuplicateSessionIdForSameEvseId(TeslaChargeSessionIngestionServiceTestFixture fixture)
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
                    .WithSessionId("abc63ce7-b9fe-44de-a945-5296dd07dc81")
                    .WithDescription("Private charge for 34F555D2")
                    .Build(),
                new TeslaChargeSessionBuilder()
                    .WithTestValues()
                    .WithSessionId("abc63ce7-b9fe-44de-a945-5296dd07dc81")
                    .WithDescription("Private charge for 34F555D2")
                    .Build()
            };

            var exception = Record.Exception(() => _sut.Ingest(input));

            Assert.NotNull(exception);
            Assert.IsAssignableFrom<DuplicateChargeSessionException>(exception);
        }
    }
}
