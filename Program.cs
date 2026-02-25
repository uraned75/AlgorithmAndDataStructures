namespace GuessTheNumber
{
    internal class Program
    {
        /// <summary>
        /// Выводит информацию о наименьшем, наибольшем и среднем числе листа
        /// </summary>
        /// <param name="userGuesses">Целочисленный лист, из которого надо получить информацию</param>
        static void DataAnalyzer(List<int> userGuesses)
        {
            Console.WriteLine($"Your lowest guess - {userGuesses.Min()}, Your highest guess - {userGuesses.Max()}, Your average guess - {userGuesses.Average()}");
        }
        /// <summary>
        /// Введение/меню выбора количества попыток
        /// </summary>
        /// <param name="gameCount">Показывает какая сессия на данный момент </param>
        /// <returns>Количество попыток указанных пользователем</returns>
        static int GameIntro(int gameCount)
        {
            int attempts;

            Console.WriteLine($"Hello Jeremy.\nIt is time for a game. The guessing game. Current Game count is {gameCount}\n");
            Console.WriteLine("How many attempts do you want, Jeremy?");
            if (!int.TryParse(Console.ReadLine(), out attempts) || (attempts < 1))
            {
                Console.WriteLine("ARE YOU TO STUPID TO EVEN INPUT CORRECT NUMBER OF ATTEMPTS?");
                GameIntro(gameCount);
            }
            Console.WriteLine($"You have {attempts} attempts, Jeremy.\nIf you won't guess the number in the alloted amount," +
                "you'll have less than ideal experience.");
            return attempts;
        }
        /// <summary>
        /// Тело игры/ Проверка загаданного пользователем числа
        /// </summary>
        /// <param name="attempts">Количество попыток указанных пользователем</param>
        /// <returns>Лист со всеми загаданными числами пользователем</returns>
        static List<int> TheCycleClass(int attempts)
        {
            Random rnd = new Random();
            int currentNum;
            List<int> usersGuesses = new List<int>();
            bool wonFlag = false;

            int randomNum = rnd.Next(1, 101);
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
                    usersGuesses.Add(currentNum);
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
                        Console.WriteLine("YOU WON, JEREMY. I'M PROUD OF YOU.\n");
                        wonFlag = true;
                        break;
                    }
                }
            }
            if (!wonFlag)
            {
                Console.WriteLine("YOU ARE AN IMBECILE, JEREMY. PRAY GOOD BYE TO YOUR PENSION PLAN!");
            }
            return usersGuesses;
        }
        /// <summary>
        /// Проверка на то если пользователь хочет продолжать игру
        /// </summary>
        /// <returns>Возвращает булевое значение хочет ли пользователь продолжать игру</returns>
        static bool Repeat()
        {
            char exitKey;
            bool toRepeat = false;

            Console.WriteLine("Do you want to try again, Jeremy? Press 'Y' to try again or press any other button to quit.");

            exitKey = Console.ReadLine().ToLower().FirstOrDefault();

            if (exitKey == 'y')
                return toRepeat = true;
            return toRepeat;
        }
        static void Main(string[] args)
        {
            int gameCount = 1;
            int attempts;
            bool repeatFlag = false;
            List<int> userGuesses = new List<int>();

            do
            {
                Console.WriteLine("--------------------------------------------------------------");
                attempts = GameIntro(gameCount);
                userGuesses = TheCycleClass(attempts);
                DataAnalyzer(userGuesses);
                Console.WriteLine("--------------------------------------------------------------");
                repeatFlag = Repeat();
                gameCount++;
            }
            while (repeatFlag);

            Console.WriteLine("You quit the game");
        }
    }
}
