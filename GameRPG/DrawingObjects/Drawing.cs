using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameRPG
{
   abstract class Drawing
    {
        public virtual Coordinate Placement { get; set; }
        public virtual CharacterStats Stats { get; set; }
        public virtual bool ShouldDraw { get; set; }
        //use these to override later 
        public virtual string Rendering()
        {
            return "Override For Each Drawing Object";
        }
        
        public virtual void DrawMe()
        {
            if (ShouldDraw)
            {
                var bossLineArray = Rendering().Split(new string[] { "\r\n", "\n" }, StringSplitOptions.None);
                foreach (string line in bossLineArray)
                {   
                    Console.SetCursorPosition(Placement.X, Placement.Y);
                    Console.Write(line);
                    Placement.Y++;
                }
            }
        }

        public virtual void DeleteMe()
        {
            var lineArray = Rendering().Split(new string[] { "\r\n", "\n" }, StringSplitOptions.None);
            foreach (string line in lineArray)
            {
                var delete = "";
                var character = line.ToArray();
                foreach(char x in character)
                {
                    delete = string.Concat(delete, " ");
                }
                Console.SetCursorPosition(Placement.X, Placement.Y);
                Console.Write(delete);
                Placement.Y++;
            }
        }
    }
}
