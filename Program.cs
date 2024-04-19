using System;
using System.Threading.Tasks;

namespace MobileProgramming
{
    public class Game
    {
        private int _x;
        private int _y;
        private char[,] map = new char[7, 7];
        private bool hiltCollected = false;
        private bool crossCollected = false;
        private bool bladeCollected = false;
        private int attemptsLeft = 2;
        private bool askedToCombine = false;


        public Game()
        {
            InitializeMap();
            _x = 3;
            _y = 3;
            map[_x, _y] = 'X';
            PrintMap();
            Move();
        }

        private void InitializeMap()
        {
            for (int i = 0; i < 7; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    map[i, j] = '.';
                }
            }
        }

        private void PrintMap()
        {
            Console.WriteLine("   0 1 2 3 4 5 6");
            for (int i = 0; i < 7; i++)
            {
                Console.Write(i + "  ");
                for (int j = 0; j < 7; j++)
                {
                    Console.Write(map[i, j] + " ");
                }
                Console.WriteLine();
            }
            if (_x == 3 && _y == 3)
            {
                Console.WriteLine("\nEilhart");
                if (hiltCollected && crossCollected && bladeCollected && !askedToCombine)
                {
                    Console.WriteLine("You have collected all three items. Would you like to combine them?");
                    Console.WriteLine("1. Yes");
                    Console.WriteLine("2. No");
                    int choice;
                    if (int.TryParse(Console.ReadLine(), out choice) && choice == 1)
                    {
                        CombineItemsAsync().GetAwaiter().GetResult();
                    }
                    else
                    {
                        Console.WriteLine("There is no way to defeat the Dragon without Excalibur.(Press R to reset game)");
                    }
                    askedToCombine = true;
                }
            }
            if (_x == 0 && _y == 3)
            {
                Console.WriteLine("\nEge Castle");
                if (hiltCollected && crossCollected && bladeCollected)
                {
                    Console.WriteLine("You have defeated the dragon and saved the kingdom!");
                    Console.WriteLine("Congratulations! You won the game.");
                    return;
                }
                else
                {
                    Console.WriteLine("You are not ready to face the dragon, forge Excalibur again and come like that.");
                }
            }
            if (_x == 5 && _y == 0 && !hiltCollected)
            {
                Console.WriteLine("\nRed Wizard");
                GetHilt();
            }
            if (_x == 2 && _y == 6 && !crossCollected)
            {
                Console.WriteLine("\nBlack Wizard");
                GetCross();
            }
            if (_x == 6 && _y == 6 && !bladeCollected)
            {
                Console.WriteLine("\nWhite Wizard");
                GetBlade();
            }
        }

        private void GetHilt()
        {
            Console.WriteLine("Riddle 1: What has keys but can't open locks?");
            Console.WriteLine("1. Piano");
            Console.WriteLine("2. Banana");
            Console.WriteLine("3. Chest");
            Console.WriteLine("4. Book");

            int correctAnswer = 1;

            HandleRiddle(correctAnswer, new Hilt());
        }

        private void GetCross()
        {
            Console.WriteLine("Riddle 2: I’m tall when I’m young, and I’m short when I’m old. What am I?");
            Console.WriteLine("1. Tree");
            Console.WriteLine("2. Pencil");
            Console.WriteLine("3. Candle");
            Console.WriteLine("4. Fish");

            int correctAnswer = 3;

            HandleRiddle(correctAnswer, new Cross());
        }

        private void GetBlade()
        {
            Console.WriteLine("Riddle 3: What has a head, a tail, is brown, and has no legs?");
            Console.WriteLine("1. Coin");
            Console.WriteLine("2. Snake");
            Console.WriteLine("3. Bear");
            Console.WriteLine("4. Table");

            int correctAnswer = 1;

            HandleRiddle(correctAnswer, new Blade());
        }


        private void HandleRiddle(int correctAnswer, Item item)
        {
            while (attemptsLeft > 0)
            {
                Console.WriteLine($"You have {attemptsLeft} attempts left.");

                int chosenAnswer;
                if (int.TryParse(Console.ReadLine(), out chosenAnswer) && chosenAnswer == correctAnswer)
                {
                    Console.WriteLine($"Correct! You've collected the {item.Name}.");
                    UpdateCollectedStatus(item.Name);
                    return;
                }
                else
                {
                    Console.WriteLine("Incorrect answer. Try again.");
                    attemptsLeft--;
                }
            }

            Console.WriteLine("You've run out of attempts. Returning to the starting point.");
            ResetGame();
        }


        private void UpdateCollectedStatus(string item)
        {
            switch (item)
            {
                case "Hilt":
                    hiltCollected = true;
                    break;
                case "Cross":
                    crossCollected = true;
                    break;
                case "Blade":
                    bladeCollected = true;
                    break;
            }
        }

        private void ResetGame()
        {
            hiltCollected = false;
            crossCollected = false;
            bladeCollected = false;
            attemptsLeft = 2;
            Console.WriteLine("Game reset.");
        }

        private async Task CombineItemsAsync()
        {
            Console.WriteLine("Combining items...");
            await Task.Delay(2000);

            Console.WriteLine("You have combined the Hilt, Cross, and Blade into Excalibur!");
            Console.WriteLine("Now go to the Ege Castle and save us from the dragon");
        }

        private void Move()
        {
            while (true)
            {
                ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                switch (keyInfo.Key)
                {
                    case ConsoleKey.W:
                        if (_x > 0)
                        {
                            map[_x, _y] = '.';
                            _x--;
                            map[_x, _y] = 'X';
                        }
                        break;
                    case ConsoleKey.A:
                        if (_y > 0)
                        {
                            map[_x, _y] = '.';
                            _y--;
                            map[_x, _y] = 'X';
                        }
                        break;
                    case ConsoleKey.S:
                        if (_x < 6)
                        {
                            map[_x, _y] = '.';
                            _x++;
                            map[_x, _y] = 'X';
                        }
                        break;
                    case ConsoleKey.D:
                        if (_y < 6)
                        {
                            map[_x, _y] = '.';
                            _y++;
                            map[_x, _y] = 'X';
                        }
                        break;
                    case ConsoleKey.R:
                        ResetGame();
                        break;
                    case ConsoleKey.Escape:
                        return;
                }
                Console.Clear();
                PrintMap();
            }
        }
    }
}
