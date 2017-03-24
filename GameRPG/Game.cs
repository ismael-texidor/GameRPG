using System;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using GameRPG.DrawingObjects;

namespace GameRPG
{
    public class Game
    {
        static Coordinate CornerScreenCoordinate { get; set; }
        static Player Player = new Player();
        static Boss Boss = new Boss();
        static Gun Gun = new Gun();
        static Sword Sword = new Sword();
        static TextBox PlayerTextBox = new TextBox();
        static Text Text = new Text();

        public bool StartGame()
        {
            InitializeGame();
            ConsoleKeyInfo keyInfo;
            while ((keyInfo = Console.ReadKey(true)).Key != ConsoleKey.Escape)
            {
                switch (keyInfo.Key)
                {
                    //case ConsoleKey.UpArrow:
                    //    MoveAndDrawScreen(0, -1);
                    //    break;

                    //case ConsoleKey.DownArrow:
                    //    MoveAndDrawScreen(0, 1);
                    //    break;

                    //attack
                    case ConsoleKey.Spacebar:
                        IgnoreInputOnAMethod(AttackAnimation);
                        break;

                    //Gun Weapon 
                    case ConsoleKey.A:
                        Gun.ShouldDraw = true;
                        Sword.ShouldDraw = false;
                        DrawBossBattle();
                        break;

                    //Sword Weapon 
                    case ConsoleKey.S:
                        Gun.ShouldDraw = false;
                        Sword.ShouldDraw = true;
                        DrawBossBattle();
                        break;
                }
            }
            return true;
        }

        /// <summary>
        ///Create Boss Battle Drawings
        /// </summary>
        static void DrawBossBattle()
        {

            Coordinate playerCoordinate = new Coordinate()
            {
                X = Player.Placement.X,
                Y = Player.Placement.Y
            };

            Coordinate bossCoordinate = new Coordinate()
            {
                X = Boss.Placement.X,
                Y = Boss.Placement.Y
            };

            Coordinate gunCoordinate = new Coordinate()
            {
                X = Gun.Placement.X,
                Y = Gun.Placement.Y
            };

            Coordinate swordCoordinate = new Coordinate()
            {
                X = Sword.Placement.X,
                Y = Sword.Placement.Y
            };
            Coordinate playerTextBoxCoordinate = new Coordinate()
            {
                X = PlayerTextBox.Placement.X,
                Y = PlayerTextBox.Placement.Y
            };
            Coordinate textCoordinate = new Coordinate()
            {
                X = Text.Placement.X,
                Y = Text.Placement.Y
            };

            Coordinate cornerScreenCoordinate = new Coordinate()
            {
                X = CornerScreenCoordinate.X,
                Y = CornerScreenCoordinate.Y
            };

            //ClearScreen
            Console.Clear();

            //Draw the player.
            Player.DrawMe();
            //Draw the weapons.
            Gun.DrawMe();
            Sword.DrawMe();

            //Draw the boss.    
            Boss.DrawMe();

            //Draw TextBox and Text

            Console.SetCursorPosition(cornerScreenCoordinate.X, cornerScreenCoordinate.Y);
            Console.WriteLine("Spacebar to Attack.");
            Console.WriteLine("Press A key for Gun and S key for the Sword");
            Console.Write("Press the ESC to quit the game");

            //reset coordinates for all drawings
            Player.Placement = playerCoordinate;
            Boss.Placement = bossCoordinate;
            Gun.Placement = gunCoordinate;
            Sword.Placement = swordCoordinate;
            PlayerTextBox.Placement = playerTextBoxCoordinate;
            Text.Placement = textCoordinate;
            CornerScreenCoordinate = cornerScreenCoordinate;
        }

        static void IgnoreInputOnAMethod(Action method)
        {
            var Done = false;
            while (!Done)
            {
                while (Console.KeyAvailable) Console.ReadKey(true);
                ConsoleKeyInfo key = Console.ReadKey(true);
                method();
                Done = true;
            }
        }

        static void AttackAnimation()
        {
            if (Gun.ShouldDraw)
            {
                Gun.BulletAnimation();
                DrawAttackNumberReduceBossHealth();
            }
            if (Sword.ShouldDraw)
            {
                DrawBossBattle();
            }

            if (Boss.Stats.HealthPower < 0)
            {
                BossDefeated();
            }
        }
        static void TextWhileInBattle()
        {
            PlayerTextBox.ShouldDraw = true;
            PlayerTextBox.DrawMe();
            Text.ShouldDraw = true;
            Text.text = "You scumbag!";
            Text.DrawMe();
        }

        static void BossDefeated()
        {

        }
        static void DrawAttackNumberReduceBossHealth()
        {
            //Figure attack power minus boss hp
            var AttackAnimation = new Attack();

            AttackAnimation.Placement = new Coordinate
            {
                X = 65,
                Y = 10
            };
            AttackAnimation.DrawMe();
            AttackAnimation.Placement.Y = 10;
            var attackNumber = Player.Stats.Attack + Gun.Stats.Attack;
            Console.SetCursorPosition(73, 12);
            Console.Write(attackNumber);
            Thread.Sleep(300);
            AttackAnimation.DeleteMe();
            Boss.Stats.HealthPower = -(attackNumber);
        }

        /// <summary>
        /// Initiates the game by setting up coordinates
        /// calling drawing functions. 
        /// </summary>
        static void InitializeGame()
        {
            Player.Placement = new Coordinate()
            {
                X = 0,
                Y = 9
            };
            Boss.Placement = new Coordinate()
            {
                X = 80,
                Y = 7
            };
            Gun.Placement = new Coordinate()
            {
                X = 25,
                Y = 10
            };
            Sword.Placement = new Coordinate()
            {
                X = 25,
                Y = 7
            };
            PlayerTextBox.Placement = new Coordinate()
            {
                X = 12,
                Y = 0
            };
            Text.Placement = new Coordinate()
            {
                X = 17,
                Y = 2
            };
            CornerScreenCoordinate = new Coordinate()
            {
                X = 0,
                Y = Console.WindowHeight - 3
            };

            //Creating Stats
            Random random = new Random();
            Player.Stats = new CharacterStats
            {
                Attack = random.Next(15, 40),
                HealthPower = 300
            };
            Boss.Stats = new CharacterStats
            {
                Attack = random.Next(1, 5),
                HealthPower = 700
            };
            Gun.Stats = new CharacterStats
            {
                Attack = random.Next(10, 20)
            };

            Sword.ShouldDraw = false;
            Gun.ShouldDraw = true;
            DrawBossBattle();
        }
    }
}