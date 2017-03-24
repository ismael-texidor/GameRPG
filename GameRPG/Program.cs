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
        static Coordinate CornerScreenCoordinate {get; set;}
        static Player Player = new Player();
        static Boss Boss = new Boss();
        static Gun Gun = new Gun();
        static Sword Sword = new Sword();
        static TextBox PlayerTextBox = new TextBox();
        static Text Text = new Text();

        static void Main(string[] args)
        {
            var done = false;
            while (!done)
            {
                try
                {
                    var game = new Game();
                    done = game.StartGame();
                }
                catch (Exception e)
                {
                    if (e is ArgumentOutOfRangeException)
                    {
                        Console.Clear();
                        Console.Write("The screen console is too small! Maximize you console Screen and press any key");
                        Console.ReadKey();
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Um, this is akward, I don't know what went wrong!");
                        Console.WriteLine("Do you want to play again? Press Y for yes, and N for no");
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