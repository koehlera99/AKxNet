using System;

namespace TCS.Net
{
    class TCSServicePrime : ITCSServicePrime
    {
        Guid ITCSServicePrime.GetNewID()
        {
            return Guid.NewGuid();
        }
    }
}
