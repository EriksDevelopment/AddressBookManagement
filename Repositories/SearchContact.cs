using AddressBook.Helpers;

namespace AddressBook.Repositories
{
    partial class ContactRepository
    {
        Validation validation;
        // METHOD TO SEARCH CONTACT
        public ContactRepository()
        {
            validation = new Validation();
        }
        public void SearchContact()
        {
            while (true)
            {
                Console.Clear();
                Utilities.OrderMessage("\n|--- SEARCH CONTACT ---|\n");

                Console.WriteLine("[1] Search contact by name\n");
                Console.WriteLine("[2] Search contact by City or ZIP code");
                Console.Write("\nYour choice: ");
                string choice = Utilities.SafeReadLine().ToLower();

                if (choice == "1")
                {
                    Console.Clear();
                    Utilities.OrderMessage("\n|--- SEARCH CONTACT ---|\n");
                    Console.Write("\nSearch for contact (firstname or lastname): ");

                    string search = Utilities.SafeReadLine();

                    var contactsFound = contacts
                        .Where(c =>
                            c.FirstName.Contains(search, StringComparison.OrdinalIgnoreCase)
                            || c.LastName.Contains(search, StringComparison.OrdinalIgnoreCase)
                        )
                        .ToList();

                    if (contactsFound.Count == 0)
                    {
                        Console.Write($"Search: {search} ");
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"({contactsFound.Count} results)");
                        Console.ResetColor();
                        Utilities.Stop();
                        return;
                    }

                    Console.Write($"Search: {search} ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"({contactsFound.Count} results)");
                    Console.ResetColor();

                    foreach (var c in contactsFound)
                    {
                        Console.Write($"\nID: [{c.Id}] ");
                        Utilities.HighlightMatch(c.FirstName, search);
                        Console.Write(", ");
                        Utilities.HighlightMatch(c.LastName, search);
                        Console.Write(
                            $", {c.Address}, {c.ZipCode}, {c.City}, {c.PhoneNumber}, {c.Email}\n"
                        );
                    }
                    break;
                }
                else if (choice == "2")
                {
                    Console.Clear();
                    Utilities.OrderMessage("\n|--- SEARCH CONTACT ---|\n");
                    Console.Write("\nSearch for contact (city or ZIP code): ");

                    string search = Utilities.SafeReadLine();

                    var contactsFound = contacts
                        .Where(c =>
                            c.City.Contains(search, StringComparison.OrdinalIgnoreCase)
                            || c.ZipCode.Contains(search, StringComparison.OrdinalIgnoreCase)
                        )
                        .ToList();

                    if (contactsFound.Count == 0)
                    {
                        Console.Write($"Search: {search} ");
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"({contactsFound.Count} results)");
                        Console.ResetColor();

                        Utilities.Stop();
                        return;
                    }

                    Console.Write($"Search: {search} ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"({contactsFound.Count} results)");
                    Console.ResetColor();

                    foreach (var c in contactsFound)
                    {
                        Console.Write($"\nID: [{c.Id}] ");
                        Console.Write($"{c.FirstName}, {c.LastName}, {c.Address}, ");
                        Utilities.HighlightMatch(c.City, search);
                        Console.Write(", ");
                        Utilities.HighlightMatch(c.ZipCode, search);
                        Console.WriteLine($", {c.PhoneNumber}, {c.Email}\n");
                    }
                    break;
                }
                else
                {
                    validation.ValidationResult("Invalid choice, must be a number and [1] - [2]");
                }
            }
            Utilities.Stop();
        }
    }
}
