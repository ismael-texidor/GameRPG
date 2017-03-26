using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameRPG.DrawingObjects
{
    class Fire:Drawing
    {
        public override string Rendering()
        {
            const string fire =
            "                (\n" +
            "    .            )        )\n" +
            "             (  (|              .\n" +
            "         )   )\\/ ( ( (\n" +
            " *  (   ((  /     ))\\))  (  )    )	\n" +
            "(     \\   )\\(          |  ))( )  (|	\n" +
            ">)     ))/   |          )/  \\((  ) \\	\n" +
            "(     (      .        -.     V )/   )(    (	\n" +
            "\\   /     .   \\            .       \\))   ))\n" +
            "  )(      (  | |   )            .    (  /	\n";

            return fire;
        }
        public override void InitialPlacements()
        {
            Placement = new Coordinate
            {
                X = 0,
                Y = 0
            };
        }
    }
}
