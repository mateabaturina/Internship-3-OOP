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
            InProgress,
            Missed,
            Ended,
        };

        private DateTime timeOfCall;
        private Status callstatus;

        public DateTime TimeOfCall { get => timeOfCall; set => timeOfCall = value; }
        public Status CallStatus { get => callstatus; set => callstatus = value; }

        public Call()
        {
            TimeOfCall = DateTime.Now;

            Random randomInt = new Random(DateTime.Now.Millisecond);
            var _callstatus = randomInt.Next(0, 2);

            switch (_callstatus)
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
