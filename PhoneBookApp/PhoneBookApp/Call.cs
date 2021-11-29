using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBookApp
{
    public class Call
    {
        public enum Status
        {
            Missed = 1,
            InProgress = 2,
            Ended = 3,
        };

        private DateTime timeOfCall;
        private Status callstatus;

        public DateTime TimeOfCall { get => timeOfCall; set => timeOfCall = value; }
        public Status CallStatus { get => callstatus; set => callstatus = value; }

        public Call(DateTime _timeOfCall, int _callStatus)
        {
            TimeOfCall = _timeOfCall;

            switch (_callStatus)
            {
                case 1:
                    CallStatus = Status.Missed;
                    break;
                case 2:
                    CallStatus = Status.InProgress;
                    break;
                case 3:
                    CallStatus = Status.Ended;
                    break;
            }
        }
    }
}
