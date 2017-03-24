using System;
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

    }
}
