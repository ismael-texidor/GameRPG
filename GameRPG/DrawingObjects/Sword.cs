using System;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameRPG.DrawingObjects
{
    class Sword: Drawing
    {
        public override string Rendering()
        {
            const string sword =
             "            `...` \n" +
             "         `..``    \n" +
             "  .  .-..`        \n" +
             " .o/-.            \n" +
             "//:```            \n";
            return sword;
        }
        public void SwordAnimation()
        {
            //Animiation
            var left = 25;
            while (left < 64)
            {
                Placement.X = left;
                DrawMe();
                Thread.Sleep(10);
                DeleteMe();
                left++;
                //Thread.Sleep(60);
            }
            Placement.X = 25;
            DrawMe();
        }
        public override void ResetTopPlacement()
        {
            Placement.Y = 7;
        }

    }
}
