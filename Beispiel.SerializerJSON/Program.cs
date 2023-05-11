using System.Text.Json;
using System.Text.Json.Serialization;

namespace Beispiel.SerializerJSON
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Hero batman = new Hero()
            {
                Name = "Batman",
                FirstName = "Bruce",
                LastName = "Wayne",
                Gadgets = new List<string>() { "Batmobile", "Batarang" }
            };
            Hero robin = new Hero()
            {
                Name = "Robin",
                FirstName = "Dick",
                LastName = "Garryson",
                Gadgets = new List<string>() { "Make-up-Tasche" }
            };
            batman.Partner = robin;
            robin.Partner = batman; 

            JsonSerializerOptions options = new JsonSerializerOptions()
            {
                WriteIndented = true,
                ReferenceHandler = ReferenceHandler.Preserve
            };

            // Serialisierung
            string batmanJson = JsonSerializer.Serialize(batman, options);
            Console.WriteLine(batmanJson);

            // Deserialisierung
            Hero newBatman = JsonSerializer.Deserialize<Hero>(batmanJson, options);
            Console.WriteLine(newBatman.Name);
        }
    }
    class Hero
    {
        public string Name { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Hero Partner { get; set; }
        public List<string> Gadgets { get; set; }
        private int age;
        public string Stuff;
        public int GetAge()
        {
            return age;
        }
    }
}