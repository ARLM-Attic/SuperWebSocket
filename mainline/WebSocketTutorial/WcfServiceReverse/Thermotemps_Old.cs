using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace WcfServiceReverse
{    
    [DataContract]
    public class ThermoTemps_Old
    {
        [DataMember]
        public int IceMaker { get; set; }

        [DataMember]
        public int Fridge { get; set; }

        [DataMember]
        public int Freezer { get; set; }

        [DataMember]
        public int Fan { get; set; }

        [DataMember]
        public int CoolingVent { get; set; }
    }
}
