using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameRPG.DrawingObjects
{
    class Boss:Drawing
    {
        public override bool ShouldDraw
        {
            get
            {
                return true;
            }

            set
            {
                base.ShouldDraw = true;
            }
        }
        public override string Rendering()
        {
            const string boss =
                "       -. -. `.  / .-' _.'  _       \n" +
                "     .--`. `. `| / __.-- _' `       \n" +
                "    '.-.  \\  \\ |  /   _.' `_        \n" +
                "    .-. \\  `  || |  .' _.-' `.      \n" +
                "  .' _ \\ '  -    -'  - ` _.-.       \n" +
                "   .' `. %%%%%   | %%%%% _.-.`-     \n" +
                " .' .-. ><(@)> ) ( <(@)>< .-.`.     \n" +
                "   (('`(   -   | |   -   )''))      \n" +
                "  / \\#)\\     (.(_).)    /(#//\\      \n" +
                " ' / ) ((  /   | |   \\  )) (`.`.    \n" +
                " .'  (.) \\ .md88o88bm. / (.) \\)     \n" +
                "   / /| / \\ `Y88888Y' / \\ | \\ \\     \n" +
                " .' / O  / `.   -   .' \\  O \\ \\    \n" +
                "  / /(O)/ /| `.___.' | \\(O) \\      \n" +
                "   / / / / |  |   |  |\\  \\  \\ \\     \n" +
                "   / / // /|  |   |  |  \\  \\ \\      \n" +
                " _.--/--/'( ) ) ( ) ) )`\\-\\-\\-._    \n" +
                "( ( ( ) ( ) ) ( ) ) ( ) ) ) ( ) )      \n";
            return boss;
        }
        public override void InitialPlacements()
        {
            //override with initial placements. 
            Placement = new Coordinate()
            {
                X = 80,
                Y = 7
            };
        }
        public override void ResetTopPlacement()
        {
            Placement.Y = 7;
        }
    }
}
