using System;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameRPG
{
    abstract class Drawing
    {
        public virtual int? ThreadingSpeed { get; set; }
        public virtual bool? LineDropIt { get; set; }
        public virtual Coordinate Placement { get; set; }
        public virtual CharacterStats Stats { get; set; }
        public virtual bool ShouldDraw { get; set; }
        public virtual ConsoleColor? DrawingColor { get; set; }

        //Override to render any string drawing I want. 
        public virtual string Rendering()
        {
            return "Override For Each Drawing Object";
        }
        
        /// <summary>
        /// Draws whatever is overriden in the Rendering method. 
        /// </summary>
        public virtual void DrawMe()
        {
            if(ThreadingSpeed == null)
            {
                ThreadingSpeed = 200;
            }
            if(DrawingColor == null)
            {
                DrawingColor = ConsoleColor.White;
            }
            if (ShouldDraw)
            {
                var lineArray = Rendering().Split(new string[] { "\r\n", "\n" }, StringSplitOptions.None);
                foreach (string line in lineArray)
                {   
                    Console.SetCursorPosition(Placement.X, Placement.Y);
                    Console.ForegroundColor = DrawingColor.Value;
                    Console.Write(line);
                    Placement.Y++;
                    if(LineDropIt == true)
                    {
                        Thread.Sleep(ThreadingSpeed.Value);
                    }
                }
            }
            ResetTopPlacement();
            Console.ResetColor();
        }

        /// <summary>
        /// Deletes  whatever is overriden in the Rendering method. 
        /// </summary>
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
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(delete);
                Placement.Y++;
            }
            ResetTopPlacement();
        }

        /// <summary>
        /// Override to set the initial placement of each object. 
        /// </summary>
        public virtual void InitialPlacements()
        {
            //override with initial placements. 
        }

        /// <summary>
        /// Resets the Y component of the placement Object. 
        /// </summary>
        public virtual void ResetTopPlacement()
        {
            //override with resetplacements. 
        }
    }
}
