using System;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using GameRPG.DrawingObjects;

namespace GameRPG
{
    class Program
    {
        static void Main(string[] args)
        {
            var done = false;
            while (!done)
            {
                //If this error happens more than once, 
                //the user probably needs to change some 
                //properties settings in the command prompt. 
                var argumentOutOfRange = 0;
                try
                {
                    Console.SetWindowSize(120, 35);
                    var game = new Game();
                    done = game.StartGame();
                    if(done)
                    {
                        Console.Clear();
                        Console.WriteLine("Do you want to play again? Press Y for yes, and N for no.");
                        done = true;
                        var readKey = Console.ReadKey().Key;
                        if (readKey == ConsoleKey.Y)
                        {
                            done = false;
                        }
                    }
                }
                catch (Exception e)
                {
                    if (e is ArgumentOutOfRangeException)
                    {
                        if (argumentOutOfRange > 0)
                        {
                            Console.WriteLine("One the following things happened:");
                            Console.WriteLine("1. You talked about fight club");
                            Console.WriteLine("2. Why did you break rules 1 and 2?!");
                            Console.WriteLine("3. Ok, the real list starts below");
                            Console.WriteLine("3. You're messing around with console window size! STOP IT!");
                            Console.WriteLine("4. You didn't maximize the screen as instructed! DO IT!");
                            Console.WriteLine("5. If none of the above worked, see below.");
                            Console.WriteLine("Take a look at https://www.howtogeek.com/howto/19982/how-to-make-the-windows-command-prompt-wider/");
                            Console.WriteLine("Change Window Size Width to 120 and Height to 35");
                        }
                        argumentOutOfRange++;
                        Console.Clear();
                        Console.Write("The screen console is too small! Please maximize your console screen and press any key.");
                        Console.ReadKey();
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Um, this is akward, I don't know what went wrong!");
                        Console.WriteLine("Do you want to play again? Press Y for yes, and N for no.");
                        done = true;
                        var readKey = Console.ReadKey().Key;
                        if (readKey == ConsoleKey.Y)
                        {
                            done = false;
                        }
                    }
                }
            }
        }
    }
}