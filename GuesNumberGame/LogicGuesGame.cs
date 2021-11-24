using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuesNumberGame
{

    public enum GuessPlayer
    {
        Human,
        Machine
    }

    class LogicGuesGame
    {

        public readonly int max;
        public readonly int maxTries;
        public readonly GuessPlayer guessPlayer;

        public LogicGuesGame(GuessPlayer guessPlayer, int max = 100, int maxTries = 5)
        {
            this.max = max;
            this.maxTries = maxTries;
            this.guessPlayer = guessPlayer;
        }

        public void Start()
        {
            if (guessPlayer == GuessPlayer.Human)
            {
                HumanGame();
            }
            else
            {
                MachineGame();
            }
        }

        public void HumanGame()
        {
            Random rand = new Random();
            int randomNumber = rand.Next(0, max);
            int numberPlayer;
            for (int i = 0; i <= maxTries; i++)
            {
                if (i == maxTries)
                {
                    Console.WriteLine("You lost");
                    Console.WriteLine($"It was a {randomNumber}");
                    break;
                }
                Console.Write("Maybe it's: ");
                numberPlayer = Convert.ToInt32(Console.ReadLine());
                if (numberPlayer == randomNumber)
                {
                    Console.WriteLine("You WIN");
                    break;
                }
                else if (numberPlayer < randomNumber)
                {
                    Console.WriteLine("You number less than mine");
                }
                else
                {
                    Console.WriteLine("You number greater than mine");
                }

            }


        }

        public void MachineGame()
        {
            Console.Write("What number does the robot need to guess?");


            int playerNumber = 0;
            bool positiveNumber = true;
            while (positiveNumber)
            {
                int unLocalVariable = Convert.ToInt32(Console.ReadLine());
                if (playerNumber >= 0 && playerNumber <= 100)
                {
                    playerNumber = unLocalVariable;
                    positiveNumber = false;
                }


            }
            Console.WriteLine();

            int min = 0;
            int max = this.max;
            int guessNumberMachine;


            for (int i = 0; i <= maxTries; i++)
            {

                if (i == maxTries)
                {
                    Console.WriteLine("Sorry, but you lost robot");
                    break;
                }
                guessNumberMachine = (min + max) / 2;
                Console.WriteLine($"Maybe you'r number is {guessNumberMachine}");
                Console.WriteLine("If yes enter \"y\". If number less then your enter \"L\". If your number greater then you enter \"G\"");
                Console.WriteLine();
                string answer = "";
                bool correctAnswer = true;
                while (correctAnswer)
                {
                    string localAnswer = Console.ReadLine().ToLower();
                    if (localAnswer == "y" || localAnswer == "l" || localAnswer == "g")
                    {
                        answer = localAnswer;
                        correctAnswer = false;
                    }
                }

                if (answer == "y")
                {
                    Console.WriteLine("Yes, it is number!");
                    break;
                }
                else if (answer == "l")
                {
                    max = guessNumberMachine;
                    Console.WriteLine("Less then your number robot;");
                    Console.WriteLine();
                }
                else if (answer == "g")
                {
                    min = guessNumberMachine;
                    Console.WriteLine("Greater then your number robot;");
                    Console.WriteLine();
                }

                if (playerNumber == guessNumberMachine)
                {
                    Console.WriteLine("I don't playing with you:(");
                    break;

                }
            }

        }
    }
}
