namespace AddressBook.Models
{
    public class Contacts
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string ZipCode { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;

        public override string ToString()
        {
            return $"\n[{Id}] {FirstName} {LastName}, {Address}, {ZipCode} {City}, {PhoneNumber}, {Email}";
        }
    }
}
