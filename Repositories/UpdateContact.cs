using AddressBook.Helpers;

namespace AddressBook.Repositories
{
    partial class ContactRepository
    {
        // METHOD TO UPDATE A CONTACT
        public void UpdateContact()
        {
            while (true)
            {
                Console.Clear();
                Utilities.OrderMessage("\n|--- UPDATE CONTACT ---|\n");
                Console.WriteLine("Press [0] and ENTER to go back to main menu.\n\n");

                Console.WriteLine("[1] Update contact by search (name or address)\n");
                Console.WriteLine("[2] Update contact by list");
                Console.Write("\nYour choice: ");
                string choice = Utilities.SafeReadLine().ToLower();
                if (Utilities.Back(choice))
                    return;

                // OPTION 1: UPDATE CONTACT BY SEARCH

                if (choice == "1")
                {
                    Console.Clear();
                    Utilities.OrderMessage("\n|--- UPDATE CONTACT ---|\n");
                    Console.WriteLine("Press [0] and ENTER to go back to main menu.\n\n");

                    Console.Write("\nSearch name of contact: ");
                    string search = Utilities.SafeReadLine().ToLower();
                    if (Utilities.Back(search))
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
                        Utilities.Stop();
                        return;
                    }

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
                            $", {c.Address}, {c.ZipCode} {c.City}, {c.PhoneNumber}, {c.Email}\n"
                        );
                    }
                    int id;

                    while (true)
                    {
                        Console.Write("\nEnter the ID of the contact you want to update: ");
                        string input = Utilities.SafeReadLine();

                        if (Utilities.Back(input))
                            return;

                        if (!int.TryParse(input, out id))
                        {
                            Console.WriteLine("\nInvalid input, only numbers allowed.");
                            Thread.Sleep(1000);
                            continue;
                        }

                        break;
                    }

                    var updateContact = contacts.FirstOrDefault(c => c.Id == id);
                    if (updateContact == null)
                    {
                        Console.WriteLine("\nNo contact found with that ID.");
                        Utilities.Stop();
                        break;
                    }

                    Console.Clear();
                    Utilities.OrderMessage("\n|--- UPDATE CONTACT ---|\n");
                    Console.WriteLine("Press [0] and ENTER to go back to main menu.\n\n");

                    string firstName;
                    do
                    {
                        Console.Write("Enter new first name (leave blank to keep current): ");
                        firstName = Utilities.SafeReadLine();

                        if (Utilities.Back(firstName))
                            return;

                        if (string.IsNullOrWhiteSpace(firstName))
                            break; // tillåter tomt — behåll nuvarande värde

                        if (firstName.Any(char.IsDigit))
                        {
                            Console.WriteLine("No numbers allowed!");
                            Thread.Sleep(1000);
                        }
                    } while (firstName.Any(char.IsDigit));

                    if (!string.IsNullOrWhiteSpace(firstName))
                        updateContact.FirstName = firstName;

                    string lastName;
                    do
                    {
                        Console.Write("Enter new last name (leave blank to keep current): ");
                        lastName = Utilities.SafeReadLine();

                        if (Utilities.Back(lastName))
                            return;

                        if (string.IsNullOrWhiteSpace(lastName))
                            break;

                        if (lastName.Any(char.IsDigit))
                        {
                            Console.WriteLine("Numbers are not allowed in the name!");
                            Thread.Sleep(1000);
                        }
                    } while (lastName.Any(char.IsDigit));

                    if (!string.IsNullOrWhiteSpace(lastName))
                        updateContact.LastName = lastName;

                    Console.Write("Enter new address (leave blank to keep current): ");
                    string address = Utilities.SafeReadLine();
                    if (Utilities.Back(address))
                        return;

                    if (!string.IsNullOrWhiteSpace(address))
                        updateContact.Address = address;

                    string zipCode;
                    do
                    {
                        Console.Write(
                            "Enter new ZIP code (must be 5 numbers, leave blank to keep current): "
                        );
                        zipCode = Utilities.SafeReadLine();

                        if (Utilities.Back(zipCode))
                            return;

                        if (string.IsNullOrWhiteSpace(zipCode))
                            break;

                        if (!zipCode.All(char.IsDigit))
                        {
                            Console.WriteLine("Only numbers allowed!");
                            Thread.Sleep(1000);
                        }
                        else if (zipCode.Length != 5)
                        {
                            Console.WriteLine("ZIP Code needs to be 5 digits!");
                            Thread.Sleep(1000);
                        }
                    } while (
                        !string.IsNullOrWhiteSpace(zipCode)
                        && (zipCode.Length != 5 || !zipCode.All(char.IsDigit))
                    );

