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
    public class WebSocketService : IWebSocketService
    {
        public string ReverseCommunication(string communication)
        {
            return communication.Aggregate("", (acc, c) => c + acc);
        }

        public ThermoTemps GetTemperatures(int? fan = null)
        {
            Random rnd = new Random();            
            ThermoTemps temperatures = new ThermoTemps();

            // determine if fan temp past in
            if (fan != null) temperatures.Fan = (int)fan;
            else temperatures.Fan = rnd.Next(-20, 20);

            temperatures.CoolingVent = rnd.Next(-20, 20);
            temperatures.Freezer = rnd.Next(-20, 20);
            temperatures.Fridge = rnd.Next(-20, 20);
            temperatures.IceMaker = rnd.Next(-20, 20);

            return temperatures;
        }      
    }
}
