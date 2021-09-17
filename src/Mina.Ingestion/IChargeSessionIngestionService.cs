using System.Collections.Generic;

namespace Mina.Ingestion
{
    public interface IChargeSessionIngestionService<in T>
    {
        IReadOnlyList<NormalizedChargeSession> Ingest(IEnumerable<T> chargeSessions);
    }
}
