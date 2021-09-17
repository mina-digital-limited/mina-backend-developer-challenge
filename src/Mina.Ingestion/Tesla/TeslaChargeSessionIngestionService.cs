using System;
using System.Collections.Generic;
using System.Linq;

namespace Mina.Ingestion.Tesla
{
    public class TeslaChargeSessionIngestionService : IChargeSessionIngestionService<TeslaChargeSession>
    {
        public IReadOnlyList<NormalizedChargeSession> Ingest(IEnumerable<TeslaChargeSession> chargeSessions)
        {
            throw new NotImplementedException();
        }
    }
}
