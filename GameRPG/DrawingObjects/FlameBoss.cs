using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameRPG.DrawingObjects
{
    class FlameBoss: Drawing
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
"                            (					\n" +
"                .            )        )			\n" +
"                         (  (|              .			\n" +
"                     )   )\\/ ( ( (				\n" +
"             *  (   ((  /     ))\\))  (  )    )			\n" +
"           (     \\   )\\(          |  ))( )  (|			\n" +
"           >)     ))/   |          )/  \\((  ) \\		\n" +
"           (     (      .        -.     V )/   )(    (		\n" +
"            \\   /     .   \\            .       \\))   ))	\n" +
"              )(      (  | |   )            .    (  /		\n" +
"             )(    ,'))     \\ /          \\( `.    )		\n" +
"             (\\>  ,'/__      ))            __`.  /		\n" +
"            ( \\   | /  ___   ( \\/     ___   \\ | ( (		\n" +
"             \\.)  |/  /   \\__      __/   \\   \\|  ))		\n" +
"            .  \\. |>  \\      | __ |      /   <|  /		\n" +
"                 )/    \\____/ :..: \\____/     \\ <		\n" +
"          )   \\ (|__  .      / ;: \\          __| )  (		\n" +
"         ((    )\\)  ~--_     --  --      _--~    /  ))		\n" +
"          \\    (    |  ||               ||  |   (  /		\n" +
"                \\.  |  ||_             _||  |  /		\n" +
"                  > :  |  ~V+-I_I_I-+V~  |  : (.		\n" +
"                 (  \\:  T\\   _     _   /T  : ./		\n" +
"                  \\  :    T^T T-+-T T^T    ;<			\n" +
"                   \\..`_       -+-       _'  )			\n" +
"                     . `--=.._____..=--'. ./        		  ";
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
