using System;
using System.Collections.Generic;

namespace PhoneBookApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var phoneBook = new Dictionary<Contact, List<Call>>();
            phoneBook.Add(new Contact("Mate Matić", "099123456", "favorit"), new List<Call>());
            phoneBook.Add(new Contact("Ana Anić", "099456123", "normalan"), new List<Call>());
            phoneBook.Add(new Contact("Ena Enić", "098765432", "blokiran kontakt"), new List<Call>());
        }
    }
}
