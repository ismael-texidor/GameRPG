using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameRPG.DrawingObjects
{
    class GunAttack:Drawing
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
            const string attack =
                "       . : .    \n" +
                "    '.  :  .'   \n" +
                "    .__'.:.'  . \n" +
                "    .  .':'.  . \n" +
                "    .'  :  '.   \n" +
                "       ' : '      ";
            return attack;
        }
       public override void InitialPlacements()
        {
            Placement = new Coordinate
            {
                X = 65,
                Y = 10
            };
        }
    }
}
