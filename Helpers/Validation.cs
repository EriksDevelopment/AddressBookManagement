namespace AddressBook.Helpers
{
    public class Validation
    {
        public void ValidationResult(string message)
        {
            Console.WriteLine(message);
            this.ThreadSleepMethod();
        }
        public void ValidationOnlyNumbersAllowedMessage()
        {
            Console.WriteLine("Only numbers allowed!");
            this.ThreadSleepMethod();
        }
        public void ValidationNoEmptyFieldsAllowedMessage()
        {
            Console.WriteLine("No empty feilds allowed!");
            this.ThreadSleepMethod();
        }

        public void ValidationNoNumbersAllowedMessage()
        {
            Console.WriteLine("No numbers allowed!");
            this.ThreadSleepMethod();
        }

        private void ThreadSleepMethod()
        {
            Thread.Sleep(1000);
        }
    }
}
