using System;
using System.Collections.Generic;
using System.Text;

namespace Util
{
    class Logger
    {
        public static void Log(int lvl, string str)
        {
            if (lvl == 0)
            {
                Console.WriteLine("[DEBUG]: " + str);
            }
            else if (lvl == 1) {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("[WARN]: " + str);
                Console.ForegroundColor = ConsoleColor.White;
            } else if (lvl == 2)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("[ERROR]: " + str);
                Console.ForegroundColor = ConsoleColor.White;
            } else if (lvl == 3)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("[CRIT]: " + str);
                Console.ForegroundColor = ConsoleColor.White;
            }
        }

        public static void Log(int lvl, string str, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            string prefix = "";
            switch (lvl)
            {
                case 1:
                    prefix = "[DEBUG]: ";
                    break;
                case 2:
                    prefix = "[WARN]: ";
                    break;
                case 3:
                    prefix = "[ERROR]: ";
                    break;
                case 4:
                    prefix = "[CRIT]: ";
                    break;
                default:
                    break;
            }
            Console.WriteLine(prefix + str);
            Console.ForegroundColor = ConsoleColor.White;
        }

        public static void Log(string str)
        {
            Console.WriteLine("[?]: "+str);
        }
    }
}
