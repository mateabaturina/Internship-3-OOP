using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBookApp
{
    public class Contact
    {
        public enum Preference
        {
            Favorite = 1,
            Normal = 2,
            Blocked = 3,
        };

        private string name;
        private string phoneNumber;
        private Preference preference;

        public string Name { get => name; set => name = value; }
        public string PhoneNumber { get => phoneNumber; set => phoneNumber = value; }
        public Preference PreferenceValue { get => preference; set => preference = value; }

        public Contact(string _name, string _phoneNumber)
        {
            Name = _name;
            PhoneNumber = _phoneNumber;
            PreferenceValue = Preference.Normal;
        }
        public Contact(string _name, string _phoneNumber, int _preference)
        {
            Name = _name;
            PhoneNumber = _phoneNumber;

            switch (_preference)
            {
                case 1:
                    PreferenceValue = Preference.Favorite;
                    break;
                case 2:
                    PreferenceValue = Preference.Normal;
                    break;
                case 3:
                    PreferenceValue = Preference.Blocked;
                    break;
            }

        }
    }
}
