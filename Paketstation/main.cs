//Autor:        Jan-Lukas Spilles
//Klasse:       IA119
//Datei:        main.cs
//Datum:        19.11.2020
//Beschreibung: Programmeinstieg
namespace Paketstation
{
    public class main
    {
        static void Main(string[] args)
        {
            Controller c = new Controller(true);
            c.run();
        }
    }
}