                    if (!string.IsNullOrWhiteSpace(zipCode))
                        updateContact.ZipCode = zipCode;

                    string city;
                    do
                    {
                        Console.Write("Enter new city (leave blank to keep current): ");
                        city = Utilities.SafeReadLine();

                        if (Utilities.Back(city))
                            return;

                        if (string.IsNullOrWhiteSpace(city))
                            break;

                        if (city.Any(char.IsDigit))
                        {
                            Console.WriteLine("No numbers allowed!");
                            Thread.Sleep(1000);
                        }
                    } while (!string.IsNullOrWhiteSpace(city) && city.Any(char.IsDigit));

                    if (!string.IsNullOrWhiteSpace(city))
                        updateContact.City = city;

                    string phoneNumber;
                    do
                    {
                        Console.Write("Enter new phone number (leave blank to keep current):  ");
                        phoneNumber = Utilities.SafeReadLine();

                        if (Utilities.Back(phoneNumber))
                            return;

                        if (string.IsNullOrWhiteSpace(phoneNumber))
                            break;

                        if (!phoneNumber.All(char.IsDigit))
                        {
                            Console.WriteLine("Only numbers allowed!");
                            Thread.Sleep(1000);
                        }
                        else if (phoneNumber.Length != 10)
                        {
                            Console.WriteLine("Phone number needs to be 10 digits!");
                            Thread.Sleep(1000);
                        }
                    } while (
                        !string.IsNullOrWhiteSpace(phoneNumber)
                        && (phoneNumber.Length != 10 || !phoneNumber.All(char.IsDigit))
                    );

                    if (!string.IsNullOrWhiteSpace(phoneNumber))
                        updateContact.PhoneNumber = phoneNumber;

                    string email;
                    do
                    {
                        Console.Write("Enter new email (leave blank to keep current):  ");
                        email = Utilities.SafeReadLine();

                        if (Utilities.Back(email))
                            return;

                        if (string.IsNullOrWhiteSpace(email))
                            break;

                        if (!email.Contains("@"))
                        {
                            Console.WriteLine("Email must contain '@'!");
                            Thread.Sleep(1000);
                        }
                    } while (!string.IsNullOrWhiteSpace(email) && !email.Contains("@"));

                    if (!string.IsNullOrWhiteSpace(email))
                        updateContact.Email = email;

                    SaveContactsToFile();
                    Console.WriteLine("\nContact updated!");
                    Utilities.Stop();
                    return;
                }
                // OPTION 2: UPDATE CONTACT FROM LIST

