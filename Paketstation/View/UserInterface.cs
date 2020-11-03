using Paketstation.Model;
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
        public Paket PaketEinliefern(string name)
        {
            Console.Clear();
            Console.WriteLine("Was wollen Sie versenden?");
            string inhalt = Console.ReadLine();
            Console.Clear();
            Console.WriteLine("Geben Sie einen Empfänger für Ihr Paket an.");
            string empfaenger = Console.ReadLine();
            return new Paket(empfaenger, name, inhalt);
        }

        public void KeinFreiesSchliessfach()
        {
            Console.Clear();
            Console.WriteLine("Es ist kein freies Schliessfach verfügbar.");
            Console.ReadKey(true);
        }

        public void KundeHatSchonEinPaket()
        {
            Console.Clear();
            Console.WriteLine("Es kann nicht mehr als ein Paket getragen werden. Öffnen Sie Ihr aktuelles bitte zunächst!");
            Console.ReadKey(true);
        }

        public void PaketeListen(int[] paketnummern)
        {
            Console.Clear();
            if (paketnummern.Length == 0)
            {
                Console.WriteLine("Es befinden sich keine Pakete für Sie in der Station.");
            }
            else
            {
                Console.WriteLine("Folgende Paketnummern gehören zu Paketen, die an Sie adressiert sind:");
                for (int zaehler = 0; zaehler < paketnummern.Length; zaehler++)
                {
                    Console.WriteLine($"Paket {zaehler}: Paketnummer: {paketnummern[zaehler]}");
                }
            }
            Console.ReadKey(true);
        }

        public void PaketOeffnen(Paket p)
        {
            Console.Clear();
            Console.WriteLine("Absender: " + p.Absender);
            Console.WriteLine("Inhalt: " + p.Inhalt);
            Console.ReadKey(true);
        }

        public void MeldungKeinPaket()
        {
            Console.Clear();
            Console.WriteLine("Sie besitzen kein Paket zum Öffnen!");
            Console.ReadKey(true);
        }

        public int AusgabePaket()
        {
            Console.Clear();
            Console.WriteLine("Bitte geben Sie die Id des auszugebenen Pakets an.");
            return Convert.ToInt32(Console.ReadLine());
        }

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
    }
}
