using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameRPG
{
    class HelperMethods
    {
        /// <summary>
        /// Erases a line from the console.
        /// </summary>
        public void EraseConsoleLine()
        {
            Console.SetCursorPosition(0, Console.CursorTop);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(0, Console.CursorTop - 1);
        }
        /// <summary>
        /// Takes a method and runs it while ignoring all console input. 
        /// </summary>
        /// <param name="method"></param>
        public void IgnoreInputOnAMethod(Action method)
        {
            var done = false;
            while (!done)
            {
                while (Console.KeyAvailable) Console.ReadKey(true);
                Console.ReadKey(true);
                method();
                done = true;
            }
        }
    }
}
