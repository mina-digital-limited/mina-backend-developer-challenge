using System;

namespace Mina.Ingestion
{
    public class OverlappingChargeSessionException : Exception
    {
        public OverlappingChargeSessionException() : base("Overlapping charge sessions were detected")
        {

        }
    }
}
