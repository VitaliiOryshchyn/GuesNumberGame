using System;

namespace GuesNumberGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("You and robot have 5 try to gues a number");
            Console.WriteLine("Please enter number game:\n1) Human game(You must gues number of robots);\n2) Machine game(Robots try to gues your number);");
            int number;
            try
            {
                number = Convert.ToInt32(Console.ReadLine());

                switch (number)
                {
                    case 1:
                        LogicGuesGame gameHUman = new LogicGuesGame(GuessPlayer.Human);
                        Console.WriteLine();
                        gameHUman.Start();
                        break;
                    case 2:
                        LogicGuesGame gameMachine = new LogicGuesGame(GuessPlayer.Machine);
                        Console.WriteLine();
                        gameMachine.Start();
                        break;
                    default:
                        Console.WriteLine("Select correct number for a game");
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
