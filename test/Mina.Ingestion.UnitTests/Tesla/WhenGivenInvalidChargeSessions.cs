using System;
using Mina.Ingestion.Tesla;
using Xunit;

namespace Mina.Ingestion.UnitTests.Tesla
{
    [Collection(Collection.TeslaChargeSessionIngestionService)]
    public class WhenGivenInvalidChargeSessions
    {
        private readonly TeslaChargeSessionIngestionService _sut;

        public WhenGivenInvalidChargeSessions(TeslaChargeSessionIngestionServiceTestFixture fixture)
        {
            _sut = fixture.Sut;
        }

        [Fact]
        public void ShouldRejectNullDescription()
        {
            var input = new[]
            {
                new TeslaChargeSession
                {
                    SessionId = "",
                    Description = null,
                    StartTime = "8/17/2021,00:30",
                    EndTime = "8/17/2021,04:30",
                    ConsumptionWh = "28000",
                },
            };

            Assert.Throws<ArgumentNullException>(() => _sut.Ingest(input));
        }

        [Fact]
        public void ShouldRejectEmptyDescription()
        {
            var input = new[]
            {
                new TeslaChargeSession
                {
                    SessionId = "",
                    Description = "   \n   ",
                    StartTime = "8/17/2021,00:30",
                    EndTime = "8/17/2021,04:30",
                    ConsumptionWh = "28000",
                },
            };

            Assert.Throws<ArgumentNullException>(() => _sut.Ingest(input));
        }

        [Fact]
        public void ShouldRejectNullStartTime()
        {
            var input = new[]
            {
                new TeslaChargeSession
                {
                    SessionId = "",
                    Description = "Private charge for 34F555D2",
                    StartTime = null,
                    EndTime = "8/17/2021,04:30",
                    ConsumptionWh = "28000",
                },
            };

            Assert.Throws<ArgumentNullException>(() => _sut.Ingest(input));
        }

        [Fact]
        public void ShouldRejectEmptyStartTime()
        {
            var input = new[]
            {
                new TeslaChargeSession
                {
                    SessionId = "",
                    Description = "Private charge for 34F555D2",
                    StartTime = "   \n   ",
                    EndTime = "8/17/2021,00:30",
                    ConsumptionWh = "28000",
                },
            };

            Assert.Throws<ArgumentNullException>(() => _sut.Ingest(input));
        }

        [Fact]
        public void ShouldRejectNullEndTime()
        {
            var input = new[]
            {
                new TeslaChargeSession
                {
                    SessionId = "",
                    Description = "Private charge for 34F555D2",
                    StartTime = "8/17/2021,00:30",
                    EndTime = null,
                    ConsumptionWh = "28000",
                },
            };

            Assert.Throws<ArgumentNullException>(() => _sut.Ingest(input));
        }

        [Fact]
        public void ShouldRejectEmptyEndTime()
        {
            var input = new[]
            {
                new TeslaChargeSession
                {
                    SessionId = "",
                    Description = "Private charge for 34F555D2",
                    StartTime = "8/17/2021,00:30",
                    EndTime = "   \n   ",
                    ConsumptionWh = "28000",
                },
            };

            Assert.Throws<ArgumentNullException>(() => _sut.Ingest(input));
        }

        [Fact]
        public void ShouldRejectNullConsumption()
        {
            var input = new[]
            {
                new TeslaChargeSession
                {
                    SessionId = "",
                    Description = "Private charge for 34F555D2",
                    StartTime = "8/17/2021,00:30",
                    EndTime = "8/17/2021,00:30",
                    ConsumptionWh = null,
                },
            };

            Assert.Throws<ArgumentNullException>(() => _sut.Ingest(input));
        }

        [Fact]
        public void ShouldRejectEmptyConsumption()
        {
            var input = new[]
            {
                new TeslaChargeSession
                {
                    SessionId = "",
                    Description = "Private charge for 34F555D2",
                    StartTime = "8/17/2021,00:30",
                    EndTime = "8/17/2021,00:30",
                    ConsumptionWh = "   \n   ",
                },
            };

            Assert.Throws<ArgumentNullException>(() => _sut.Ingest(input));
        }

        [Fact]
        public void ShouldRejectNonDecimalConsumption()
        {
            var input = new[]
            {
                new TeslaChargeSession
                {
                    SessionId = "",
                    Description = "Private charge for 34F555D2",
                    StartTime = "8/17/2021,00:30",
                    EndTime = "8/17/2021,00:30",
                    ConsumptionWh = "this is not a decimal",
                },
            };

            Assert.Throws<ArgumentException>(() => _sut.Ingest(input));
        }
    }
}
