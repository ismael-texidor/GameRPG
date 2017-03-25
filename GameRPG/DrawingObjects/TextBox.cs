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
                "  ______________________      \n" +
                "/\\                     \\    \n" +
                " \\_|                    |     \n" +
                "   |                    |     \n" +
                "   |                    |     \n" +
                "   | ___________________|     \n" +
                "   \\_ / _______________/     \n"+
                "  o                              ";
            return textbox;
        }

        public virtual void PlayerTextBoxInitialPlacement()
        {
            Placement = new Coordinate()
            {
                X = 12,
                Y = 0
            };
        }
    }
}
