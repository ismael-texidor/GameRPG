using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameRPG.DrawingObjects
{
    class Town:Drawing
    {
        TextBox BossTextBox = new TextBox();
        Fire Fire = new Fire();
        public override string Rendering()
        {
            const string town =
            "                                                           |>>>                 \n" +
            "                   _                      _                |					\n" +
            "    ____________ .' '.    _____/----/-\\ .' './========\\   / \\			    \n" +
            "   //// ////// /V_.-._\\  |.-.-.|===| _ |-----| u    u |  /___\\				\n" +
            "  // /// // ///==\\ u |.  || | ||===||||| |T| |   ||   | .| u |_ _ _ _ _ _ 	\n" +
            " ///////-\\////====\\==|:::::::::::::::::::::::::::::::::::|u u| U U U U U 	\n" +
            " |----/\\u |--|++++|..|'''''''''''::::::::::::::''''''''''|+++|+-+-+-+-+-+		\n" +
            " |u u|u | |u ||||||..|              '::::::::'           |===|>=== _ _ ==		\n" +
            " |===|  |u|==|++++|==|              .::::::::.           | T |....| V |..		\n" +
            " |u u|u | |u ||HH||         \\|/    .::::::::::. 								\n" +
            " |===|_.|u|_.|+HH+|_              .::::::::::::.              _ 				\n" +
            "                __(_)___         .::::::::::::::.         ___(_)__             \n" +
            "---------------/  / \\  /|       .:::::;;;:::;;:::.       |\\  / \\  \\-------	\n" +
            "______________/_______/ |      .::::::;;:::::;;:::.      | \\_______\\________  \n" +
            "|       |     [===  =] /|     .:::::;;;::::::;;;:::.     |\\ [==  = ]   |       \n" +
            "|_______|_____[ = == ]/ |    .:::::;;;:::::::;;;::::.    | \\[ ===  ]___|____   \n" +
            "     |       |[  === ] /|   .:::::;;;::::::::;;;:::::.   |\\ [=  ===] |		 \n" +
            "_____|_______|[== = =]/ |  .:::::;;;::::::::::;;;:::::.  | \\[ ==  =]_|______   \n" +
            " |       |    [ == = ] /| .::::::;;:::::::::::;;;::::::. |\\ [== == ]      |    \n" +
            "_|_______|____[=  == ]/ |.::::::;;:::::::::::::;;;::::::.| \\[  === ]______|_   \n" +
            "   |       |  [ === =] /.::::::;;::::::::::::::;;;:::::::.\\ [===  =]   |       \n" +
            "___|_______|__[ == ==]/.::::::;;;:::::::::::::::;;;:::::::.\\[=  == ]___|_____  \n";

            return town;
        }

        public void TownFire(int RunTimes)
        {
            Fire.LineDropIt = true;
            Fire.ShouldDraw = true;
            Fire.ThreadingSpeed = 200;
            Fire.InitialPlacements();
            Fire.DrawingColor = ConsoleColor.Red;
            while (RunTimes > 0)
            {
                TownFires();
                RunTimes--;
            }
        }
        private void TownFires()
        {
            var randomNumber = new Random();
            var Text = new List<string>();

            Text.Add("*Concentrates*\n" +
                    "Cast Fire");
            BossTextBox.AddBossListOfText(Text, false);
            Fire.DrawMe();
            Fire.Placement.X = randomNumber.Next(0, 30);
            Fire.Placement.Y = randomNumber.Next(0, 20);
            
        }
        public override void InitialPlacements()
        {
            //override with initial placements. 
            Placement = new Coordinate
            {
                X = 0,
                Y = 7
            };
        }
    }
}
