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
        Coordinate CornerScreenCoordinate { get; set; }
        HelperMethods HelperMethods = new HelperMethods();
        //Drawing Objects.
        StartGameBackground GameBackground = new StartGameBackground();
        Town Town = new Town();
        Player Player = new Player();
        Boss Boss = new Boss();
        Gun Gun = new Gun();
        Sword Sword = new Sword();
        TextBox PlayerTextBox = new TextBox();
        TextBox BossTextBox = new TextBox();
        Text PlayerText = new Text();
        Text BossText = new Text();
        //Generating random numbers for stats.
        Random randomNumber = new Random();

        public bool StartGame()
        {
            InitializeGame();
            ConsoleKeyInfo keyInfo;
            while ((keyInfo = Console.ReadKey(true)).Key != ConsoleKey.Escape)
            {
                switch (keyInfo.Key)
                {
                    //attack
                    case ConsoleKey.Spacebar:
                        //AttackAnimation is the Method
                        HelperMethods.IgnoreInputOnAMethod(AttackAnimation);
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
        /// Initiates the game by setting up drawing placement
        /// and calling the drawing methods. 
        /// </summary>
        void InitializeGame()
        {
            //set initial positions before drawing. 
            GameBackground.InitialPlacements();
            Town.InitialPlacements();
            Player.InitialPlacements();
            Boss.InitialPlacements();
            Gun.InitialPlacements();
            Sword.InitialPlacements();
            PlayerTextBox.PlayerTextBoxInitialPlacement();
            PlayerText.PlayerTextInitialPlacement();
            CornerScreenCoordinate = new Coordinate()
            {
                X = 0,
                Y = Console.WindowHeight - 3
            };

            //inialize stats. 
            Player.Stats = new CharacterStats
            {
                Attack = randomNumber.Next(15, 40),
                HealthPower = 300
            };
            Boss.Stats = new CharacterStats
            {
                Attack = randomNumber.Next(1, 5),
                HealthPower = 700
            };
            Gun.Stats = new CharacterStats
            {
                Attack = randomNumber.Next(10, 20)
            };
            Sword.Stats = new CharacterStats
            {
                Attack = randomNumber.Next(10, 20)
            };

            //Why bring a knife to a gun fight?  
            Sword.ShouldDraw = false;
            Gun.ShouldDraw = true;

            DrawInitialGameBackground();
            DrawBossBattle();
        }

        void DrawInitialGameBackground()
        {
            //GameBackground.LineDropIt = true;
            //GameBackground.ShouldDraw = true;
            //GameBackground.DrawMe();
            //var done = false;
            //var name = "";
            //do
            //{
            //    char c = Console.ReadKey().KeyChar;
            //    name += c;
            //    if (name.Length >= 10 || name.Contains("\r"))
            //    {
            //        done = true;
            //        name = name.Replace("\r", "").Replace("\n", "");
            //        name.Trim();
            //        if (name.Length == 0)
            //        {
            //            Console.Write("Um, you kind of need a name, let's try this again. This message will magically disapear in 5 seconds.");
            //            Thread.Sleep(5000);
            //            HelperMethods.EraseConsoleLine();
            //            done = false;
            //        }

            //        if (done)
            //        {
            //            Console.Write("Press Enter if you would like " + name + " as your player's name, otherwise press any key to enter another name.");
            //            var key = Console.ReadKey().Key;
            //            done = false;
            //            if(key == ConsoleKey.Enter)
            //            {
            //                done = true;
            //            }
            //            else
            //            {
            //                name = "";
            //            }
            //            HelperMethods.EraseConsoleLine();
            //        }
            //    }
            //} while (!done);

            //Player.Name = name;
            Console.Clear();
            Town.LineDropIt = true;
            Town.ShouldDraw = true;
            Town.DrawMe();
            Boss.DrawMe();
            var Text = new List<string>();
            Text.Add("Oh look a random town\n"+
                "I'm a evil monster. \n"+
                "What should I do?!");
            Text.Add("I should probably\n" +
                "destroy it. \n");
            BossTextBox.AddListOfText(Text, true);
            Town.TownFire(randomNumber.Next(4,9));
            
        }
        /// <summary>
        ///Create Boss Battle Drawings.
        /// </summary>
        void DrawBossBattle()
        {
            Coordinate cornerScreenCoordinate = new Coordinate()
            {
                X = CornerScreenCoordinate.X,
                Y = CornerScreenCoordinate.Y
            };

            //Clear Screen.
            Console.Clear();

            //Draw the player.
            Player.DrawMe();
            //Draw the weapons.
            Gun.DrawMe();
            Sword.DrawMe();
            //Draw the boss.    
            Boss.DrawMe();

            //Draw TextBox and Text.
            Console.SetCursorPosition(cornerScreenCoordinate.X, cornerScreenCoordinate.Y);
            Console.WriteLine("Press the spacebar to attack.");
            Console.WriteLine("Press the A key for your gun, and the S key for your sword.");
            Console.Write("Press the ESC to quit the game.");

            CornerScreenCoordinate = cornerScreenCoordinate;
        }

        void AttackAnimation()
        {
            if (Gun.ShouldDraw)
            {
                Gun.BulletAnimation();
                DrawAttackNumberReduceBossHealth(true);
            }
            if (Sword.ShouldDraw)
            {
                Sword.SwordAnimation();
                DrawAttackNumberReduceBossHealth(false);
            }

            if (Boss.Stats.HealthPower < 0)
            {
                BossDefeated();
            }
        }

        void TextWhileInBattle()
        {
            PlayerTextBox.ShouldDraw = true;
            PlayerTextBox.DrawMe();
            PlayerText.ShouldDraw = true;
            PlayerText.charactherText = "You scumbag!";
            PlayerText.DrawMe();
        }

        static void BossDefeated()
        {

        }

        /// <summary>
        /// Draws attack animiation and reduces boss's health.
        /// </summary>
        /// <param name="gun">If a the player has a gun different animations are shown
        /// </param>
        void DrawAttackNumberReduceBossHealth(bool gun)
        {
            var GunAttackAnimation = new GunAttack();
            var SwordAttackAnimation = new SwordAttack();
            int attackNumber = 0;
            if(gun)
            {
                GunAttackAnimation.InitialPlacements();
                GunAttackAnimation.DrawMe();
                GunAttackAnimation.Placement.Y = 10;
                attackNumber = Gun.Stats.Attack + Player.Stats.Attack;
                Console.SetCursorPosition(73, 12);
                Console.Write(attackNumber);
                Thread.Sleep(300);
                GunAttackAnimation.DeleteMe();
            }
            else
            {
                SwordAttackAnimation.InitialPlacements();
                SwordAttackAnimation.DrawMe();
                SwordAttackAnimation.Placement.Y = 10;
                attackNumber = Sword.Stats.Attack + Player.Stats.Attack;
                Console.SetCursorPosition(75, 12);
                Console.Write(attackNumber);
                Thread.Sleep(300);
                SwordAttackAnimation.DeleteMe();
            }
            Boss.Stats.HealthPower =- (attackNumber);
            Gun.Stats.Attack = randomNumber.Next(10, 20);
            Sword.Stats.Attack = randomNumber.Next(10, 20);
        }
    }
}