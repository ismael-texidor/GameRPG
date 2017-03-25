using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameRPG.DrawingObjects
{
    class TextBox:Drawing
    {
        public override string Rendering()
        {
            const string textbox =
                "    _____________________     \n" +
                "   |                    |     \n" +
                "   |                    |     \n" +
                "   |                    |     \n" +
                "   | ___________________|     \n" +
                "   \\_ / _______________/     \n"+
                "  o                              ";
            return textbox;
        }

        public void PlayerTextBoxInitialPlacement()
        {
            Placement = new Coordinate()
            {
                X = 12,
                Y = 0
            };
        }
        public void BossTextBoxInitialPlacement()
        {
            Placement = new Coordinate()
            {
                X = 12,
                Y = 0
            };
        }
    }
}
