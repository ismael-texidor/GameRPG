using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameRPG.DrawingObjects
{
    class Text:Drawing
    {
        public string charactherText { get; set; }

        public override string Rendering()
        {
            return charactherText;
        }

        public virtual void PlayerTextInitialPlacement()
        {
            Placement = new Coordinate()
            {
                X = 17,
                Y = 1
            };
        }
        public virtual void BossTextInitialPlacement()
        {
            Placement = new Coordinate()
            {
                X = 94,
                Y = 1
            };
        }
    }
}
