//Autor:        Jan-Lukas Spilles
//Klasse:       IA119
//Datei:        UserInterface.cs
//Datum:        19.11.2020
//Beschreibung: Kümmert sich um Userinteraktionen

using Paketstation.Model;
using System;
using System.Threading;

namespace Paketstation
{
    public class UserInterface
    {
        #region Attributes
        private string _text;
        #endregion
        #region Properties
        public string Text { get => _text; set => _text = value; }
        #endregion
        #region Constructors       
        public UserInterface()
        {

        }
        public UserInterface(bool splashscreen)
        {
            if (splashscreen)
            {
                Splashinfo();
            }
            else
            {
                //Nichts
            }
        }
        #endregion
        #region Methods
        public void TextAusgeben()
        {
            Console.Clear();
            Console.WriteLine(Text);
            Console.ReadKey(true);
        }

        public void PaketeListen(int[] paketnummern)
        {
            Console.Clear();
            Console.WriteLine($"Es sind {paketnummern.Length} Pakete für Sie hinterlegt:");
            Console.WriteLine();
            Console.WriteLine("Nr        Paketnummer");

            for (int i = 0; i < paketnummern.Length; i++)
            {
                Console.WriteLine($"({i + 1})       {paketnummern[i]}");
            }

            Console.ReadKey(true);
        }

        public int AbfragePaketnummer()
        {
            Console.Clear();
            Console.WriteLine("Bitte geben Sie eine Paketnummer an:");
            return Convert.ToInt32(Console.ReadLine());
        }

        public string Kundenauthentifizierung()
        {
            Console.Clear();
            Console.WriteLine("Bitte authentifizieren Sie sich mit Ihrer Kundennummer");
            return Console.ReadLine();
        }

        private void Splashinfo()
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

        public void ShowExceptionText(string message)
        {
            Console.Clear();
            Console.WriteLine(message);
            Console.ReadKey(true);
        }

        public int SelectableMenu(string menuPoints, string headline)
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

        private void WriteWithColor(ConsoleColor color, string format, params string[] text)
        {
            ConsoleColor oldColor = Console.ForegroundColor;
            Console.ForegroundColor = color;
            Console.WriteLine(format, text);
            Console.ForegroundColor = oldColor;
        }

        private void WriteWithColor(ConsoleColor color, params string[] text)
        {
            ConsoleColor oldColor = Console.ForegroundColor;
            Console.ForegroundColor = color;
            Console.WriteLine(text);
            Console.ForegroundColor = oldColor;
        }
        #endregion

    }
}
