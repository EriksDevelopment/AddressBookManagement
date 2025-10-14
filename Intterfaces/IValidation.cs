namespace AddressBook.Intterfaces
{
    public interface IValidation
    {
        void ValidationResult();
        void ValidationOnlyNumbersAllowedMessage();
        void ValidationNoEmptyFieldsAllowedMessage();
        void ValidationNoNumbersAllowedMessage();
        void ThreadSleepMethod();
    }
}
