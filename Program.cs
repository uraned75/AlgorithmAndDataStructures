namespace GuessTheNumber
{
    internal class Program
    {
        static int gameCount = 1;
        static int attempts = 0;
        static bool repeatFlag = false;
        static bool wonFlag = false;
        static List<int> userGuesses = new List<int>();
        static int leftRange = 1;
        static int rightRange = 100;

        public static int GetNumber()
        {
            int number;
            if (!int.TryParse(Console.ReadLine(), out number)){
                Console.WriteLine("You'll be stuck here until you'll write a correct number");
                int.TryParse(Console.ReadLine(), out number);
            }

            return number;
        }

        public static string CompareNumber(int currentNum, int randomNum)
        {
            if (currentNum < randomNum)
            {
                return "Your number is lesser than the guessed number";
            }
            else if (currentNum > randomNum)
            {
                return "Your number is greater than the guessed number";
            }
            else
            {
                return "YOU WON, JEREMY. I'M PROUD OF YOU.\n";
            }
        }
            /// <summary>
            /// Выводит информацию о наименьшем, наибольшем и среднем числе листа
            /// </summary>
            /// <param name="userGuesses">Целочисленный лист, из которого надо получить информацию</param>
            static void DataAnalyzer()
        {
            Console.WriteLine($"Your lowest guess - {userGuesses.Min()}, Your highest guess - {userGuesses.Max()}, Your average guess - {userGuesses.Average()}");
        }
        /// <summary>
        /// Введение/меню выбора количества попыток
        /// </summary>
        /// <param name="gameCount">Показывает какая сессия на данный момент </param>
        /// <returns>Количество попыток указанных пользователем</returns>
        static int StartGame()
        {

            Console.WriteLine($"Hello Jeremy.\nIt is time for a game. The guessing game. Current Game count is {gameCount}\n");
            Console.WriteLine("How many attempts do you want, Jeremy?");
            attempts = GetNumber();
            Console.WriteLine($"You have {attempts} attempts, Jeremy.\nIf you won't guess the number in the alloted amount," +
                "you'll have less than ideal experience.");
            return attempts;
        }
        /// <summary>
        /// Тело игры/ Проверка загаданного пользователем числа
        /// </summary>
        /// <param name="attempts">Количество попыток указанных пользователем</param>
        /// <returns>Лист со всеми загаданными числами пользователем</returns>
        static List<int> PlayGame()
        {
            Random rnd = new Random();
            int? currentNum;

            int randomNum = rnd.Next(leftRange, rightRange);
            Console.WriteLine($"Write an number between {leftRange} and {rightRange}, Jeremy");
            for (int i = 0; i < attempts; i++)
            {
                currentNum = GetNumber();
                Console.WriteLine(CompareNumber((int)currentNum, randomNum));
                userGuesses.Add(currentNum.Value);
                if (wonFlag) return userGuesses;
            }
            if (!wonFlag) Console.WriteLine("YOU ARE AN IMBECILE, JEREMY. PRAY GOOD BYE TO YOUR PENSION PLAN!");
            return userGuesses;
        }
        /// <summary>
        /// Проверка на то если пользователь хочет продолжать игру
        /// </summary>
        /// <returns>Возвращает булевое значение хочет ли пользователь продолжать игру</returns>
        static bool Repeat()
        {
            char exitKey;

            Console.WriteLine("Do you want to try again, Jeremy? Press 'Y' to try again or press any other button to quit.");

            exitKey = Console.ReadLine().ToLower().FirstOrDefault();

            if (exitKey == 'y')
                return repeatFlag = true;
            return repeatFlag;
        }
        static void Main(string[] args)
        {
            try
            {
                do
                {
                    repeatFlag = false;
                    wonFlag = false;
                    Console.WriteLine("--------------------------------------------------------------");
                    StartGame();
                    PlayGame();
                    DataAnalyzer();
                    Console.WriteLine("--------------------------------------------------------------");
                    Repeat();
                    gameCount++;
                }
                while (repeatFlag);

                Console.WriteLine("You quit the game");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
        }
    }
}
