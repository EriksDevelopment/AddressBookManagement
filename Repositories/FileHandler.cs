using AddressBook.Models;


namespace AddressBook.Repositories
{
    partial class ContactRepository
    {

        public void LoadContactsFromFile()
        {
            if (!File.Exists("Contacts.txt"))
                return;

            string[] lines = File.ReadAllLines("Contacts.txt");
            foreach (var line in lines)
            {
                var parts = line.Split(',');
                if (parts.Length == 8)
                {
                    Contacts c = new Contacts
                    {
                        Id = int.Parse(parts[0]),
                        FirstName = parts[1],
                        LastName = parts[2],
                        Address = parts[3],
                        ZipCode = parts[4],
                        City = parts[5],
                        PhoneNumber = parts[6],
                        Email = parts[7],
                    };
                    contacts.Add(c);
                }
            }
        }

        // METHOD TO SAVE CONTACTS TO Contacts.txt FILE
        public void SaveContactsToFile()
        {
            File.WriteAllLines(
                "Contacts.txt",
                contacts.Select(c =>
                    $"{c.Id},{c.FirstName},{c.LastName},{c.Address},{c.ZipCode},{c.City},{c.PhoneNumber},{c.Email}"
                )
            );
        }
    }
}