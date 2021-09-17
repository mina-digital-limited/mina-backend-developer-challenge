using System;

namespace Mina.Ingestion
{
    public class NormalizedChargeSession
    {
        public NormalizedChargeSession(
            string evseId,
            DateTimeOffset plugInTimestamp,
            DateTimeOffset plugOutTimestamp,
            double kWhImported,
            string? externalId = null
        )
        {
            Id = Guid.NewGuid();
            ExternalId = externalId;
            EvseId = evseId;
            PlugInTimestamp = plugInTimestamp;
            PlugOutTimestamp = plugOutTimestamp;
            KWhImported = kWhImported;
        }

        public Guid Id { get; }
        public string? ExternalId { get; }
        public string EvseId { get; }
        public DateTimeOffset PlugInTimestamp { get; }
        public DateTimeOffset PlugOutTimestamp { get; }
        public double KWhImported { get; }
    }
}
