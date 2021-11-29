using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneBookApp
{
    class Program
    {
        static void Main(string[] args)
        {   
            var phoneBook = new Dictionary<Contact, List<Call>>();
            phoneBook.Add(new Contact("Mate Matić", "0991234567", 1), new List<Call>() {new Call (DateTime.Now, 1),
                                                                                       {new Call (DateTime.Now, 2) } });
            phoneBook.Add(new Contact("Ana Anić", "0995671234", 2), new List<Call>() { new Call(DateTime.Now, 1) });
            phoneBook.Add(new Contact("Ena Enić", "0987654321", 3), new List<Call>() { new Call(DateTime.Now, 3) });

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
            Console.WriteLine();
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
                case "5":
                    Submenu(phoneBook);
                    return true;
                case "6":
                    PrintAllCalls(phoneBook);
                    return true;
                case "7":
                    return false;
                default:
                    return true;
            }
        }

        private static void PressEnter()
        {
            Console.WriteLine("\r\nPritisnite enter za povratak na izbornik... ");
            while (Console.ReadKey().Key != ConsoleKey.Enter) { }
            Console.Clear();
        }

        static bool PhoneBookEmpty(Dictionary<Contact, List<Call>> phoneBook)
        {
            return phoneBook.Count is 0 ? true : false;
        }

        private static void CheckingIfPhoneBookIsEmpty(Dictionary<Contact, List<Call>> phoneBook)
        {
            if (PhoneBookEmpty(phoneBook))
            {
                Console.WriteLine("Kontakti su prazni!");
                return;
            }
        }

        private static void PrintAllContacts(Dictionary<Contact, List<Call>> phoneBook)
        {
            Console.Clear();
            Console.WriteLine("Popis kontakata:");
            Console.WriteLine();

            CheckingIfPhoneBookIsEmpty(phoneBook);

            foreach (var contact in phoneBook.Keys)

                Console.WriteLine(contact.Name + " - " + contact.PhoneNumber + " - " + contact.PreferenceValue);

            PressEnter();
        }

        static bool CheckingName(string name)
        {
            return name.Any(char.IsDigit) || name == "" ? true : false;
        }

        private static string CheckingNameInput(string name)
        {
            while (CheckingName(name))
            {
                Console.WriteLine("!Ime ne može biti prazno ili sadržavati brojeve! Molim vas ponovo unesite.");
                Console.Write("\r\nUnesite ime i prezime: ");
                name = Console.ReadLine();               
            }

            return name;
        }

        private static string NameInput(Dictionary<Contact, List<Call>> phoneBook)
        {
            Console.Clear();

            Console.Write("\r\nUnesite ime i prezime: ");
            var name = Console.ReadLine();

            name = CheckingNameInput(name);

            return name;
        }

        private static string CheckingIfNameExists(string name, Dictionary<Contact, List<Call>> phoneBook)
        {
            int count = 0;

            foreach (var contact in phoneBook.Keys)
            {
                if (name == contact.Name)
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

        static bool CheckingPhoneNumber(string phoneNumber)
        {
            return phoneNumber.Any(char.IsLetter) || phoneNumber == "" ? true : false;
        }

        private static string CheckingPhoneNumberInput(string phoneNumber)
        {
            while (CheckingPhoneNumber(phoneNumber))
            {
                Console.WriteLine("Broj telefona ne može biti prazan ili sadržavati slova! Molim vas ponovo unesite.");
                Console.Write("\r\nUnesite broj telefona: ");
                phoneNumber = Console.ReadLine();
            }

            return phoneNumber;
        }

        static bool ValidPhoneNumber(string phoneNumber)
        {
            return long.TryParse(phoneNumber, out long result) && phoneNumber.Length is 10 ? true : false;
        }

        private static string CheckingIfPhoneNumberIsValid(string phoneNumber)
        {
            while (!ValidPhoneNumber(phoneNumber))
            {
                Console.WriteLine("Broj mobitela krivo upisan, broj mora imati 10 znamenki");
                Console.Write("\r\nUnesite broj telefona: ");
                phoneNumber = Console.ReadLine();
                phoneNumber = CheckingPhoneNumberInput(phoneNumber);
            }

            return phoneNumber;
        }

        private static string CheckingIfPhoneNumberAlreadyExists(string phoneNumber, Dictionary<Contact, List<Call>> phoneBook)
        {
            foreach (var contact in phoneBook.Keys)
            {
                while (phoneNumber == contact.PhoneNumber)
                {
                    Console.WriteLine("Kontakt s tim brojem već postoji! Molim vas ponovo unesite.");
                    Console.Write("\r\nUnesite broj telefona: ");
                    phoneNumber = Console.ReadLine();
                    phoneNumber = CheckingPhoneNumberInput(phoneNumber);
                    phoneNumber = CheckingIfPhoneNumberIsValid(phoneNumber);
                }
            }

            return phoneNumber;
        }

        private static string PhoneNumberInput(Dictionary<Contact, List<Call>> phoneBook)
        {
            Console.Write("\r\nUnesite broj telefona: ");
            var phoneNumber = Console.ReadLine();

            phoneNumber = CheckingPhoneNumberInput(phoneNumber);
            phoneNumber = CheckingIfPhoneNumberIsValid(phoneNumber);
            phoneNumber = CheckingIfPhoneNumberAlreadyExists(phoneNumber, phoneBook);

            return phoneNumber;
        }

        private static void AddingNewContacts(Dictionary<Contact, List<Call>> phoneBook)
        {
            var name = NameInput(phoneBook);

            var phoneNumber = PhoneNumberInput(phoneBook);

            phoneBook.Add(new Contact(name, phoneNumber), new List<Call>());

            PrintAllContacts(phoneBook);
        }

        private static void DeleteContacts(Dictionary<Contact, List<Call>> phoneBook)
        {
            var name = NameInput(phoneBook);
            name = CheckingIfNameExists(name, phoneBook);

            foreach (var contact in phoneBook.Keys)
            { 
                if (name == contact.Name)
                    phoneBook.Remove(contact);
            }

            PrintAllContacts(phoneBook);
        }

        private static void PrintPreference()
        {
            Console.Clear();
            Console.WriteLine("Odaberite preferencu:");
            Console.WriteLine();
            Console.WriteLine("1 - Favorit");
            Console.WriteLine("2 - Normalan");
            Console.WriteLine("3 - Blokiran kontakt");
            Console.Write("\r\nUnesite odabir: ");
        }

        private static void EditingContactPreferences(Dictionary<Contact, List<Call>> phoneBook)
        {
            var name = NameInput(phoneBook);
            name = CheckingIfNameExists(name, phoneBook);

            PrintPreference();
            var input = Console.ReadLine();
           
            while (true)
            {
                if (input == "1" | input == "2" | input == "3")
                {
                    Contact.Preference preference = (Contact.Preference)Enum.Parse(typeof(Contact.Preference), input);

                    foreach (var contact in phoneBook.Keys)
                    {
                        if (name == contact.Name)
                            contact.PreferenceValue = preference;                 
                    }
                }

                else
                {
                    Console.WriteLine("Preferenca mora biti jedno od ponuđenih( 1 - favorit/ 2 - normalan/ 3 - blokiran kontakt )! Molim vas ponovo unesite.");
                    Console.Write("\r\nUnesite novu preferencu( 1 - favorit/ 2 - normalan/ 3 - blokiran kontakt ): ");
                    input = Console.ReadLine();
                }

                PrintAllContacts(phoneBook);
            }         
        }

        private static void PrintSubmenu()
        {
            Console.Clear();
            Console.WriteLine("Odaberite akciju:");
            Console.WriteLine("1 - Ispis svih poziva sa tim kontaktom poredan od vremenski najnovijeg prema najstarijem");
            Console.WriteLine("2 - Kreiranje novog poziva");
            Console.WriteLine("3 - Izlaz iz submenu");
            Console.Write("\r\nUnesite odabir: ");
        }

        private static bool Submenu(Dictionary<Contact, List<Call>> phoneBook)
        {
            PrintSubmenu();

            switch (Console.ReadLine())
            {
                case "1":
                    PrintAllCallsWithContact(phoneBook);
                    return true;
                case "2":
                    CreatingNewCall(phoneBook);
                    return true;
                case "3":
                    return false;
                default:
                    return true;
            }
        }

        private static void CheckingIfListIsEmpty(string name, Dictionary<Contact, List<Call>> phoneBook)
        {
            foreach (var contact in phoneBook.Keys)
            {
                while (name == contact.Name)
                {
                    List<Call> value = phoneBook[contact];

                    if (!(value?.Any() ?? false))
                    {
                        Console.WriteLine("Lista poziva je prazna! Nisu obavljeni nikakvi pozivi s tim kontaktom.");
                        Console.ReadLine();
                        break;
                    }
                }
            } 
        }
       
        private static void PrintAllCallsWithContact(Dictionary<Contact, List<Call>> phoneBook)
        {
            var name = NameInput(phoneBook);
            name = CheckingIfNameExists(name, phoneBook);

            Console.WriteLine("Ispis svih poziva sa kontaktom " + name + ": ");

            foreach (var contact in phoneBook.Keys)
            {
                while (name == contact.Name)
                {
                    foreach (var call in phoneBook[contact])                   
                        Console.WriteLine("Vrijeme poziva: " + call.TimeOfCall + " Status poziva: " + call.CallStatus);
                    
                    break;
                } 
            }

            PressEnter();
        }

        private static string CreatingNewCall_NameInput(Dictionary<Contact, List<Call>> phoneBook)
        {
            Console.Clear();
            Console.Write("\r\nUnesite ime i prezime osobe koju želite kontaktirati: ");
            var name = Console.ReadLine();

            name = CheckingNameInput(name);
            name = CheckingIfNameExists(name, phoneBook);

            return name;
        }

        private static int CheckingForCallsInProgress(Dictionary<Contact, List<Call>> phoneBook)
        {
            var count = 0;

            foreach (var contact in phoneBook.Keys)
            {
                foreach (var call in phoneBook[contact])
                {
                    if (call.CallStatus == Call.Status.InProgress)
                        count++;
                }
            }

            return count;
        }

        private static void CreatingNewCall(Dictionary<Contact, List<Call>> phoneBook)
        {
            var name = CreatingNewCall_NameInput(phoneBook);

            Random random = new Random(DateTime.Now.Millisecond);

            var answerChoice = random.Next(1, 3);
            var callDuration = random.Next(1, 20);

            Call currentCall = new Call(DateTime.Now, answerChoice);

            foreach (var contact in phoneBook.Keys)
            {
                if (name == contact.Name)
                {
                    var List = phoneBook[contact];
                 
                    if (contact.PreferenceValue == Contact.Preference.Blocked)
                    {
                        Console.WriteLine("Nemoguće obaviti poziv! Osoba je blokirana.");
                        Console.ReadLine();
                    }

                    else
                    {
                        switch (answerChoice)
                        {
                            case 1:
                                currentCall.CallStatus = Call.Status.Missed;
                                List.Add(currentCall);

                                Console.WriteLine("Propušten je poziv.");
                                Console.ReadLine();

                                break;

                            case 2:
                                var count = CheckingForCallsInProgress(phoneBook);

                                if (count == 0)
                                {
                                    currentCall.CallStatus = Call.Status.InProgress;

                                    Console.WriteLine($"Poziv u tijeku! Sačekajte dok završi...");
                                    Console.WriteLine(callDuration + "s");

                                    Task.Delay(callDuration * 1000).Wait();

                                    currentCall.CallStatus = Call.Status.Ended;
                                    List.Add(currentCall);

                                    Console.WriteLine("Poziv je završen");
                                    Console.ReadLine();
                                }

                                else
                                {
                                    Console.WriteLine("Nemoguće je obaviti poziv! Postoji poziv u tijeku.");
                                    Console.ReadLine();
                                }

                                break;

                            case 3:
                                currentCall.CallStatus = Call.Status.Ended;
                                List.Add(currentCall);

                                Console.WriteLine("Poziv je završen. Trajanje poziva: " + callDuration + "s.");
                                Console.ReadLine();

                                break;
                        }
                    }
                }  
            }
        }

        private static void PrintAllCalls(Dictionary<Contact, List<Call>> phoneBook)
        {
            Console.Clear();

            CheckingIfPhoneBookIsEmpty(phoneBook);

            foreach (var contact in phoneBook.Keys)
            {
                Console.WriteLine();
                Console.WriteLine("Ispis svih poziva kontakta " + contact.Name + ": ");

                foreach (var call in phoneBook[contact])
                    Console.WriteLine("Vrijeme poziva: " + call.TimeOfCall + " Status poziva: " + call.CallStatus);
                
            }

            PressEnter();
        }
    }
}
