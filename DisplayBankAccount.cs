namespace BankAccount
{
    public class DisplayBankAccount
    {
    
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
                    Console.WriteLine("Insättning");
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


        
    }
}
