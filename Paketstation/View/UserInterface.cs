using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Paketstation.View
{
    public class UserInterface
    {
        #region Attributes
        #endregion
        #region Properties
        #endregion
        #region Constructors
        #endregion
        public UserInterface()
        {
            Splashinfo();
        }
        #region Methods
        #endregion
        public void Splashinfo()
        {
            string[] titles = { "Projektname:", "Version:", "Datum:", "Autor:", "Klasse:" };
            string[] information = { "Paketstation", "1.0", "26.10.2020", "Jan-Lukas Spilles", "IA119" };
            Console.CursorTop = 5;
            for (int i = 0; i < information.Length; i++)
            {
                Console.CursorLeft = (Console.WindowWidth - 32) / 2;
                Console.WriteLine("{0,-12}{1,20}", titles[i], information[i]);
                Thread.Sleep(400);
            }
            Console.SetCursorPosition((Console.WindowWidth - 50) / 2, Console.WindowHeight - 2);
            Console.WriteLine("Drücken Sie eine beliebige Taste, um fortzufahren.");
        }

        public int ShowMainMenu(string menuPoints, string headline)
        {
            string[] menu = menuPoints.Split(';');

            int currentItem = 0;
            ConsoleKeyInfo key;

            do
            {
                Console.Clear();
                Console.WriteLine(headline + "\n");

                for (int counter = 0; counter < menu.Length; counter++)
                {
                    WriteWithColor((currentItem == counter) ? ConsoleColor.Green : ConsoleColor.White, menu[counter]);
                }

                Console.WriteLine("\n\nNavigieren können Sie mit den Pfeiltasten.\nBestätigen Sie Ihre Eingabe mit der return-Taste.");
                key = Console.ReadKey(true);
                if (key.Key == ConsoleKey.DownArrow)
                {
                    currentItem++;
                    if (currentItem > menu.Length - 1)
                    {
                        currentItem = 0;
                    }
                }
                else if (key.Key == ConsoleKey.UpArrow)
                {
                    currentItem--;
                    if (currentItem < 0)
                    {
                        currentItem = menu.Length - 1;
                    }
                }
                else
                {
                    //Nichts
                }
            } while (key.Key != ConsoleKey.Enter);
            return currentItem;
        }

        public void WriteWithColor(ConsoleColor color, string format, params string[] text)
        {
            ConsoleColor oldColor = Console.ForegroundColor;
            Console.ForegroundColor = color;
            Console.WriteLine(format, text);
            Console.ForegroundColor = oldColor;
        }

        public void WriteWithColor(ConsoleColor color, params string[] text)
        {
            ConsoleColor oldColor = Console.ForegroundColor;
            Console.ForegroundColor = color;
            Console.WriteLine(text);
            Console.ForegroundColor = oldColor;
        }
    }
}
