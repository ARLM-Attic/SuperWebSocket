using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace SharedClasses
{    
    //[Serializable]
    public class ThermoTemps
    {
        public int IceMaker { get; set; }
        public int Fridge { get; set; }
        public int Freezer { get; set; }
        public int Fan { get; set; }
        public int CoolingVent { get; set; }
    }
}
