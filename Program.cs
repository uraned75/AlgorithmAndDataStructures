namespace GuessTheNumber
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Игра угадай число
            Random rnd = new Random();
            int attempts = 7;
            int currentNum = -1;
            bool wonFlag = false;
            bool leaveFlag = false;
            int min = 0;
            int max = 0;
            int gameCount = 1;
            char exitKey = 'n';
            do
            {
                int randomNum = rnd.Next(1, 101);
                Console.WriteLine("Hello Jeremy.\nIt is time for a game. The guessing game.\n" + $"It's your {gameCount} game");
                Console.WriteLine("How many attempts do you want, Jeremy?");
                if (!int.TryParse(Console.ReadLine(), out attempts) || (attempts < 1))
                {
                    Console.WriteLine("FUCK YOU, JEREMY. YOU ARE TO STUPID TO EVEN INPUT CORRECT NUMBER OF ATTEMPTS.");
                    return;
                }
                Console.WriteLine($"You have {attempts} attempts, Jeremy.\nIf you won't guess the number in the alloted amount," +
                    "you'll have less than ideal experience.");
                Console.WriteLine("Write an number between 1 and 100, Jeremy");
                for (int i = 0; i < attempts; i++)
                {
                    if (!int.TryParse(Console.ReadLine(), out currentNum) || (currentNum < 1 || currentNum > 100))
                    {
                        Console.WriteLine("JEREMY! YOU IDIOT! I TOLD YOU TO WRITE A NUMBER BETWEEN 1 AND A 100. TRY AGAIN.");
                        continue;
                    }
                    else
                    {
                        if (currentNum < randomNum)
                        {
                            Console.WriteLine("Your number is lesser than the guessed number");
                        }
                        else if (currentNum > randomNum)
                        {
                            Console.WriteLine("Your number is greater than the guessed number");
                        }
                        else
                        {
                            Console.WriteLine("YOU WON, JEREMY. I'M PROUD OF YOU.");
                            wonFlag = true;
                            break;
                        }
                    }
                }
                if (!wonFlag)
                {
                    Console.WriteLine("YOU ARE AN IMBECILE, JEREMY. PRAY GOOD BYE TO YOUR PENSION PLAN!");
                }
                Console.WriteLine("Do you want to try again, Jeremy?");

                exitKey = (char)Console.Read();

                if (exitKey == 'y')
                {
                    leaveFlag = true;
                    gameCount++;
                }
            }
            while (leaveFlag);
        }
    }
}
