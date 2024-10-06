namespace BankAccount
{
public abstract class BankAccount
{
    public string AccountNumber { get; set; }
    public string AccountHolder { get; set; }
    public int Balance { get; set; }
    
    //Konstruktor för att igemensamma kontouppgifter.
    public BankAccount(string accountNumber, string accountHolder, int balance)
    {
        AccountNumber = accountNumber;
        AccountHolder = accountHolder;
        Balance = balance;
    }

    //Abstrakta metoder för insättning och uttag
    public abstract void Deposit(int amount); 
    public abstract bool Withdraw(int amount);
}

public class PersonalAccount : BankAccount
{
    public PersonalAccount(string accountNumber, string accountHolder, int balance) : base(accountNumber, accountHolder, balance)
    {
    //     this.AccountNumber = accountNumber;
    //     this.AccountHolder = accountHolder;
    //    this.Balance = balance;
    }

    //Metod för insättning
    public override void Deposit(int amount)
    {
        Balance += (int)amount;
        Console.WriteLine($"Du har gjort en insättning på: {amount}SEK till {AccountHolder}'s person konto.");
    }

    //Metod för uttag
    public override bool Withdraw(int amount)
    {
       if (amount > Balance)
        {
            Console.WriteLine("Det finns inte tillräckligt med pengar i ditt person konto.");
            return false;
        }
        Balance -= amount;
        Console.WriteLine($"Du har tagit ut: {amount}SEK från {AccountHolder}'s person konto.");
        return true;
    }
}
}