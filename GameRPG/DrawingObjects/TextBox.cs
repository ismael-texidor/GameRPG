using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameRPG.DrawingObjects
{
    class TextBox:Drawing
    {
        Text BossText = new Text();
        Text PlayerText = new Text();
        Text BossNameText = new Text();
        Text PlayerNameText = new Text();
        Text ContinueText = new Text();
        public string name { get; set; }
        public override string Rendering()
        {
            const string textbox =
                "    ______________________     \n" +
                "   |                     |     \n" +
                "   |                     |     \n" +
                "   |                     |     \n" +
                "   | ____________________|     \n" +
                "   \\_ /                 |     \n" +
                "       \\________________/      \n" +
                "  o                              ";
            return textbox;
        }
        public void AddBossListOfText (List<string> ListText, bool stopForUser)
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
            BossNameText.AddingBossName("Random Evil Boss");
            BossText.ThreadingSpeed = 600;
            BossText.BossTextInitialPlacement();
            BossText.ShouldDraw = true;
            BossText.LineDropIt = true;
            BossText.charactherText = TextList;
            BossText.DrawMe();
            ContinueText.ContinueText();
            var key = Console.ReadKey().Key;
            ContinueText.DeleteMe();
            BossText.BossTextInitialPlacement();
            BossText.DeleteMe();
        }
        public void AddTextBossWithoutStop(string TextList)
        {
            BossTextBoxInitialPlacement();
            ShouldDraw = true;
            DrawMe();
            BossNameText.AddingBossName("Random Evil Boss");
            BossText.ThreadingSpeed = 500;
            BossText.BossTextInitialPlacement();
            BossText.ShouldDraw = true;
            BossText.LineDropIt = true;
            BossText.charactherText = TextList;
            BossText.DrawMe();
            BossText.ThreadingSpeed = 500;
            BossText.BossTextInitialPlacement();
            BossText.DeleteMe();
        }

        public void AddPlayerListOfText(List<string> ListText, bool stopForUser)
        {
            if (stopForUser)
                foreach (string x in ListText)
                {
                    AddTextPlayerWithStop(x);
                }
            else
                foreach (string x in ListText)
                {
                    AddTextPlayerWithoutStop(x);
                }
        }
        public void AddTextPlayerWithStop(string TextList)
        {
            PlayerTextBoxInitialPlacement();
            ShouldDraw = true;
            DrawMe();
            PlayerNameText.AddingPlayerName(name);
            PlayerText.ThreadingSpeed = 600;
            PlayerText.PlayerTextInitialPlacement();
            PlayerText.ShouldDraw = true;
            PlayerText.LineDropIt = true;
            PlayerText.charactherText = TextList;
            PlayerText.DrawMe();
            var key = Console.ReadKey().Key;
            PlayerText.PlayerTextInitialPlacement();
            PlayerText.DeleteMe();
        }
        public void AddTextPlayerWithoutStop(string TextList)
        {
            PlayerTextBoxInitialPlacement();
            ShouldDraw = true;
            DrawMe();
            PlayerNameText.AddingPlayerName(name);
            PlayerText.ThreadingSpeed = 500;
            PlayerText.PlayerTextInitialPlacement();
            PlayerText.ShouldDraw = true;
            PlayerText.LineDropIt = true;
            PlayerText.charactherText = TextList;
            PlayerText.DrawMe();
            PlayerText.ThreadingSpeed = 500;
            PlayerText.PlayerTextInitialPlacement();
            PlayerText.DeleteMe();
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