                else if (choice == "2")
                {
                    if (contacts.Count == 0)
                    {
                        Console.WriteLine("\nNo contacts to update.");
                        Utilities.Stop();
                        return;
                    }

                    Console.Clear();
                    Utilities.OrderMessage("\n|--- UPDATE CONTACT ---|\n");
                    Console.WriteLine("\nSelect a contact to update:\n");

                    foreach (var c in contacts)
                    {
                        Console.WriteLine(c);
                    }

                    Console.Write("\nEnter the ID of the contact you want to update: ");
                    string input = Utilities.SafeReadLine();
                    if (Utilities.Back(input))
                        return;

                    if (!int.TryParse(input, out int id))
                    {
                        Console.WriteLine("\nInvalid input, only numbers allowed.");
                        Utilities.Stop();
                        break;
                    }

                    var updateContact = contacts.FirstOrDefault(c => c.Id == id);
                    if (updateContact == null)
                    {
                        Console.WriteLine("\nNo contact found with that ID.");
                        Utilities.Stop();
                        break;
                    }
                    Console.Clear();
                    Utilities.OrderMessage("\n|--- UPDATE CONTACT ---|\n");
                    Console.WriteLine("Press [0] and ENTER to go back to main menu.\n\n");

                    string firstName;
                    do
                    {
                        Console.Write("Enter new first name (leave blank to keep current): ");
                        firstName = Utilities.SafeReadLine();

                        if (Utilities.Back(firstName))
                            return;

                        if (string.IsNullOrWhiteSpace(firstName))
                            break;

                        if (firstName.Any(char.IsDigit))
                        {
                            Console.WriteLine("No numbers allowed!");
                            Thread.Sleep(1000);
                        }
                    } while (firstName.Any(char.IsDigit));

                    if (!string.IsNullOrWhiteSpace(firstName))
                        updateContact.FirstName = firstName;

                    string lastName;
                    do
                    {
                        Console.Write("Enter new last name (leave blank to keep current): ");
                        lastName = Utilities.SafeReadLine();

                        if (Utilities.Back(lastName))
                            return;

                        if (string.IsNullOrWhiteSpace(lastName))
                            break;

                        if (lastName.Any(char.IsDigit))
                        {
                            Console.WriteLine("Numbers are not allowed in the name!");
                            Thread.Sleep(1000);
                        }
                    } while (lastName.Any(char.IsDigit));

                    if (!string.IsNullOrWhiteSpace(lastName))
                        updateContact.LastName = lastName;

                    Console.Write("Enter new address (leave blank to keep current): ");
                    string address = Utilities.SafeReadLine();
                    if (Utilities.Back(address))
                        return;

                    if (!string.IsNullOrWhiteSpace(address))
                        updateContact.Address = address;

                    string zipCode;
                    do
                    {
                        Console.Write(
                            "Enter new ZIP code (must be 5 numbers, leave blank to keep current): "
                        );
                        zipCode = Utilities.SafeReadLine();

                        if (Utilities.Back(zipCode))
                            return;

                        if (string.IsNullOrWhiteSpace(zipCode))
                            break;

                        if (!zipCode.All(char.IsDigit))
                        {
                            Console.WriteLine("Only numbers allowed!");
                            Thread.Sleep(1000);
                        }
                        else if (zipCode.Length != 5)
                        {
                            Console.WriteLine("ZIP Code needs to be 5 digits!");
                            Thread.Sleep(1000);
                        }
                    } while (
                        !string.IsNullOrWhiteSpace(zipCode)
                        && (zipCode.Length != 5 || !zipCode.All(char.IsDigit))
                    );

                    if (!string.IsNullOrWhiteSpace(zipCode))
                        updateContact.ZipCode = zipCode;

                    string city;
                    do
                    {
                        Console.Write("Enter new city (leave blank to keep current): ");
                        city = Utilities.SafeReadLine();

                        if (Utilities.Back(city))
                            return;

                        if (string.IsNullOrWhiteSpace(city))
                            break;

                        if (city.Any(char.IsDigit))
                        {
                            Console.WriteLine("No numbers allowed!");
                            Thread.Sleep(1000);
                        }
                    } while (!string.IsNullOrWhiteSpace(city) && city.Any(char.IsDigit));

                    if (!string.IsNullOrWhiteSpace(city))
                        updateContact.City = city;

                    string phoneNumber;
                    do
                    {
                        Console.Write("Enter new phone number (leave blank to keep current):  ");
                        phoneNumber = Utilities.SafeReadLine();

                        if (Utilities.Back(phoneNumber))
                            return;

                        if (string.IsNullOrWhiteSpace(phoneNumber))
                            break;

                        if (!phoneNumber.All(char.IsDigit))
                        {
                            Console.WriteLine("Only numbers allowed!");
                            Thread.Sleep(1000);
                        }
                        else if (phoneNumber.Length != 10)
                        {
                            Console.WriteLine("Phone number needs to be 10 digits!");
                            Thread.Sleep(1000);
                        }
                    } while (
                        !string.IsNullOrWhiteSpace(phoneNumber)
                        && (phoneNumber.Length != 10 || !phoneNumber.All(char.IsDigit))
                    );

                    if (!string.IsNullOrWhiteSpace(phoneNumber))
                        updateContact.PhoneNumber = phoneNumber;

                    string email;
                    do
                    {
                        Console.Write("Enter new email (leave blank to keep current):  ");
                        email = Utilities.SafeReadLine();

                        if (Utilities.Back(email))
                            return;

                        if (string.IsNullOrWhiteSpace(email))
                            break;

                        if (!email.Contains("@"))
                        {
                            Console.WriteLine("Email must contain '@'!");
                            Thread.Sleep(1000);
                        }
                    } while (!string.IsNullOrWhiteSpace(email) && !email.Contains("@"));

                    if (!string.IsNullOrWhiteSpace(email))
                        updateContact.Email = email;

                    SaveContactsToFile();
                    Console.WriteLine("\nContact updated!");
                    Utilities.Stop();
                    return;
                }
                else
                {
                    Console.WriteLine("Invalid choice, must be a number and [1] - [2]");
                    Thread.Sleep(1000);
                }
            }
        }
    }
}
