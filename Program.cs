namespace BankAccount
{  
internal class Program
{
    static void Main(string[] args)
    {   
        DisplayBankAccount displayBankAccount = new DisplayBankAccount();
        displayBankAccount.Run();

        PersonalAccount personalAccount = new PersonalAccount("123456789", "Kalle Anka", 1000);
        personalAccount.Deposit(500);
        personalAccount.Withdraw(2000);
        personalAccount.Withdraw(500);
    }










} //End of Program
} //End of namespace BankAccount