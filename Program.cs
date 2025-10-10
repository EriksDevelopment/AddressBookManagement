using AddressBook.Helpers;
using AddressBook.Repositories;

namespace AddressBook
{
    class Program
    {
        static void Main(string[] args)
        {
            ContactRepository addressBook = new ContactRepository();
            addressBook.LoadContactsFromFile();

            bool run = true;

            while (run)
            {
                Console.Clear();
                Utilities.OrderMessage("\n|--- CONTACT BOOK ---|\n");

                Console.WriteLine("\n[1] Add contact");
                Console.WriteLine("\n[2] Update contact");
                Console.WriteLine("\n[3] Search contact");
                Console.WriteLine("\n[4] List all contacts");
                Console.WriteLine("\n[5] Delete contact");
                Console.WriteLine("\n[X] = Quit");
                Console.Write("\nYour choice: ");
                var Choice = Utilities.SafeReadLine().ToLower();
                if (Choice == "x")
                {
                    Console.Write("\nQuitting");
                    Utilities.Loader();
                    break;
                }

                switch (Choice)
                {
                    case "1":
                        addressBook.AddContact();
                        break;
                    case "2":
                        addressBook.UpdateContact();
                        break;
                    case "3":
                        addressBook.SearchContact();
                        break;
                    case "4":
                        addressBook.ListAllContacts();
                        break;
                    case "5":
                        addressBook.DeleteContactMenu();
                        break;
                    case "x":
                        Console.Write("\nQuitting");
                        Helpers.Utilities.Loader();
                        return;

                    default:
                        Console.WriteLine("Only number allowed (1-5)!");
                        Thread.Sleep(1000);
                        break;
                }
            }
        }
    }
}
