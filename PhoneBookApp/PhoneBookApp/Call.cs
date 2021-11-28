using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBookApp
{
    public class Call
    {
        public DateTime timeOfCall;
        public string status;

        public Call(DateTime callTimeOfCall, string callStatus)
        {
            timeOfCall = callTimeOfCall;
            status = callStatus;
        }
    }
}
