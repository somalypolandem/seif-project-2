using System;
using static System.Console;

namespace TicTacToe3
{
    class Program
    {
        static void Main(string[] args)
        {
                Start:
                Console.Clear();
                Console.WriteLine("TIC TAC TOE");

                Console.WriteLine("\t1 - New Game");
                Console.WriteLine("\t2 - About the author");
                Console.WriteLine("\t3 - Quit");
                string input = Console.ReadLine();



                if (input == "1")
                {
                    Console.Clear();
                    Game();
                }



                if (input == "2")
                {
                  Console.Clear();
                  Console.WriteLine("Andrelouiz is the creator of the Tic Tac Toe game. It took him 20 years to write all the code.");
                  Console.WriteLine();
                  Console.WriteLine("Press enter to continue or any key to exit...");
    
                  ConsoleKeyInfo keyPressed = ReadKey();

                     if (keyPressed.Key == ConsoleKey.Enter)
                     {
                       goto Start;
                     }
                     else
                     {
                        Console.WriteLine("Press Enter to continue.");
                     }
                        Console.WriteLine("Press any key to exit.");
                        ReadKey(true);

            }

                if (input == "3")
                {
                    Console.WriteLine("Exit? y/n");
                    string exitProgram = (Console.ReadLine());
                    if (exitProgram == "y")
                    {
                        System.Environment.Exit(1);
                    }
                    else
                    {
                      goto Start;
                    }

                }

        }


        static void Game()
        {
            int gameStatus = 0;
            int currentPlayer = -1;
            char[] Slots = { '1', '2', '3', '4', '5', '6', '7', '8', '9' };

            do
            {
                Console.Clear();

                currentPlayer = GetNextPlayer(currentPlayer);

                HeadsUpDisplay(currentPlayer);
                DrawGameboard(Slots);

                GameEngine(Slots, currentPlayer);

               
                gameStatus = CheckWinner(Slots);

            } while (gameStatus.Equals(0));

            Console.Clear();
            HeadsUpDisplay(currentPlayer);
            DrawGameboard(Slots);

            if (gameStatus.Equals(1))
            {
                Console.WriteLine($"Player {currentPlayer} has won!");
                Console.WriteLine();

                Console.WriteLine("Press enter to continue or any key to exit.");
                ConsoleKeyInfo keyPressed = ReadKey();

                if (keyPressed.Key == ConsoleKey.Enter)
                {
                    Game();
                }
                else
                {
                    Console.WriteLine("Press Enter to continue.");
                }
                Console.WriteLine("Press any key to exit.");
                ReadKey(true);
            }

            if (gameStatus.Equals(2))
            {
                Console.WriteLine($"The game is a draw!");
                Game();
            }
        }

        private static int CheckWinner(char[] Slots)
        {
            if (IsGameDraw(Slots))
            {
                return 2;
            }

            if (IsGameWinner(Slots))
            {
                return 1;
            }

            return 0;
        }

        private static bool IsGameDraw(char[] Slots)
        {
            return Slots[0] != '1' &&
                   Slots[1] != '2' &&
                   Slots[2] != '3' &&
                   Slots[3] != '4' &&
                   Slots[4] != '5' &&
                   Slots[5] != '6' &&
                   Slots[6] != '7' &&
                   Slots[7] != '8' &&
                   Slots[8] != '9';
        }

        private static bool IsGameWinner(char[] Slots)
        {
            if (SameSlot(Slots, 0, 1, 2))
            {
                return true;
            }

            if (SameSlot(Slots, 3, 4, 5))
            {
                return true;
            }

            if (SameSlot(Slots, 6, 7, 8))
            {
                return true;
            }

            if (SameSlot(Slots, 0, 3, 6))
            {
                return true;
            }

            if (SameSlot(Slots, 1, 4, 7))
            {
                return true;
            }

            if (SameSlot(Slots, 2, 5, 8))
            {
                return true;
            }

            if (SameSlot(Slots, 0, 4, 8))
            {
                return true;
            }

            if (SameSlot(Slots, 2, 4, 6))
            {
                return true;
            }

            return false;
        }

        private static bool SameSlot(char[] testSlots, int pos1, int pos2, int pos3)
        {
            return testSlots[pos1].Equals(testSlots[pos2]) && testSlots[pos2].Equals(testSlots[pos3]);
        }

        private static void GameEngine(char[] Slots, int currentPlayer)
        {
            bool notValidMove = true;

            do
            {
                string userInput = Console.ReadLine();

                if (!string.IsNullOrEmpty(userInput) &&
                    (userInput.Equals("1") ||
                    userInput.Equals("2") ||
                    userInput.Equals("3") ||
                    userInput.Equals("4") ||
                    userInput.Equals("5") ||
                    userInput.Equals("6") ||
                    userInput.Equals("7") ||
                    userInput.Equals("8") ||
                    userInput.Equals("9")))
                {

                    int.TryParse(userInput, out var gamePlacementMarker);

                    char currentMarker = Slots[gamePlacementMarker - 1];

                    if (currentMarker.Equals('X') || currentMarker.Equals('O'))
                    {
                        Console.WriteLine("Spot already taken, choose a different one.");
                    }
                    else
                    {
                        Slots[gamePlacementMarker - 1] = GetPlayerMarker(currentPlayer);

                        notValidMove = false;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid move, try again.");
                }
            } while (notValidMove);
        }

        private static char GetPlayerMarker(int player)
        {
            if (player % 2 == 0)
            {
                return 'O';
            }

            return 'X';
        }

        static void HeadsUpDisplay(int PlayerNumber)
        { 

            Console.WriteLine("Player 1: X");
            Console.WriteLine("Player 2: O");
            Console.WriteLine();
            Console.WriteLine();
           
        }

        static void DrawGameboard(char[] Slots)
        {
            

            Console.WriteLine($" {Slots[0]} | {Slots[1]} | {Slots[2]} ");
            Console.WriteLine("---+---+---");
            Console.WriteLine($" {Slots[3]} | {Slots[4]} | {Slots[5]} ");
            Console.WriteLine("---+---+---");
            Console.WriteLine($" {Slots[6]} | {Slots[7]} | {Slots[8]} ");
        }

        static int GetNextPlayer(int player)
        {
            if (player.Equals(1))
            {
                return 2;
            }

            return 1;
        }

    }


}