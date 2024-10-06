namespace BankAccount
{
    public class DisplayBankAccount
    {
        PersonalAccount personalAccount = new PersonalAccount("123456789", "Kalle Anka", 1000);


    public void Run()  //Metod som håller applikationen igång och behandlar användarens val
    {
        bool running = true;
        while (running)
        {
            Console.WriteLine("\nBank System Meny:");
            Console.WriteLine("1. Kolla saldo");
            Console.WriteLine("2. Insättning");
            Console.WriteLine("3. Uttag");
            Console.WriteLine("4. Överföring");
            Console.WriteLine("5. Exit/Avsluta");
            Console.Write("Select an option: ");

            string userInputChoice = Console.ReadLine()!;
            int userInputChoiceInt = int.Parse(userInputChoice);

            switch (userInputChoiceInt)
            {
                case 1:
                    CheckBalance(); // Metod för att kolla saldo
                    break;
                case 2:
                    UserDeposit(); // Metod för insättning
                    break;
                case 3:
                    UserWithdraw(); // Metod för uttag
                    break;
                case 4:
                    UserTransfer(); // Metod för överföring
                    break;
                case 5:
                    Console.WriteLine("Exit");
                    running = false;
                    break;
                default:
                    Console.WriteLine("Felaktigt val, försök igen.");
                    break;
            }
            System.Console.WriteLine("Vill du fortsätta? (J/N)");
            string continueChoice = Console.ReadLine()!;
            if (continueChoice.ToUpper() == "N")
            {
                running = false;
            }           
        }
    }

    private void CheckBalance() //Metod för att kolla saldo
    {
        Console.WriteLine("--Kolla saldo--");
        string accountNumber;
        BankAccount? account; 

        while (true)       //En while loop för att ge användaren möjlighet att ange ett giltigt kontonummer utan att bli utkastad vid första felförsöket.
        {
            Console.Write("Ange kontonummer: ");
            accountNumber = Console.ReadLine()!; 
        
            account = GetAccountByNumber(accountNumber);   //hämta kontot baserat på kontonumret

            if (account != null)    //Om *account* inte är LIKA MED Null, alltså om det finns ett konto med det kontonumret
            {
                break;  //kontot har hittats, och bryts ut ur loopen
            }
            else
            {
                Console.WriteLine("Finns inget konto med det kontonumret. Vänligen försök igen.");
            }
        }
         Console.WriteLine($"Saldot för kontohavaren, {account.AccountHolder} med kontonummret, {accountNumber}: {account.Balance} SEK");
    }


    private void UserDeposit()  //Metod för att hantera insättningar
    {
        Console.WriteLine("--Insättning--");
        string accountNumber;
        BankAccount? account; 

        while (true)
        {
            Console.Write("Ange kontonummer: ");
            accountNumber = Console.ReadLine()!; 
        
            account = GetAccountByNumber(accountNumber);   //hämta kontot baserat på kontonumret

            if (account != null) //Om *account* inte är LIKA MED Null, alltså om det finns ett konto med det kontonumret
            {
                break; //bryt ut ur loopen om kontot hittas och fortsätt med insättningen
            }
            else
            {
                Console.WriteLine("Finns inget konto med det kontonumret. Vänligen försök igen."); //Meddelande om felaktigt kontonummer
            }
        }
    
        Console.Write("Ange belopp som ska sättas in: ");     //läs in beloppet som ska sättas in
        string amount = Console.ReadLine()!;
        
        int amountInt = int.Parse(amount);     //Konvertera beloppet till ett heltal

        //HÄR görs insättningen
        if (amountInt > 0)
        { 
            account.UserDeposit(amountInt); //Utför insättningen
            Console.WriteLine($"Insättning av {amountInt}SEK är genomförd.");
        }
        else
        {
            Console.WriteLine("Ogiltigt belopp.");
        }     
    }

    
    private void UserWithdraw()   // Metod för att hantera uttag
    {
        Console.WriteLine("--Uttag--");
        string accountNumber;
        BankAccount? account; 

        while (true)
            {
                Console.Write("Ange kontonummer: ");
                accountNumber = Console.ReadLine()!; 
            
                account = GetAccountByNumber(accountNumber);   

                    if (account != null) 
                    {
                        break; 
                    }
                    else
                    {
                        Console.WriteLine("Finns inget konto med det kontonumret. Vänligen försök igen."); 
                    }
            }
    
        Console.Write("Ange belopp som ska tas ut: ");   
        string amount = Console.ReadLine()!;
        int amountInt = int.Parse(amount);    
   
            if (amountInt > 0)
            { 
                account.UserWithdraw(amountInt);
                Console.WriteLine($"Ditt uttag av {amountInt}SEK är genomförd.");
            }
            else
            {
                Console.WriteLine("Ogiltigt belopp.");
            }     
    }


    private void UserTransfer()     //Metod för att hantera överföringar
    {
        Console.WriteLine("--Överföring--");
        string fromAccountNumber;
        string toAccountNumber;
        BankAccount? fromAccount;
        BankAccount? toAccount;

        while (true) //hämta avsändarens konto  
            {
            Console.Write("Ange avsändarens kontonummer: ");
            fromAccountNumber = Console.ReadLine()!;
            fromAccount = GetAccountByNumber(fromAccountNumber);

                    if (fromAccount != null) 
                    {
                        break; 
                    }
                    else
                    {
                        Console.WriteLine("Finns inget konto med det kontonumret. Vänligen försök igen."); 
                    }
            }

         while (true)  //hämta mottagarens konto
            {
                Console.Write("Ange mottagarens kontonummer: ");
                toAccountNumber = Console.ReadLine()!;
                toAccount = GetAccountByNumber(toAccountNumber);

                if (toAccount != null)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Finns inget konto med det kontonumret. Vänligen försök igen.");
                }
            }
    
        Console.Write("Ange belopp som ska överföras: ");   
        string amountInput = Console.ReadLine()!;
        int amountInt = int.Parse(amountInput);    
   
        if (amountInt > 0)
        { 
            if (fromAccount.UserWithdraw(amountInt))
            {
                toAccount.UserDeposit(amountInt);
                Console.WriteLine($"Överförde {amountInt}SEK från konto {fromAccountNumber} till konto {toAccountNumber}.");
            }
            else
            {
                Console.WriteLine("Otillräckliga medel i dittt konto.");
            }
        }
        else
        {
            Console.WriteLine("Ogiltigt belopp.");
        }   
    }


    private BankAccount GetAccountByNumber(string accountNumber)     //Metod för att hämta konto med kontonummer
    {
        if (accountNumber == personalAccount.AccountNumber)     //Kontrollera om det angivna kontonumret matchar det personliga kontot
        {
            return personalAccount;
        }
        else
        {
            return null; // Om inget konto hittades, returnera null
        }
    }



    } //End of DisplayBankAccount!!
}
