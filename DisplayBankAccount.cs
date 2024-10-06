namespace BankAccount
{
    public class DisplayBankAccount
    {
        PersonalAccount personalAccount = new PersonalAccount("123456789", "Kalle Anka", 1000);


    public void Run()  // Metod som håller applikationen igång och behandlar användarens val
    {
        bool running = true;
        while (running)
        {
            Console.WriteLine("\nBank System Meny:");
            Console.WriteLine("1. Insättning");
            Console.WriteLine("2. Uttag");
            Console.WriteLine("3. Överföring");
            Console.WriteLine("4. Kolla saldo");
            Console.WriteLine("5. Exit/Avsluta");
            Console.Write("Select an option: ");

            string userInputChoice = Console.ReadLine()!;
            int userInputChoiceInt = int.Parse(userInputChoice);

            switch (userInputChoiceInt)
            {
                case 1:
                    Deposit(); // Metod för insättning
                    break;
                case 2:
                    Console.WriteLine("Withdraw");
                    break;
                case 3:
                    Console.WriteLine("Transfer");
                    break;
                case 4:
                    Console.WriteLine("Check Balance");
                    break;
                case 5:
                    Console.WriteLine("Exit");
                    running = false;
                    break;
                default:
                    Console.WriteLine("Felaktigt val, försök igen.");
                    break;
            }
        }
    }

    private void Deposit()
    {
        Console.WriteLine("--Insättning--");
        string accountNumber;
        BankAccount? account; 

    //En while loop för att ge användaren möjlighet att ange ett giltigt kontonummer utan att bli utkastad vid första felförsöket
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

        //HÄR ska insättningen göras
        if (amountInt > 0)
        { 
            account.Deposit(amountInt); //Utför insättningen
            Console.WriteLine($"Insättning av {amountInt} kr genomförd.");
        }
        else
        {
            Console.WriteLine("Ogiltigt belopp.");
        }     
    }
        //Metod för att hämta konto med kontonummer
        private BankAccount GetAccountByNumber(string accountNumber)
        {
            if (accountNumber == personalAccount.AccountNumber) //Kontrollera om det angivna kontonumret matchar det personliga kontot
            {
                return personalAccount;
            }
            else
            {
                return null; // Om inget konto hittades, returnera null
        }
    }
    }
}


    // Console.Write("Ange kontonummer: ");

    //     string accountNumber = Console.ReadLine()!;
    //     Console.Write("Ange belopp som ska sättas in: ");

    //     string amount = Console.ReadLine()!;
    //     int amountInt = int.Parse(amount);

    //  //Här ska insättningen göras
    //     if(amountInt > 0)
    //     { 
    //        BankAccount? account = GetAccountByNumber(accountNumber); //Hämtar konto(!) baserat på kontonummer
    //         if (account != null) //Om *account* inte är LIKA MED Null, alltså om det finns ett konto med det kontonumret
    //         {
    //             account.Deposit(amountInt); //Utför insättningen
    //              Console.WriteLine($"Insättning av {amountInt} kr genomförd.");
    //         }
    //         else
    //         {
    //             Console.WriteLine("Finns inget konto med det kontonumret.");    
    //         }
    //     }
    //     else
    //     {
    //         Console.WriteLine("Ogiltigt belopp.");
    //     }