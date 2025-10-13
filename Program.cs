using AddressBook.Helpers;
using AddressBook.Repositories;

namespace AddressBook
{
    class Program
    {
        static void Main(string[] args)
        {
            ContactRepository addressBook = new ContactRepository();
            Validation validation = new Validation();
            addressBook.LoadContactsFromFile();

            while (true)
            {
                Console.Clear();
                Utilities.OrderMessage("\n|--- CONTACT BOOK ---|\n");

                Utilities.OrderMessage("\n[1] Add contact");
                Utilities.OrderMessage("\n[2] Update contact");
                Utilities.OrderMessage("\n[3] Search contact");
                Utilities.OrderMessage("\n[4] List all contacts");
                Utilities.OrderMessage("\n[5] Delete contact");
                Utilities.OrderMessage("\n[X] = Quit");
                Console.Write("\nYour choice: ");
                var Choice = Utilities.SafeReadLine().ToLower();
                if (Choice == "x")
                {
                    Utilities.OrderMessage("\nQuitting");
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

                    default:
                        validation.ValidationResult("Only number allowed (1-5)!");
                        break;
                }
            }
        }
    }
}
