namespace Mina.Ingestion.Tesla
{
    public class TeslaChargeSession
    {
        public string? SessionId { get; set; }
        public string? Description { get; set; }
        public string? StartTime { get; set; }
        public string? EndTime { get; set; }
        public string? ConsumptionWh { get; set; }
    }
}
