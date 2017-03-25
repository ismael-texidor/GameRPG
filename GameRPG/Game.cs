﻿using System;
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
        static StartGameBackground GameBackground = new StartGameBackground();
        static Player Player = new Player();
        static Boss Boss = new Boss();
        static Gun Gun = new Gun();
        static Sword Sword = new Sword();
        static TextBox PlayerTextBox = new TextBox();
        static Text Text = new Text();
        //Creating Stats
        static Random randomNumber = new Random();

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
        /// Initiates the game by setting up coordinates
        /// calling drawing functions. 
        /// </summary>
        static void InitializeGame()
        {
            //set initial positions before drawing. 
            GameBackground.InitialPlacements();
            Player.InitialPlacements();
            Boss.InitialPlacements();
            Gun.InitialPlacements();
            Sword.InitialPlacements();
            PlayerTextBox.PlayerTextBoxInitialPlacement();
            Text.PlayerTextInitialPlacement();
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

        static void DrawInitialGameBackground()
        {
            GameBackground.ShouldDraw = true;
            GameBackground.DrawMe();
            var name = "";
            do
            {
                char c = Console.ReadKey().KeyChar;
                if (c == '\n')
                    break;

                name += c;
            } while (name.Length <=10);

        }
        /// <summary>
        ///Create Boss Battle Drawings
        /// </summary>
        static void DrawBossBattle()
        {
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

            Text.Placement = textCoordinate;
            CornerScreenCoordinate = cornerScreenCoordinate;
        }

        /// <summary>
        /// Takes a method and runs it while ignoring all console input. 
        /// </summary>
        /// <param name="method"></param>
        static void IgnoreInputOnAMethod(Action method)
        {
            var Done = false;
            while (!Done)
            {
                while (Console.KeyAvailable) Console.ReadKey(true);
                Console.ReadKey(true);
                method();
                Done = true;
            }
        }

        static void AttackAnimation()
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
        /// <summary>
        /// Draws attack animiation
        /// </summary>
        /// <param name="gun">If a the player has a gun different animations are shown
        /// </param>
        static void DrawAttackNumberReduceBossHealth(bool gun)
        {
            var GunAttackAnimation = new GunAttack();
            var SwordAttackAnimation = new SwordAttack();
            int attackNumber = 0;
            if(gun)
            {
                GunAttackAnimation.Placement = new Coordinate
                {
                    X = 65,
                    Y = 10
                };
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
                SwordAttackAnimation.Placement = new Coordinate
                {
                    X = 67,
                    Y = 10
                };
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