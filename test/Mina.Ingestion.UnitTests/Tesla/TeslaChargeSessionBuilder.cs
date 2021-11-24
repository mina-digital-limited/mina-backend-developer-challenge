using System;
using System.Linq;
using Mina.Ingestion.Tesla;

namespace Mina.Ingestion.UnitTests.Tesla
{
    public class TeslaChargeSessionBuilder
    {
        private static Random s_random;
        private readonly TeslaChargeSession _teslaChargeSession;

        static TeslaChargeSessionBuilder()
        {
            s_random = new Random();
        }

        public TeslaChargeSessionBuilder()
        {
            _teslaChargeSession = new TeslaChargeSession();
        }

        public TeslaChargeSessionBuilder WithConsumptionWh(string? consumptionWh)
        {
            _teslaChargeSession.ConsumptionWh = consumptionWh;

            return this;
        }

        public TeslaChargeSessionBuilder WithDescription(string? description)
        {
            _teslaChargeSession.Description = description;

            return this;
        }

        public TeslaChargeSessionBuilder WithEndTime(string? endTime)
        {
            _teslaChargeSession.EndTime = endTime;

            return this;
        }

        public TeslaChargeSessionBuilder WithSessionId(string? sessionId)
        {
            _teslaChargeSession.SessionId = sessionId;

            return this;
        }

        public TeslaChargeSessionBuilder WithStartTime(string? startTime)
        {
            _teslaChargeSession.StartTime = startTime;

            return this;
        }

        public TeslaChargeSessionBuilder WithTestValues()
        {
            static string RandomString(int length)
            {
                const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
                return new string(Enumerable.Repeat(chars, length)
                    .Select(s => s[s_random.Next(s.Length)]).ToArray());
            }

            _teslaChargeSession.SessionId = Guid.NewGuid().ToString();
            _teslaChargeSession.Description = $"Private charge for {RandomString(8)}";
            _teslaChargeSession.StartTime = DateTime.UtcNow.AddHours(-1).ToString("yyyy-MM-dd HH:mm:ss");
            _teslaChargeSession.EndTime = DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss");
            _teslaChargeSession.ConsumptionWh = ((s_random.NextDouble() * 3.5) + 3.5).ToString();

            return this;
        }

        public TeslaChargeSession Build()
        {
            return _teslaChargeSession;
        }
    }
}
