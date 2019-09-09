/*************************************
 * Name: Roulette_Game
 * Author: Cherif Ouedraogo
 * Date: August 30,2019
 * 
 * ***********************************/
using System;

namespace Roulette
{
    class Program
    {
        static void Main(string[] args)
        {
            bool run = true;
            while(run==true)
            {
                Console.WriteLine(" WELCOME TO THE ROULETTE GAME \n");

                string[] Positions ={ "0G-00G","1R","2B","3R", "4B", "5R", "6B", "7R","8B", "9R", "10B", "11B", "12R", "13B","14R",
                                   "15B","16R","17B","18R","19R","20B","21R","22B","23R","24B",
                                   "25R","26B","27R","28B","29B","30R","31B","32R","33B","34R","35B","36R", };
                start:
                Random generator = new Random();
                int number = generator.Next(0, 36);
                Console.WriteLine(" Enter [1] to Spin or [0] to Exit ");
                int user_input;

                if (!int.TryParse(Console.ReadLine(), out user_input))
                {
                    user_input = 3;
                }
                if (user_input == 1)
                {
                    GeneralBets(number, Positions);
                    ColumnsBets(number, Positions);
                    RowBets(number, Positions);
                    DoubleRowBets(number, Positions);
                    SplitBets(number, Positions);
                    CornerBets(number, Positions);
                }
                else if (user_input == 0)
                {
                    Console.WriteLine(" GoodBye!...\n ");
                    Exit();
                }
                else
                {
                    Console.WriteLine(" Invalid Input! Enter [1] or [0]\n");
                }

                Console.WriteLine("\n Would you like to play again? : Enter [1] to play again or [0] to Exit ");
                int input;

                if (!int.TryParse(Console.ReadLine(), out input))
                {
                    input = 3;
                }
                if(input==1)
                {
                    goto start;
                }
                else if(input==0)
                {
                    Console.WriteLine(" THANK YOU FOR PLAYING...\n ");
                    Exit();

                }
                else if( input!=1 && input !=0)
                {
                    Console.WriteLine(" Invalid Input! Enter [1] or [0]\n");
                }
                else
                {
                    run = false;
                }
               

            }

        }
        static void GeneralBets(int number, string[] Positions)
        {
           Console.WriteLine($" Your Winning Number is {Positions[number]}");
            if (number % 2 == 0)
            {
                Console.WriteLine($" You Win the Even Number");
            }
            else if (number % 2 == 1)
            {
                Console.WriteLine($" You Win the Odd Number");
            }

            if (Positions[number].Substring(Positions[number].Length - 1) == "R")
            {
                Console.WriteLine($" Your Winning Color is Red");
            }
            else if (Positions[number].Substring(Positions[number].Length - 1) == "B")
            {
                Console.WriteLine($" Your Winning Color is Black");
            }
            else
            {
                Console.WriteLine($" Your Winning Color is Green");
            }

           
            if (number <= 18)
            {
                Console.WriteLine($" You Win the Low Bet");
            }
            else
            {
                Console.WriteLine($" You Win the High Bet");
            }


            if (number >= 1 && number <= 12)
            {
                Console.WriteLine($" You Win the 1st Dozen");
            }
            else if (number >= 12 && number <= 24)
            {
                Console.WriteLine($" You Win the 2nd Dozen");
            }
            else if (number >= 25 && number <= 36)
            {
                Console.WriteLine($" You Win the 3rd Dozen");
            }

        }
        static void ColumnsBets(int number, string[] Positions)
        {
            int column = 0;
            for (int i = 0; i < 36; i += 3)
            {
                if (number == i + 1)
                {
                    column = 1;
                }
                else if (number == i + 2)
                {
                    column = 2;
                }
                else if (number == i + 3)
                {
                    column = 3;
                }
            }
            if (column > 0)
            {
                Console.WriteLine($" You Win the Number [{column}] Column Bet");
            }
        }
        static void RowBets(int number, string[] Positions)
        {
            for (int i = 0; i < 36; i += 3)
            {
                if (number == i + 1 || number == i + 2 || number == i + 3)
                {
                    Console.WriteLine($" Your Winning Row is {i + 1}/{i + 2}/{i + 3}");
                }
            }

        }
        static void DoubleRowBets(int number, string[] Positions)
        {
            for (int i = 0; i < 33; i += 3)
            {
                if (number == i + 1 || number == i + 2 || number == i + 3 || number == i + 4 || number == i + 5 || number == i + 6)
                {
                    Console.WriteLine($" Your Winning Double Row is {i + 1}/{i + 2}/{i + 3}/{i + 4}/{i + 5}/{i + 6}");
                }
            }
        }
        static void SplitBets(int number, string[] Positions)
        {
            for (int i = 0; i < 36; i += 3)
            {
                if (number == i + 1)
                {
                    Console.WriteLine($" You Win the Split Bet {number}/{number + 1}"); 
                }
                else if (number == i + 2)
                {
                    Console.WriteLine($" You Win the Split Bet {number}/{number + 1}");  
                    Console.WriteLine($" You Win the Split Bet {number - 1}/{number}"); 
                }
                else if (number == i + 3)
                {
                    Console.WriteLine($" You Win the Split Bet {number - 1}/{number}"); 
                }

            }

            if (number <= 3)
            {
                Console.WriteLine($" You Win the Split Bet {number}/{number + 3}"); 
            }
            else if (number >= 34)
            {
                Console.WriteLine($" You Win the Split Bet {number - 3}/{number}"); 
            }
            else if (number > 3 && number < 34)
            {

                Console.WriteLine($" You Win the Split Bet {number}/{number + 3}"); 
                Console.WriteLine($" You Win the Split Bet {number - 3}/{number}"); 
            }

        }
        static void CornerBets(int number, string[] Positions)
        {
            for (int i = 0; i < 36; i += 3)
            {
                if (number == i + 1)
                {
                    if (number <= 3)
                    {
                        Console.WriteLine($" Your Winning Corner Bet is {number}/{number + 1}/{number + 3}/{number + 4}");
                    }
                    else if (number >= 34)
                    {
                        Console.WriteLine($" Your Winning Corner Bet is {number}/{number + 1}/{number - 2}/{number - 3}");
                    }
                    else if (number > 3 && number < 34)
                    {
                        Console.WriteLine($" Your Winning Corner Bet is {number}/{number + 1}/{number + 3}/{number + 4}");
                        Console.WriteLine($" Your Winning Corner Bet is {number}/{number + 1}/{number - 2}/{number - 3}");
                    }
                }
                else if (number == i + 2)
                {
                    if (number <= 3)
                    {
                        Console.WriteLine($" Your Winning Corner Bet is {number}/{number + 1}/{number + 3}/{number + 4}");
                        Console.WriteLine($" Your Winning Corner Bet is {number}/{number - 1}/{number + 2}/{number + 3}");
                    }
                    else if (number >= 34)
                    {
                        Console.WriteLine($" Your Winning Corner Bet is {number}/{number + 1}/{number - 2}/{number - 3}");
                        Console.WriteLine($" Your Winning Corner Bet is {number}/{number - 1}/{number - 3}/{number - 4}");
                    }
                    else if (number > 3 && number < 34)
                    {
                        Console.WriteLine($" Your Winning Corner Bet is {number}/{number + 1}/{number + 3}/{number + 4}");
                        Console.WriteLine($" Your Winning Corner Bet is {number}/{number - 1}/{number + 2}/{number + 3}");
                        Console.WriteLine($" Your Winning Corner Bet is {number}/{number + 1}/{number - 2}/{number - 3}");
                        Console.WriteLine($" Your Winning Corner Bet is {number}/{number - 1}/{number - 3}/{number - 4}");
                    }
                }
                else if (number == i + 3)
                {
                    if (number <= 3)
                    {
                        Console.WriteLine($" Your Winning Corner Bet is {number}/{number - 1}/{number + 2}/{number + 3}");
                    }
                    else if (number >= 34)
                    {
                        Console.WriteLine($" Your Winning Corner Bet is {number}/{number - 1}/{number - 3}/{number - 4}");
                    }
                    else if (number > 3 && number < 34)
                    {
                        Console.WriteLine($" Your Winning Corner Bet is {number}/{number - 1}/{number - 3}/{number - 4}");
                        Console.WriteLine($" " +
                            $"Your Winning Corner Bet is {number}/{number - 1}/{number + 2}/{number + 3}");
                    }
                }

            }
           
        }
        static void Exit()
        {
            System.Environment.Exit(0);
        }
       
           
       

    }
}