using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfCommunicationController
{    
    [ServiceContract]
    public interface ITextService
    {
        [OperationContract]
        string ReverseCommunication(string communication);
    }
}
