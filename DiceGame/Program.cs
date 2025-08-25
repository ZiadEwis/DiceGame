using System;

namespace DiceGame
{
    class Player
    {
        public string Name { get; private set; }
        public int Score { get; private set; }

        private Random random;

        public Player(string name, Random rand)
        {
            Name = name;
            Score = 0;
            random = rand;
        }

        public int RollDice()
        {
            int roll = random.Next(1, 7);
            Console.WriteLine($"{Name} rolled: {roll}");
            return roll;
        }

        public void AddPoint() => Score++;
    }

    class DiceGame
    {
        private Player user;
        private Player computer;
        private Random random;

        public DiceGame()
        {
            random = new Random();
            user = new Player("You", random);
            computer = new Player("Computer", random);
        }

        public void Play()
        {
            Console.WriteLine("🎲 Welcome to the Dice Game!");
            Console.WriteLine("Press any key to roll the dice, or press 'Q' to quit.\n");

            while(true)
            {
                ConsoleKeyInfo key = Console.ReadKey(true);
                if (key.Key == ConsoleKey.Q)
                {
                    ShowFinalScore();
                    break;
                }

                int userRoll = user.RollDice();
                int computerRoll = computer.RollDice();

                if (userRoll > computerRoll)
                {
                    user.AddPoint();
                    Console.WriteLine("👉 You win this round!");
                }
                else if (userRoll < computerRoll)
                {
                    computer.AddPoint();
                    Console.WriteLine("👉 Computer wins this round!");
                }
                else
                    Console.WriteLine("👉 It's a tie this round!");

                ShowScore();
                Console.WriteLine("\n🎲🎲🎲🎲🎲🎲🎲🎲🎲🎲🎲🎲🎲🎲🎲🎲🎲🎲🎲🎲🎲🎲🎲🎲🎲🎲🎲🎲🎲🎲\n");
                Console.WriteLine("Press any key to roll the dice, or press 'Q' to quit.\n");

            }

        }

        private void ShowScore() => Console.WriteLine($"Score: You {user.Score} - {computer.Score} Computer");

        private void ShowFinalScore()
        {
            Console.WriteLine("\nGame Over!");
            Console.WriteLine($"Final Score: You {user.Score} - {computer.Score} Computer");

            if (user.Score > computer.Score)
                Console.WriteLine("🎉 You Win!");
            else if (user.Score < computer.Score)
                Console.WriteLine("😢 Computer Wins!");
            else
                Console.WriteLine("🤝 It's a Draw!");
            Console.WriteLine("\n🎲🎲🎲🎲🎲🎲🎲🎲🎲🎲🎲🎲🎲🎲🎲🎲🎲🎲🎲🎲🎲🎲🎲🎲🎲🎲🎲🎲🎲🎲\n");
        }
    }

    class Program
    {
        static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            DiceGame game = new DiceGame();
            game.Play();
        }
    }
}