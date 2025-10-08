using AddressBook.Helpers;

namespace AddressBook.Repositories
{
    partial class ContactRepository
    {
        // METHOD TO LIST ALL CONTACTS
        public void ListAllContacts()
        {
            Console.Clear();
            Utilities.OrderMessage("\n|--- LIST ALL CONTACTS ---|\n");

            if (contacts.Count == 0)
            {
                Console.WriteLine("\nNo contacts added!");
            }
            else
            {
                foreach (var c in contacts)
                {
                    Console.WriteLine(c);
                }
            }
            Utilities.Stop();
        }
    }
}