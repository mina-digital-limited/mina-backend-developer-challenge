using System;

namespace Mina.Ingestion
{
    public class DuplicateChargeSessionException : Exception
    {
        public DuplicateChargeSessionException() : base("Duplicate charge sessions were detected")
        {

        }
    }
}
