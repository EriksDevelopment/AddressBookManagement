using AddressBook.Models;
using AddressBook.Utilities;

namespace AddressBook.Repositories
{
    partial class ContactRepository
    {
        // METHOD TO ADD CONTACT
        public void AddContact()
        {
            Contacts c = new Contacts();

            Console.Clear();
            Utilities.Utilities.OrderMessage("\n|--- ADD CONTACT ---|\n");
            Console.WriteLine("Press [0] and ENTER to go back to main menu.\n\n");
            Console.Write("Add contact:\n");

            // FIRSTNAME
            do
            {
                Console.Write("\nEnter first name: ");
                c.FirstName = Utilities.Utilities.SafeReadLine();
                if (Utilities.Utilities.Back(c.FirstName))
                    return;

                if (string.IsNullOrWhiteSpace(c.FirstName))
                {
                    Console.WriteLine("No empty feilds allowed!");
                    Thread.Sleep(1000);
                }
                else if (c.FirstName.Any(char.IsDigit))
                {
                    Console.WriteLine("No numbers allowed!");
                    Thread.Sleep(1000);
                }
            } while (string.IsNullOrWhiteSpace(c.FirstName) || c.FirstName.Any(char.IsDigit));

            // LASTNAME
            do
            {
                Console.Write("\nEnter last name: ");
                c.LastName = Console.ReadLine() ?? "";
                if (Utilities.Utilities.Back(c.LastName))
                    return;

                if (string.IsNullOrWhiteSpace(c.LastName))
                {
                    Console.WriteLine("No empty feilds allowed!");
                    Thread.Sleep(1000);
                }
                else if (c.LastName.Any(char.IsDigit))
                {
                    Console.WriteLine("No numbers allowed!");
                    Thread.Sleep(1000);
                }
            } while (string.IsNullOrWhiteSpace(c.LastName) || c.FirstName.Any(char.IsDigit));

            // ADDRESS
            do
            {
                Console.Write("\nEnter address: ");
                c.Address = Utilities.Utilities.SafeReadLine();
                if (Utilities.Utilities.Back(c.Address))
                    return;

                if (string.IsNullOrWhiteSpace(c.Address))
                {
                    Console.WriteLine("No empty feilds allowed!");
                    Thread.Sleep(1000);
                }
            } while (string.IsNullOrWhiteSpace(c.Address));

            // ZIP CODE
            string zipCode;
            do
            {
                // Console.WriteLine("Press [B] and ENTER to go back to main menu.\n\n");

                Console.Write("\nEnter ZIP code (must be 5 numbers): ");
                zipCode = Utilities.Utilities.SafeReadLine();
                if (Utilities.Utilities.Back(zipCode))
                    return;

                if (string.IsNullOrWhiteSpace(zipCode))
                {
                    Console.WriteLine("No empty feilds allowed!");
                    Thread.Sleep(1000);
                }
                else if (!zipCode.All(char.IsDigit))
                {
                    Console.WriteLine("Only numbers allowed!");
                    Thread.Sleep(1000);
                }
                else if (zipCode.Length != 5)
                {
                    Console.WriteLine("ZIP Code needs to be 5 digits!");
                    Thread.Sleep(1000);
                }
            } while (zipCode.Length != 5 || !zipCode.All(char.IsDigit));
            c.ZipCode = zipCode;

            // CITY
            do
            {
                Console.Write("\nEnter city: ");
                c.City = Utilities.Utilities.SafeReadLine();

                if (Utilities.Utilities.Back(c.City))
                    return;

                if (string.IsNullOrWhiteSpace(c.City))
                {
                    Console.WriteLine("No empty feilds allowed!");
                    Thread.Sleep(1000);
                }
                else if (c.City.Any(char.IsDigit))
                {
                    Console.WriteLine("No numbers allowed!");
                    Thread.Sleep(1000);
                }
            } while (string.IsNullOrWhiteSpace(c.City) || c.City.Any(char.IsDigit));

            // PHONE NUMBER
            string phone;
            do
            {
                Console.Write("\nEnter phone number: ");
                phone = Utilities.Utilities.SafeReadLine();
                if (Utilities.Utilities.Back(phone))
                    return;

                if (string.IsNullOrWhiteSpace(phone))
                {
                    Console.WriteLine("No empty feilds allowed!");
                    Thread.Sleep(1000);
                }
                else if (!phone.All(char.IsDigit))
                {
                    Console.WriteLine("Only numbers allowed! (10)");
                    Thread.Sleep(1000);
                }
                else if (phone.Length != 10)
                {
                    Console.WriteLine("Phone number needs to be 10 digits!");
                    Thread.Sleep(1000);
                }
            } while (phone.Length != 10 || !phone.All(char.IsDigit));
            c.PhoneNumber = phone;

            // EMAIL
            do
            {
                Console.Write("\nEnter email: ");
                c.Email = Utilities.Utilities.SafeReadLine();

                if (Utilities.Utilities.Back(c.Email))
                    return;

                if (string.IsNullOrWhiteSpace(c.Email))
                {
                    Console.WriteLine("No empty feilds allowed!");
                    Thread.Sleep(1000);
                }
                else if (!c.Email.Contains("@"))
                {
                    Console.WriteLine("Email must contain '@'!");
                    Thread.Sleep(1000);
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
            Utilities.Utilities.Loader();
            SaveContactsToFile();
            Console.WriteLine("\nContact added!");
            Utilities.Utilities.Stop();
        }
    }
}
