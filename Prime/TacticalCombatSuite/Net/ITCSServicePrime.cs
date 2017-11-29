using System;
using System.ServiceModel;

namespace TCS.Net
{
    interface ITCSServicePrime
    {
        [OperationContract]
        Guid GetNewID();
    }
}
