using AddressBook.Utilities;

namespace AddressBook.Repositories
{
    partial class ContactRepository
    {
        // METHOD TO UPDATE A CONTACT
        public void UpdateContact()
        {
            Console.Clear();
            Utilities.Utilities.OrderMessage("\n|--- UPDATE CONTACT ---|\n");
            Console.WriteLine("Press [0] and ENTER to go back to main menu.\n\n");

            Console.WriteLine("[1] Update contact by search (name or address)\n");
            Console.WriteLine("[2] Update contact by list");
            Console.Write("\nYour choice: ");
            string choice = Utilities.Utilities.SafeReadLine().ToLower();
            if (Utilities.Utilities.Back(choice))
                return;

            // OPTION 1: UPDATE CONTACT BY SEARCH

            if (choice == "1")
            {
                Console.Clear();
                Utilities.Utilities.OrderMessage("\n|--- UPDATE CONTACT ---|\n");
                Console.WriteLine("Press [0] and ENTER to go back to main menu.\n\n");

                Console.Write("\nSearch name of contact: ");
                string search = Utilities.Utilities.SafeReadLine().ToLower();
                if (Utilities.Utilities.Back(search))
                    return;

                var contactsFound = contacts
                    .Where(c =>
                        c.FirstName.Contains(search, StringComparison.OrdinalIgnoreCase)
                        || c.LastName.Contains(search, StringComparison.OrdinalIgnoreCase)
                    )
                    .ToList();

                Console.Write($"Search: {search} ");
                if (contactsFound.Count == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"({contactsFound.Count} results)");
                    Console.ResetColor();
                    Utilities.Utilities.Stop();
                    return;
                }

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"({contactsFound.Count} results)");
                Console.ResetColor();

                foreach (var c in contactsFound)
                {
                    Console.Write($"\nID: [{c.Id}] ");
                    Utilities.Utilities.HighlightMatch(c.FirstName, search);
                    Console.Write(", ");
                    Utilities.Utilities.HighlightMatch(c.LastName, search);
                    Console.Write(
                        $", {c.Address}, {c.ZipCode} {c.City}, {c.PhoneNumber}, {c.Email}\n"
                    );
                }

                Console.Write("\nEnter the ID of the contact you want to update: ");
                string input = Utilities.Utilities.SafeReadLine();
                if (Utilities.Utilities.Back(input))
                    return;

                if (int.TryParse(input, out int id))
                {
                    var updateContact = contacts.FirstOrDefault(c => c.Id == id);
                    if (updateContact != null)
                    {
                        Console.Clear();
                        Utilities.Utilities.OrderMessage("\n|--- UPDATE CONTACT ---|\n");
                        Console.WriteLine("Press [0] and ENTER to go back to main menu.\n\n");

                        Console.Write("Enter new first name (leave blank to keep current): ");
                        string firstName = Utilities.Utilities.SafeReadLine();
                        if (Utilities.Utilities.Back(firstName))
                            return;
                        if (!string.IsNullOrWhiteSpace(firstName))
                            updateContact.FirstName = firstName;

                        Console.Write("Enter new last name (leave blank to keep current): ");
                        string lastName = Utilities.Utilities.SafeReadLine();
                        if (Utilities.Utilities.Back(lastName))
                            return;
                        if (Utilities.Utilities.Back(lastName))
                            return;
                        if (!string.IsNullOrWhiteSpace(lastName))
                            updateContact.LastName = lastName;

                        Console.Write("Enter new address (leave blank to keep current): ");
                        string address = Utilities.Utilities.SafeReadLine();
                        if (Utilities.Utilities.Back(address))
                            return;

                        if (!string.IsNullOrWhiteSpace(address))
                            updateContact.Address = address;

                        Console.Write(
                            "Enter new ZIP code (must be 5 numbers, leave blank to keep current): "
                        );
                        string zipCode = Utilities.Utilities.SafeReadLine();
                        if (Utilities.Utilities.Back(zipCode))
                            return;

                        if (!string.IsNullOrWhiteSpace(zipCode))
                        {
                            if (zipCode.Length == 5 && zipCode.All(char.IsDigit))
                                updateContact.ZipCode = zipCode;
                            else
                                Console.WriteLine("Invalid ZIP code, keeping old value.");
                        }

                        Console.Write("Enter new city (leave blank to keep current): ");
                        string city = Utilities.Utilities.SafeReadLine();
                        if (Utilities.Utilities.Back(city))
                            return;

                        if (Utilities.Utilities.Back(city))
                            return;
                        if (!string.IsNullOrWhiteSpace(city))
                            updateContact.City = city;

                        Console.Write("Enter new phone number (leave blank to keep current): ");
                        string phoneNumber = Utilities.Utilities.SafeReadLine();
                        if (Utilities.Utilities.Back(phoneNumber))
                            return;

                        if (Utilities.Utilities.Back(phoneNumber))
                            return;
                        if (!string.IsNullOrWhiteSpace(phoneNumber))
                            updateContact.PhoneNumber = phoneNumber;

                        Console.Write("Enter new email (leave blank to keep current): ");
                        string email = Utilities.Utilities.SafeReadLine();
                        if (Utilities.Utilities.Back(email))
                            return;

                        if (Utilities.Utilities.Back(email))
                            return;
                        if (!string.IsNullOrWhiteSpace(email))
                            updateContact.Email = email;

                        SaveContactsToFile();
                        Console.WriteLine("\nContact updated!");
                    }
                    else
                    {
                        Console.WriteLine("\nNo contact found with that ID.");
                    }
                }
                else
                {
                    Console.WriteLine("\nInvalid input, only numbers allowed.");
                }

