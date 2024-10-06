namespace BankAccount
{
    public abstract class BankAccount
    {
        public string AccountNumber { get; set; }
        public string AccountHolder { get; set; }
        public int Balance { get; set; }
        
        public BankAccount(string accountNumber, string accountHolder, int balance)         //Konstruktor för att igemensamma kontouppgifter.

        {
            AccountNumber = accountNumber;
            AccountHolder = accountHolder;
            Balance = balance;
        }

        public abstract void UserDeposit(int amount);    //abstrakt metod för insättning
        public abstract bool UserWithdraw(int amount);  //och för uttag
    }


    public class PersonalAccount : BankAccount 
    {
        public PersonalAccount(string accountNumber, string accountHolder, int balance) 
        : base(accountNumber, accountHolder, balance)
        {
        }

        public override void UserDeposit(int amount) //Metod för insättning
        {
            Balance += (int)amount;
            Console.WriteLine($"Du har gjort en insättning på: {amount} SEK till {AccountHolder}'s person konto.");
        }

        public override bool UserWithdraw(int amount)   //Metod för uttag
        {
        if (amount > Balance)
            {
                Console.WriteLine("Det finns inte tillräckligt med pengar i ditt person konto.");
                return false;
            }
            Balance -= amount;
            Console.WriteLine($"Du har tagit ut: {amount} SEK från {AccountHolder}'s person konto.");
            return true;
        }
    }


    public class SavingsAccount : BankAccount
    {
        public SavingsAccount(string accountNumber, string accountHolder, int balance) 
        : base(accountNumber, accountHolder, balance)
        {
        }

        public override void UserDeposit(int amount)
        {
            Balance += amount;
            Console.WriteLine($"Du har gjort en insättning på: {amount} SEK till {AccountHolder}'s sparkonto.");
        }

        public override bool UserWithdraw(int amount)
        {
            if (amount > Balance)
            {
                Console.WriteLine("Det finns inte tillräckligt med pengar i sparkontot.");
                return false;
            }
            Balance -= amount;
            Console.WriteLine($"Du har tagit ut: {amount} SEK från {AccountHolder}'s sparkonto.");
            return true;
        }
    }


    public class InvestmentAccount : BankAccount    
    {
        public InvestmentAccount(string accountNumber, string accountHolder, int balance)
            : base(accountNumber, accountHolder, balance) { }

        public override void UserDeposit(int amount)
        {
            Balance += amount;
            Console.WriteLine($"Du har gjort en insättning på: {amount} SEK till {AccountHolder}'s investeringskonto.");
        }

        public override bool UserWithdraw(int amount)
        {
            if (amount > Balance)
            {
                Console.WriteLine("Det finns inte tillräckligt med pengar på investeringskontot.");
                return false;
            }
            Balance -= amount;
            Console.WriteLine($"Du har tagit ut: {amount} SEK från {AccountHolder}'s investeringskonto.");
            return true;
        }
    }
}