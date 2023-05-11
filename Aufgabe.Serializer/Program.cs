using System.Text.Json;
using System.Text.Json.Nodes;

namespace Aufgabe.Serializer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("-- Auswahl: 1 = Laden, 2 = Speichern, 0 = Exit --");
                char userInput = Console.ReadKey().KeyChar;
                if (userInput == '1')
                {
                    Console.Clear();
                    LoadMenu();
                }
                else if (userInput == '2')
                {
                    Console.Clear();
                    SaveMenu();
                }
                else if (userInput == '0')
                {
                    Console.Clear();
                    exit = true;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Eingabe ungültig!");
                    Console.WriteLine();
                    continue;
                }
            }
        }
        static void LoadMenu()
        {
            Console.WriteLine("-- Laden --");
            Console.WriteLine("Bitte geben Sie den Nachnamen der Person an: ");
            string saveFile = Console.ReadLine();
            if (!File.Exists(saveFile + ".txt"))
            {
                Console.Clear();
                Console.WriteLine("Datei nicht vorhanden!");
            }
            else
            {
                Person person = JsonSerializer.Deserialize<Person>(File.ReadAllText(saveFile + ".txt"));
                Console.Clear();
                Console.WriteLine("-- Dateien wurden geladen --");
                Console.WriteLine("Ausgabe: ");
                Console.WriteLine(person.Vorname);
                Console.WriteLine(person.Nachname);
                Console.WriteLine(person.Alter);
            }      
        }
        static void SaveMenu()
        {
            Person person = new Person();
            Console.WriteLine("-- Speichern --");
            Console.WriteLine("Bitte geben Sie den Vornamen der Person ein: ");
            person.Vorname = Console.ReadLine();
            Console.WriteLine("Bitte geben Sie den Nachnamen der Person ein: ");
            person.Nachname = Console.ReadLine();
            Console.WriteLine("Bitte geben Sie das Alter der Person ein: ");
            person.Alter = Convert.ToInt32(Console.ReadLine());

            string jsPerson = JsonSerializer.Serialize(person);
            File.WriteAllText(person.Nachname + ".txt", jsPerson);
            Console.WriteLine($"-- Eingaben wurden gespeichert unter \"{person.Nachname}.txt\"! --");
        }
    }
    class Person
    {
        public string Vorname { get; set; }
        public string Nachname { get; set; }
        public int Alter { get; set; }
    }
}