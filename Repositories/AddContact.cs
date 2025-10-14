using AddressBook.Helpers;
using AddressBook.Models;

namespace AddressBook.Repositories
{
    partial class ContactRepository
    {
        // METHOD TO ADD CONTACT
        public void AddContact()
        {
            Contacts c = new Contacts();
            IValidation validation = new Validation();

            Console.Clear();
            Utilities.OrderMessage("\n|--- ADD CONTACT ---|\n");
            Console.WriteLine("Press [0] and ENTER to go back to main menu.\n\n");
            Console.Write("Add contact:\n");

            // FIRSTNAME
            do
            {
                Console.Write("\nEnter first name: ");
                c.FirstName = Utilities.SafeReadLine();
                if (Utilities.Back(c.FirstName))
                    return;

                if (string.IsNullOrWhiteSpace(c.FirstName))
                {
                    validation.ValidationNoEmptyFieldsAllowedMessage();
                }
                else if (c.FirstName.Any(char.IsDigit))
                {
                    validation.ValidationNoNumbersAllowedMessage();
                }
            } while (string.IsNullOrWhiteSpace(c.FirstName) || c.FirstName.Any(char.IsDigit));

            // LASTNAME
            do
            {
                Console.Write("\nEnter last name: ");
                c.LastName = Console.ReadLine() ?? "";
                if (Utilities.Back(c.LastName))
                    return;

                if (string.IsNullOrWhiteSpace(c.LastName))
                {
                    validation.ValidationNoEmptyFieldsAllowedMessage();
                }
                else if (c.LastName.Any(char.IsDigit))
                {
                    validation.ValidationNoNumbersAllowedMessage();
                }
            } while (string.IsNullOrWhiteSpace(c.LastName) || c.LastName.Any(char.IsDigit));

            // ADDRESS
            do
            {
                Console.Write("\nEnter address: ");
                c.Address = Utilities.SafeReadLine();
                if (Utilities.Back(c.Address))
                    return;

                if (string.IsNullOrWhiteSpace(c.Address))
                {
                    validation.ValidationNoEmptyFieldsAllowedMessage();

                }
                else if (char.IsDigit(c.Address[0]))
                {
                    validation.ValidationResult("Cant start with numbers!");
                }
            } while (string.IsNullOrWhiteSpace(c.Address) || char.IsDigit(c.Address[0]));

            // ZIP CODE
            string zipCode;
            do
            {
                // Console.WriteLine("Press [B] and ENTER to go back to main menu.\n\n");

                Console.Write("\nEnter ZIP code (must be 5 numbers): ");
                zipCode = Utilities.SafeReadLine();
                if (Utilities.Back(zipCode))
                    return;

                if (string.IsNullOrWhiteSpace(zipCode))
                {
                    validation.ValidationNoEmptyFieldsAllowedMessage();
                }
                else if (!zipCode.All(char.IsDigit))
                {
                    validation.ValidationOnlyNumbersAllowedMessage();
                }
                else if (zipCode.Length != 5)
                {
                    validation.ValidationResult("ZIP Code needs to be 5 digits!");
                }
            } while (zipCode.Length != 5 || !zipCode.All(char.IsDigit));
            c.ZipCode = zipCode;

            // CITY
            do
            {
                Console.Write("\nEnter city: ");
                c.City = Utilities.SafeReadLine();

                if (Utilities.Back(c.City))
                    return;

                if (string.IsNullOrWhiteSpace(c.City))
                {
                    validation.ValidationNoEmptyFieldsAllowedMessage();
                }
                else if (c.City.Any(char.IsDigit))
                {
                    validation.ValidationNoNumbersAllowedMessage();
                }
            } while (string.IsNullOrWhiteSpace(c.City) || c.City.Any(char.IsDigit));

            // PHONE NUMBER
            string phone;
            do
            {
                Console.Write("\nEnter phone number: ");
                phone = Utilities.SafeReadLine();
                if (Utilities.Back(phone))
                    return;

                if (string.IsNullOrWhiteSpace(phone))
                {
                    validation.ValidationNoEmptyFieldsAllowedMessage();
                }
                else if (!phone.All(char.IsDigit))
                {
                    validation.ValidationOnlyNumbersAllowedMessage();
                }
                else if (phone.Length != 10)
                {
                    validation.ValidationResult("Phone number needs to be 10 digits!");
                }
            } while (phone.Length != 10 || !phone.All(char.IsDigit));
            c.PhoneNumber = phone;

            // EMAIL
            do
            {
                Console.Write("\nEnter email: ");
                c.Email = Utilities.SafeReadLine();

                if (Utilities.Back(c.Email))
                    return;

                if (string.IsNullOrWhiteSpace(c.Email))
                {
                    validation.ValidationNoEmptyFieldsAllowedMessage();
                }
                else if (!c.Email.Contains("@"))
                {
                    validation.ValidationResult("Email must contain '@'!");
                }
            } while (
                string.IsNullOrWhiteSpace(c.Email) || (c.Email != null && !c.Email.Contains("@"))
            );

            // ID
            if (contacts.Count == 0)
            {
                c.Id = 1;
            }
            else
            {
                int currentMaxId = contacts.Max(x => x.Id);
                c.Id = currentMaxId + 1;
            }

            contacts.Add(c);

            Console.Write("\nAdding contact");
            Utilities.Loader();
            SaveContactsToFile();
            Console.WriteLine("\nContact added!");
            Utilities.Stop();
        }
    }
}
