using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using SharedClasses;

namespace WcfServiceReverse
{    
    [ServiceContract]
    public interface IWebSocketService
    {
        [OperationContract]
        string ReverseCommunication(string communication);

        [OperationContract]
        ThermoTemps GetTemperatures(int? fan = null);
    }
   
}
