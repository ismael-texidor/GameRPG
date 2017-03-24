using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameRPG.DrawingObjects
{
    class Text:Drawing
    {
        public string text { get; set; }

        public override string Rendering()
        {
            return text;
        }
    }
}
