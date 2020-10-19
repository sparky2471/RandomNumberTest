using System;

namespace RandomNumberTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Random Number Guessing Game");

            int randomNumber = new Random().Next(1, 100);
            int userGuess;
            int countUserGuess = 0;
            Boolean userWin = false;

            void startGame()
            {
                while (countUserGuess != 10 && userWin != true)
                {
                    Console.WriteLine("Please enter a number between 1 and 100!");

                    countUserGuess++;

                    var userInput = Console.ReadLine();


                    //Helper function to validate that the user's input is a number.
                    Boolean validateInput(String user)
                    {
                        if (int.TryParse(userInput, out userGuess))
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }

                    //Helper function to determine whether the user won or lost the game
                    String evaluateAnswer()
                    {
                        if (userGuess == randomNumber)
                        {
                            userWin = true;
                            return $"Congratulation YOU WON!!!";
                        }
                        else if (countUserGuess == 10)
                        {
                            return $"YOU LOSE!!! The number is { randomNumber }";
                        }
                        else
                        {
                            if (userGuess < randomNumber)
                            {
                                return $"Your guess was too low: Guess a number higher than { userGuess }";
                            }
                            else
                            {
                                return $"Your guess was too high: Guess a number lower than { userGuess }";
                            }
                        }
                    }

                    if (validateInput(userInput))
                    {
                        Console.WriteLine(evaluateAnswer());
                    }
                    else
                    {
                        Console.WriteLine("Your entry is not a valid number. You lose a turn!");
                    }

                }
            }

            Boolean tryGameAgain()
            {
                Console.WriteLine("Do you want to play again? Y for yes, N for No");
                userWin = false;
                countUserGuess = 0;

                if (Console.ReadKey().Key == ConsoleKey.Y)
                {
                    return true;
                }
                else return false;

            }

            while (tryGameAgain())
            {
                startGame();
                tryGameAgain();
            }
        }
    }
}