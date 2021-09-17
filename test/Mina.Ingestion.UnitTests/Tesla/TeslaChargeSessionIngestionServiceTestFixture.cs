using Mina.Ingestion.Tesla;

namespace Mina.Ingestion.UnitTests.Tesla
{
    public sealed class TeslaChargeSessionIngestionServiceTestFixture
    {
        public TeslaChargeSessionIngestionServiceTestFixture()
        {
            Sut = new TeslaChargeSessionIngestionService();
        }

        public TeslaChargeSessionIngestionService Sut { get; }
    }
}
