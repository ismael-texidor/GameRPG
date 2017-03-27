using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameRPG.DrawingObjects
{
    class TheEnd:Drawing
    {
        public override string Rendering()
        {
            const string end =
                "_________          _______    _______  _        ______  \n" +
                "\\__   __/|\\     /|(  ____ \\  (  ____ \\( (    /|(  __  \\ \n" +
                "   ) (   | )   ( || (    \\/  | (    \\/|  \\  ( || (  \\  )\n" +
                "   | |   | (___) || (__      | (__    |   \\ | || |   ) |\n" +
                "   | |   |  ___  ||  __)     |  __)   | (\\ \\) || |   | |\n" +
                "   | |   | (   ) || (        | (      | | \\   || |   ) |\n" +
                "   | |   | )   ( || (____/\\  | (____/\\| )  \\  || (__/  )\n" +
                "   )_(   |/     \\|(_______/  (_______/|/    )_)(______/ ";

            return end;
        }
        public override void InitialPlacements()
        {
            Placement = new Coordinate
            {
                X = 30,
                Y = 10
            };
        }
    }
}
