using Xunit;

namespace Mina.Ingestion.UnitTests.Tesla
{
    [CollectionDefinition(Collection.TeslaChargeSessionIngestionService)]
    public class TeslaChargeSessionIngestionServiceCollection : ICollectionFixture<TeslaChargeSessionIngestionServiceTestFixture>
    {
    }
}
