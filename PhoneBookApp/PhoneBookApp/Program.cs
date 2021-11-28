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
                /*case "3":
                    DeleteContacts(phoneBook);
                    return true;
                case "4":
                    EditingContactPreferences(phoneBook);
                    return true;
                case "5":
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
            
                Console.WriteLine(item.name + " - " + item.phoneNumber);

            Console.WriteLine("Pritisnite enter za povratak na izbornik...");
            Console.ReadLine();
        }

        private static string CheckingName(string name)
        {
                if (string.IsNullOrEmpty(name))
                {
                    Console.WriteLine("Ime i prezime ne moze biti prazno! Molim vas ponovo unesite.");
                    Console.Write("\r\nUnesite ime i prezime: ");
                    name = Console.ReadLine();
                }

            return name;
        }

        private static string CheckingPhoneNumber(string phoneNumber, Dictionary<Contact, List<Call>> phoneBook)
        {
            foreach (var item in phoneBook.Keys)
            {
                if (phoneNumber == item.phoneNumber)
                {
                    Console.WriteLine("Kontakt s tim brojem već postoji! Molim vas ponovo unesite.");
                    Console.Write("\r\nUnesite broj telefona: ");
                    phoneNumber = Console.ReadLine();
                }
            }

            return phoneNumber;
        }

        private static void AddingNewContacts(Dictionary<Contact, List<Call>> phoneBook)
        {
            Console.Clear();
            
            Console.Write("\r\nUnesite ime i prezime: ");
            var name = Console.ReadLine();

            name = CheckingName(name);

            Console.Write("\r\nUnesite broj telefona: ");
            var phoneNumber = Console.ReadLine();

            phoneNumber = CheckingPhoneNumber(phoneNumber, phoneBook);

            phoneBook.Add(new Contact(name, phoneNumber, null), new List<Call>());

            PrintAllContacts(phoneBook);
        }
    }
}