                Utilities.Utilities.Stop();
                return;
            }
            // OPTION 2: UPDATE CONTACT FROM LIST

            else if (choice == "2")
            {
                if (contacts.Count == 0)
                {
                    Console.WriteLine("\nNo contacts to update.");
                    Utilities.Utilities.Stop();
                    return;
                }

                Console.WriteLine("\nSelect a contact to update:\n");
                foreach (var c in contacts)
                {
                    Console.WriteLine(c);
                }

                Console.Write("\nEnter the ID of the contact you want to update: ");
                string input = Utilities.Utilities.SafeReadLine();
                if (Utilities.Utilities.Back(input))
                    return;

                if (int.TryParse(input, out int id))
                {
                    var updateContact = contacts.FirstOrDefault(c => c.Id == id);
                    if (updateContact != null)
                    {
                        Console.Clear();
                        Utilities.Utilities.OrderMessage("\n|--- UPDATE CONTACT ---|\n");
                        Console.WriteLine("Press [0] and ENTER to go back to main menu.\n\n");

                        Console.Write("\nEnter new first name (leave blank to keep current): ");
                        string firstName = Utilities.Utilities.SafeReadLine();
                        if (Utilities.Utilities.Back(firstName))
                            return;
                        if (!string.IsNullOrWhiteSpace(firstName))
                            updateContact.FirstName = firstName;

                        Console.Write("Enter new last name (leave blank to keep current): ");
                        string lastName = Utilities.Utilities.SafeReadLine();
                        if (Utilities.Utilities.Back(lastName))
                            return;
                        if (!string.IsNullOrWhiteSpace(lastName))
                            updateContact.LastName = lastName;

                        Console.Write("Enter new address (leave blank to keep current): ");
                        string address = Utilities.Utilities.SafeReadLine();
                        if (Utilities.Utilities.Back(address))
                            return;
                        if (!string.IsNullOrWhiteSpace(address))
                            updateContact.Address = address;

                        Console.Write(
                            "Enter new ZIP code (must be 5 numbers, leave blank to keep current): "
                        );
                        string zipCode = Utilities.Utilities.SafeReadLine();
                        if (!string.IsNullOrWhiteSpace(zipCode))
                        {
                            if (zipCode.Length == 5 && zipCode.All(char.IsDigit))
                                updateContact.ZipCode = zipCode;
                            else
                                Console.WriteLine("Invalid ZIP code, keeping old value.");
                        }

                        Console.Write("Enter new city (leave blank to keep current): ");
                        string city = Utilities.Utilities.SafeReadLine();
                        if (Utilities.Utilities.Back(city))
                            return;
                        if (!string.IsNullOrWhiteSpace(city))
                            updateContact.City = city;

                        Console.Write("Enter new phone number (leave blank to keep current): ");
                        string phoneNumber = Utilities.Utilities.SafeReadLine();
                        if (Utilities.Utilities.Back(phoneNumber))
                            return;
                        if (!string.IsNullOrWhiteSpace(phoneNumber))
                            updateContact.PhoneNumber = phoneNumber;

                        Console.Write("Enter new email (leave blank to keep current): ");
                        string email = Utilities.Utilities.SafeReadLine();
                        if (Utilities.Utilities.Back(email))
                            return;
                        if (!string.IsNullOrWhiteSpace(email))
                            updateContact.Email = email;

                        SaveContactsToFile();
                        Console.WriteLine("\nContact updated!");
                    }
                    else
                    {
                        Console.WriteLine("\nNo contact found with that ID.");
                    }
                }
                else
                {
                    Console.WriteLine("\nInvalid input, only numbers allowed.");
                }

                Utilities.Utilities.Stop();
            }
        }
    }
}
