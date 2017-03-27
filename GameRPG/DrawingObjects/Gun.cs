using System;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameRPG.DrawingObjects
{
    class Gun: Drawing
    {
        public override string Rendering()
        {
            const string gun =
           ".+ hhyhyyosoooo:\n" +
           " ohyyo:/.-      \n" +
           ":hyys           \n" +
           "sysy-           \n";
            return gun;
        }

        /// <summary>
        /// Animates the bullet firing to the boss. 
        /// </summary>
        public void BulletAnimation()
        {
            //Animiation
            var left = 42;
                while (left < 80)
                {
                Console.SetCursorPosition(left, 10);
                Console.Write("==>");
                Console.SetCursorPosition(left, 10);
                Console.Write(" ");
                left++;
                Thread.Sleep(10);
            }
            //Animation
            Console.SetCursorPosition(80, 10);
            Console.Write("  ");
        }
        public override void InitialPlacements()
        {
            Placement = new Coordinate()
            {
                X = 25,
                Y = 10
            };
        }
        public override void ResetTopPlacement()
        {
            Placement.Y = 10;
        }
    }
}
