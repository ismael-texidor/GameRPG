﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameRPG
{
    class Player: Drawing
    {
        public override string Rendering()
        {
            const string player =
       "          --.`           \n" +
       "          ://:           \n" +
       "          .//o-`         \n" +
       " `./ +:-`/ +/ o -`-+/ -  \n" +
       " ``/ o++-- +/ +-` :+:    \n" +
       "         ./ oyyy +       \n" +
       "         - ooh + ss      \n" +
       "         `sy / -oss      \n" +
       "        .+o.   +/        \n" +
       "         .o:    -o.      \n" +
       "     .-:/`      `:--`    \n";
            return player;
        }

        public override void DrawMe()
        {
            Console.SetCursorPosition(Placement.X, Placement.Y);
            Console.Write(Rendering());
        }
    }
}
