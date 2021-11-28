using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBookApp
{
    public class Contact
    {
        public string name;
        public string phoneNumber;
        public string preference;

        public Contact(string contactName, string contactPhoneNumber, string contactPreference)
        {
            name = contactName;
            phoneNumber = contactPhoneNumber;
            preference = contactPreference;
        }
    }
}
