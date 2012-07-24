using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfCommunicationController
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "TextService" in both code and config file together.
    public class TextService : ITextService
    {
        public string ReverseCommunication(string communication)
        {
            return communication.Aggregate("", (acc, c) => c + acc);

            //string reverseValue = new string(communication.Select((c, index) => new { c, index })
            //                             .OrderByDescending(x => x.index)
            //                             .ToArray());

            //return reverseValue;
        }
    }
}
