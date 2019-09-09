/************************************
 * Name: Guessing Number Game
 * Author: Cherif Ouedraogo
 * Date: September 1st,2019
 * **********************************/
using System;

namespace Guess_Number_Game
{
    class Program
    {
        static void Main(string[] args)
        {
            bool main = true;
            while (main ==true)
            {
                start:
                bool run = true;
                while (run == true)
                {
                    Console.WriteLine("WELCOME TO GUESS MY NUMBER GAME! Who is playing? : ");
                    Console.Write("Enter 0 for User or 1 for Computer\n: ");
                    int user_input;

                    if (!int.TryParse(Console.ReadLine(), out user_input))
                        user_input = 2;
                    if (user_input == 0)
                        User_Play();
                    else if (user_input == 1)
                        Compter_Play();
                    else
                        Console.WriteLine("Wrong Input!!! Choose between [0] and [1]");
                    run = false;
                }
                Console.WriteLine("Would you like to play again? :");
                Console.WriteLine(" Enter 0 to continue to play or 1 to EXIT : ");
                int input; 
                if (!int.TryParse(Console.ReadLine(), out input))
                    input = 2;
                if(input==0)
                    goto start;
                else if (input == 1)
                    main = false;
            }
        }

        public static void Compter_Play()
        {
            Console.WriteLine("*****Welcome to Guess My Number Game: Computer's Play !*****");
            Console.WriteLine();
            Console.WriteLine("Please choose a number between 0 - 100 and let the Computer guess it: ");
            int computer_guess = 50;
            int min = 0;
            int max = 100;
            int count = 0;
            while (true)
            {
                count++;
                Console.WriteLine($"\nComputer guessed you entered [{computer_guess}]. Is it your number? ");
                Console.Write("Enter 0 if \"Correct\", 1 if \"Low\" or 2 if \"High\": ");
                int user_input;

                if (!int.TryParse(Console.ReadLine(), out user_input))
                    user_input = 3;

                if (user_input == 0)
                    break;
                else if (user_input == 1)
                {
                    min = computer_guess;
                    computer_guess += (max - computer_guess) / 2;
                }
                else if (user_input == 2)
                {
                    max = computer_guess;
                    computer_guess -= (computer_guess - min) / 2;
                }
                else
                    Console.WriteLine("Wrong input please try again!!!");
            }
            Console.WriteLine();
            Console.WriteLine($"The Computer guessed your number in {count} tries");
            Console.WriteLine();
            Console.WriteLine("Thank you for playing [GUESS MY NUMBER] with the computer. Press Any Key to continue...");
            Console.ReadLine();
        }
        public static void User_Play()
        {
            Console.WriteLine("*****Welcome to Guess My Number Game: User's Play !*****");
            Console.WriteLine();
            Random rand = new Random();
            int computer_number = rand.Next(0, 1000);
            int min = 0;
            int max = 1000;
            int count = 0;
            bool run = true;
            while (run == true)
            {
                count++;
                Console.WriteLine("Please choose a number between 0 - 1000 and try to guess the Computer's number: ");
                int user_guess ;
                if (!int.TryParse(Console.ReadLine(), out user_guess))
                    user_guess = 4 ;

                if (computer_number == user_guess)
                {
                    Console.WriteLine($" User Guessed Computer number in {count} tries !");
                    break;
                }
                else if (computer_number > user_guess)
                {
                    Console.WriteLine(" User guess is too low! ");
                    min = user_guess + 1;
                    continue;
                }
                else if (computer_number < user_guess)
                {
                    Console.WriteLine(" User guess is too High! ");
                    max = user_guess - 1;
                    continue;
                }
                else
                    Console.WriteLine("Wrong input please try again!!!");

                user_guess = (max - min) / 2;

                run = false;
            }
            Console.WriteLine();
            Console.WriteLine("Thank you for playing [GUESS MY NUMBER] against the computer. Good Bye!!!");
        }
    }
}
