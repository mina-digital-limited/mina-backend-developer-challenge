using Mina.Ingestion.Tesla;
using Xunit;

namespace Mina.Ingestion.UnitTests.Tesla
{
    [Collection(Collection.TeslaChargeSessionIngestionService)]
    public class WhenGivenChargeSessionWithValidSessionId
    {
        private TeslaChargeSessionIngestionService _sut;

        public WhenGivenChargeSessionWithValidSessionId(TeslaChargeSessionIngestionServiceTestFixture fixture)
        {
            _sut = fixture.Sut;
        }

        [Theory]
        [InlineData(null, null)]
        [InlineData("", null)]
        [InlineData(" ", null)]
        [InlineData("\n", null)]
        [InlineData("abc63ce7-b9fe-44de-a945-5296dd07dc81", "abc63ce7-b9fe-44de-a945-5296dd07dc81")]
        public void ShouldHaveExternalId(string? sessionId, string expected)
        {
            var input = new[]
            {
                new TeslaChargeSessionBuilder()
                    .WithTestValues()
                    .WithSessionId(sessionId)
                    .Build()
            };
            var actual = _sut.Ingest(input)[0].ExternalId;

            Assert.Equal(expected, actual);
        }
    }
}
