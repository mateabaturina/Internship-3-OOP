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

            bool showMenu = true;
            while (showMenu)
            {
                showMenu = MainMenu(phoneBook);
            }
        }

        private static void PrintMenu()
        {
            Console.Clear();
            Console.WriteLine("Odaberite akciju:");
            Console.WriteLine("1 - Ispis svih kontakata");
            Console.WriteLine("2 - Dodavanje novih kontakata u imenik");
            Console.WriteLine("3 - Brisanje kontakata iz imenika");
            Console.WriteLine("4 - Editiranje preference kontakta");
            Console.WriteLine("5 - Upravljanje kontaktom koje otvara podmenu sa sljedecim funkcionalnostima:");
            Console.WriteLine("6 - Ispis svih poziva");
            Console.WriteLine("7 - Izlaz iz aplikacije");
            Console.Write("\r\nUnesite odabir: ");
        }

        private static bool MainMenu(Dictionary<Contact, List<Call>> phoneBook)
        {
            PrintMenu();

            switch (Console.ReadLine())
            {
                case "1":
                    PrintAllContacts(phoneBook);
                    return true;
                case "2":
                    AddingNewContacts(phoneBook);
                    return true;
                case "3":
                    DeleteContacts(phoneBook);
                    return true;
                case "4":
                    EditingContactPreferences(phoneBook);
                    return true;
                /*case "5":
                    Submenu(phoneBook);
                    return true;
                case "6":
                    PrintAllCalls(phoneBook);
                    return true;*/
                case "7":
                    return false;
                default:
                    return true;
            }
        }

        private static void PrintAllContacts(Dictionary<Contact, List<Call>> phoneBook)
        {
            Console.Clear();
            Console.WriteLine("Popis kontakata:");

            foreach (var item in phoneBook.Keys)

                Console.WriteLine(item.name + " - " + item.phoneNumber + " - " + item.preference);

            Console.WriteLine("Pritisnite enter za povratak na izbornik...");
            Console.ReadLine();
        }

        private static string CheckingNameInput(string name)
        {
            while (string.IsNullOrEmpty(name))
            {
                Console.WriteLine("Ime i prezime ne moze biti prazno! Molim vas ponovo unesite.");
                Console.Write("\r\nUnesite ime i prezime: ");
                name = Console.ReadLine();
            }

            return name;
        }

        private static string CheckingIfNameExists(string name, Dictionary<Contact, List<Call>> phoneBook)
        {
            int count = 0;

            foreach (var item in phoneBook.Keys)
            {
                if (name == item.name)
                    count++;
            }

            if (count == 0)
            {
                Console.WriteLine("Kontakt s tim imenom i prezimenom ne postoji! Molim vas ponovo unesite.");
                Console.Write("\r\nUnesite ime i prezime: ");
                name = Console.ReadLine();
            }

            return name;
        }

        private static string CheckingPhoneNumberInput(string phoneNumber)
        {
            if (string.IsNullOrEmpty(phoneNumber))
            {
                Console.WriteLine("Broj telefona ne moze biti prazan! Molim vas ponovo unesite.");
                Console.Write("\r\nUnesite broj telefona: ");
                phoneNumber = Console.ReadLine();
            }

            return phoneNumber;
        }

        private static string CheckingIfPhoneNumberAlreadyExists(string phoneNumber, Dictionary<Contact, List<Call>> phoneBook)
        {
            foreach (var item in phoneBook.Keys)
            {
                while (phoneNumber == item.phoneNumber)
                {
                    Console.WriteLine("Kontakt s tim brojem već postoji! Molim vas ponovo unesite.");
                    Console.Write("\r\nUnesite broj telefona: ");
                    phoneNumber = Console.ReadLine();
                }
            }

            return phoneNumber;
        }

        private static string CheckingPreferenceInput(string preference)
        {
            while (string.IsNullOrEmpty(preference) | preference != "favorit" | preference != "normalan" | preference != "blokiran kontakt")
            {
                Console.WriteLine("Preferenca ne moze biti prazna! Molim vas ponovo unesite.");
                Console.Write("\r\nUnesite novu preferencu(favorit/normalan/blokiran kontakt): ");
                preference = Console.ReadLine();

                if (preference == "favorit" | preference == "normalan" | preference == "blokiran kontakt")
                    break;
            }

            return preference;
        }

        private static void AddingNewContacts(Dictionary<Contact, List<Call>> phoneBook)
        {
            Console.Clear();
            
            Console.Write("\r\nUnesite ime i prezime: ");
            var name = Console.ReadLine();

            name = CheckingNameInput(name);

            Console.Write("\r\nUnesite broj telefona: ");
            var phoneNumber = Console.ReadLine();

            phoneNumber = CheckingPhoneNumberInput(phoneNumber);
            phoneNumber = CheckingIfPhoneNumberAlreadyExists(phoneNumber, phoneBook);

            phoneBook.Add(new Contact(name, phoneNumber, null), new List<Call>());

            PrintAllContacts(phoneBook);
        }

        private static void DeleteContacts(Dictionary<Contact, List<Call>> phoneBook)
        {
            Console.Clear();

            Console.Write("\r\nUnesite ime i prezime: ");
            var name = Console.ReadLine();

            name = CheckingNameInput(name);

            foreach (var item in phoneBook.Keys)
            { 
                if (name == item.name)
                    phoneBook.Remove(item);
            }

            PrintAllContacts(phoneBook);
        }

        private static void EditingContactPreferences(Dictionary<Contact, List<Call>> phoneBook)
        {
            Console.Clear();

            Console.Write("\r\nUnesite ime i prezime: ");
            var name = Console.ReadLine();

            name = CheckingNameInput(name);
            name = CheckingIfNameExists(name, phoneBook);

            Console.Write("\r\nUnesite novu preferencu(favorit/normalan/blokiran kontakt): ");
            var preference = Console.ReadLine();

            preference = CheckingPreferenceInput(preference);

            foreach (var item in phoneBook.Keys)
            {
                if (name == item.name)
                    item.preference = preference;
            }

            PrintAllContacts(phoneBook);
        }
    }
}
