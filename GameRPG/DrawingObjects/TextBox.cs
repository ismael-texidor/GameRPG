using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameRPG.DrawingObjects
{
    class TextBox:Drawing
    {
        static Text BossText = new Text();
        static Text PlayerText = new Text();
        public override string Rendering()
        {
            const string textbox =
                "    ______________________     \n" +
                "   |                     |     \n" +
                "   |                     |     \n" +
                "   |                     |     \n" +
                "   | ____________________|     \n" +
                "   \\_ / ________________/     \n"+
                "  o                              ";
            return textbox;
        }
        public void AddListOfText (List<string> ListText, bool stopForUser)
        {
            if (stopForUser)
                foreach (string x in ListText)
                {
                    AddTextBossWithStop(x);
                }
            else
                foreach (string x in ListText)
                {
                    AddTextBossWithoutStop(x);
                }
        }
        public void AddTextBossWithStop(string TextList)
        {
            BossTextBoxInitialPlacement();
            ShouldDraw = true;
            DrawMe();
            BossText.ThreadingSpeed = 600;
            BossText.BossTextInitialPlacement();
            BossText.ShouldDraw = true;
            BossText.LineDropIt = true;
            BossText.charactherText = TextList;
            BossText.DrawMe();
            var key = Console.ReadKey().Key;
            BossText.BossTextInitialPlacement();
            BossText.DeleteMe();
        }
        public void AddTextBossWithoutStop(string TextList)
        {
            BossTextBoxInitialPlacement();
            ShouldDraw = true;
            DrawMe();
            BossText.ThreadingSpeed = 300;
            BossText.BossTextInitialPlacement();
            BossText.ShouldDraw = true;
            BossText.LineDropIt = true;
            BossText.charactherText = TextList;
            BossText.DrawMe();
            BossText.ThreadingSpeed = 300;
            BossText.BossTextInitialPlacement();
            BossText.DeleteMe();
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
                X = 90,
                Y = 0
            };
        }
    }
}
