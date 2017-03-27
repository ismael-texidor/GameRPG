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

        public void PlayerTextInitialPlacement()
        {
            Placement = new Coordinate()
            {
                X = 17,
                Y = 1
            };
        }
        public void BossTextInitialPlacement()
        {
            Placement = new Coordinate()
            {
                X = 94,
                Y = 1
            };
        }
        public void BossNameInitialPlacement()
        {
            Placement = new Coordinate()
            {
                X = 98,
                Y = 5
            };
        }
        public void PlayerNameInitialPlacement()
        {
            Placement = new Coordinate()
            {
                X = 20,
                Y = 5
            };
        }
        public void AddingBossName(string name)
        {
            BossNameInitialPlacement();
            ShouldDraw = true;
            charactherText = name;
            DrawMe();
        }
        public void AddingPlayerName(string name)
        {
            PlayerNameInitialPlacement();
            ShouldDraw = true;
            charactherText = name;
            DrawMe();
        }
    }
}
