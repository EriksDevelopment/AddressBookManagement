using AddressBook.Helpers;

namespace AddressBook.Repositories
{
    partial class ContactRepository
    {
        // METHOD TO DELETE A CONTACT
        public void DeleteContactMenu()
        {
            bool run = true;
            while (run)
            {
                Console.Clear();
                Utilities.OrderMessage("\n|--- DELETE CONTACT ---|\n");

                if (contacts.Count == 0)
                {
                    Console.WriteLine("\nNo contacts to delete.");
                    Utilities.Stop();
                    return;
                }
                Console.Clear();
                Utilities.OrderMessage("\n|--- DELETE CONTACT ---|\n");
                Console.WriteLine("\n[1] Search contact");
                Console.WriteLine("\n[2] Full list");
                Console.Write("\nYour choice: ");

                string choice = Console.ReadLine()!;
                switch (choice)
                {
                    case "1":
                        DeleteContactSearch();
                        run = false;
                        break;
                    case "2":
                        DeleteContactList();
                        run = false;
                        break;
                    default:
                        Console.WriteLine("Invalid choice, must be a number and [1] - [2]");
                        Utilities.Stop();
                        return;
                }
            }
        }

        public void DeleteContactSearch()
        {
            Console.Clear();
            Utilities.OrderMessage("\n|--- DELETE CONTACT ---|\n");
            Console.Write("\nEnter name of the contact you want to delete: ");
            string search = Console.ReadLine()!;

            var foundContacts = contacts
                .Where(c =>
                    c.FirstName.Contains(search, StringComparison.OrdinalIgnoreCase)
                    || c.LastName.Contains(search, StringComparison.OrdinalIgnoreCase)
                )
                .ToList();

            Console.Clear();
            Utilities.OrderMessage("\n|--- DELETE CONTACT ---|\n");

            if (foundContacts.Count == 0 || string.IsNullOrWhiteSpace(search))
            {
                Console.Clear();
                Utilities.OrderMessage("\n|--- DELETE CONTACT ---|\n");
                Console.WriteLine($"\nNo contacts found with search: {search}");
                Utilities.Stop();
                return;
            }

            Console.WriteLine($"\nSearch: {search} ({foundContacts.Count} results)\n");

            foreach (var c in foundContacts)
            {
                Console.Write($"\nID: [{c.Id}] ");
                Utilities.HighlightMatch(c.FirstName, search);
                Console.Write(", ");
                Utilities.HighlightMatch(c.LastName, search);
                Console.Write($", {c.Address}, {c.ZipCode} {c.City}, {c.PhoneNumber}, {c.Email}\n");
            }

            Console.Write("\nEnter the ID of the contact you want to delete: ");
            string input = Console.ReadLine()!;

            if (int.TryParse(input, out int id))
            {
                var deleteContact = contacts.FirstOrDefault(c => c.Id == id);
                if (deleteContact != null)
                {
                    contacts.Remove(deleteContact);
                    SaveContactsToFile();
                    Console.Write("\nDeleting contact");
                    Utilities.Loader();
                    Console.WriteLine($"\nContact {deleteContact.FirstName} is deleted!");
                }
                else
                {
                    Console.WriteLine("\nNo contact found with that ID.");
                }
            }
            else
            {
                Console.WriteLine("\nInvalid ID format.");
            }
            Utilities.Stop();
        }

        public void DeleteContactList()
        {
            Console.Clear();
            Utilities.OrderMessage("\n|--- DELETE CONTACT ---|\n");

            Console.WriteLine("\nDelete from list:\n");
            foreach (var c in contacts)
            {
                Console.WriteLine(c);
            }

            Console.Write("\nEnter the ID of the contact you want to delete: ");
            string input = Console.ReadLine()!;

            if (int.TryParse(input, out int id))
            {
                var deleteContact = contacts.FirstOrDefault(c => c.Id == id);
                if (deleteContact != null)
                {
                    contacts.Remove(deleteContact);
                    SaveContactsToFile();
                    Console.Write("\nDeleting contact");
                    Utilities.Loader();
                    Console.WriteLine($"\nContact {deleteContact.FirstName} is deleted!");
                }
                else
                {
                    Console.WriteLine("\nNo contact found with that ID.");
                }
            }
            else
            {
                Console.WriteLine("\nInvalid ID format.");
            }
            Utilities.Stop();
        }
    }
}
